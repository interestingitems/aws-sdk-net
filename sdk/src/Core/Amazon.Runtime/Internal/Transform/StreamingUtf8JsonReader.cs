/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Transform
{
    /// <summary>
    /// A wrapper around Utf8JsonReader that can handle reading from a stream.
    /// </summary>
    public ref struct StreamingUtf8JsonReader
    {
        private Utf8JsonReader _reader;
        /// <summary>
        /// The UTF8JsonReader attached to the instance. 
        /// </summary>
        public Utf8JsonReader Reader
        {
            get
            {
                return _reader;
            }
        }

        private Stream _stream;
        // due to all the resizing that happens with the byte array, pooling is not used here because the
        // byte array returned by Array.Resize is not owned by the pool.
        private byte[] _buffer;

        public StreamingUtf8JsonReader(Stream stream)
        {
            _stream = stream;
            // the default for STJ's deserializer is 16,384 but we'll leave this at 4096 for now.
            _buffer = new byte[4096];
            // need to initialize the reader even if the buffer is empty because auto-default of unassigned fields is only 
            // supported in C# 11+
            _reader = new Utf8JsonReader(_buffer);
            HandleUtf8Bom(ref _buffer);
        }

        // Since this is called in the constructor, the buffer is always filled and is gauranteed
        // to be the first read. Since it is guaranteed to be the first read we can remove the bom if it exists.
        private void HandleUtf8Bom(ref byte[] buffer)
        {
            int utf8BomLength = JsonConstants.Utf8Bom.Length;
            Debug.Assert(buffer.Length >= utf8BomLength);

            int bytesRead = _stream.Read(buffer, 0, buffer.Length);
            int start = 0;
            if (buffer.AsSpan().StartsWith(JsonConstants.Utf8Bom))
            {
                // this additional copy only happens once if a UTF8 bom exists.
                start += utf8BomLength;
                bytesRead -= utf8BomLength;
                Array.Copy(buffer, start, buffer, 0, bytesRead);
            }
            Array.Clear(buffer, bytesRead, buffer.Length - bytesRead);
            _reader = new Utf8JsonReader(buffer, isFinalBlock: bytesRead == 0, default);
        }

        // Custom delegate to handle ref parameters
        public delegate void RefAction(ref Utf8JsonReader reader);

        /// <summary>
        /// Method to allow passing the private _reader as ref. This is a hacky way to get around the error
        /// "a property or indexer may not be passed as an out or ref parameter". Use this when you need to pass
        /// the Utf8JsonReader to a method that requires a ref parameter. <see cref="JsonUnmarshallerContext.ToJsonDocument(ref StreamingUtf8JsonReader)"/>
        /// for usage example.
        /// </summary>
        /// <param name="action">The custom delegate</param>

        public void PassReaderByRef(RefAction action)
        {
            action(ref _reader);
        }

        /// <summary>
        /// The Reads data from the buffer and fetches more data from the stream to fill the buffer it more data exists.
        /// </summary>
        /// <returns>true if there is more data, false otherwise.</returns>
        public bool Read()
        {
            // hasMoreData can return false if the value starts in one buffer and leaks into the next buffer
            bool hasMoreData = _reader.Read();

            while (!hasMoreData)
            {
                GetMoreBytesFromStream(_stream, ref _buffer, ref _reader);
                if (_reader.IsFinalBlock)
                    break;

                hasMoreData = _reader.Read();
            }

            return hasMoreData;

        }

        private static void GetMoreBytesFromStream(Stream stream, ref byte[] buffer, ref Utf8JsonReader reader)
        {
            int bytesRead;
            bool resized = false;
            // if Read() returned false and we are here that means that we couldn't fully parse the JSON token 
            // because it was too large to fit in the remainder of the buffer.
            if (reader.BytesConsumed < buffer.Length)
            {
                ReadOnlySpan<byte> leftover = buffer.AsSpan().Slice((int)reader.BytesConsumed);
                int previousBufferLength = buffer.Length;

                if (leftover.Length == buffer.Length)
                {
                    resized = true;
                    Array.Resize(ref buffer, buffer.Length * 2);
                }

                leftover.CopyTo(buffer);
                bytesRead = stream.Read(buffer, leftover.Length, buffer.Length - leftover.Length);
                // remove null bytes if they exist, since we don't know when the stream will end and we could have doubled the buffer size.
                // otherwise the json reader will throw an exception.
                if (resized)
                    Array.Resize(ref buffer, bytesRead + previousBufferLength);
            }
            else
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
            }

            reader = new Utf8JsonReader(buffer, isFinalBlock: bytesRead == 0, reader.CurrentState);
        }
    }
}
