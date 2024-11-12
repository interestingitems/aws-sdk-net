using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Transform
{
    /// <summary>
    /// Interface for JSON unmarshallers which unmarshall objects from response data.
    /// The Unmarshallers are stateless, and only encode the rules for what data in
    /// the JSON stream goes into what members of an object.
    /// </summary>
    /// <typeparam name="T">The type of object the unmarshaller returns</typeparam>
    /// <typeparam name="TJsonUnmarshallerContext">The type of the Unmarshaller context. This can be any context that
    /// inherits from JsonUnmarshallerContext or JsonUnmarshallerContext itself. The context contains the
    /// state during parsing of the JSON stream. Usually an instance of JsonUnmarshallerContext</typeparam>
    public interface IJsonUnmarshaller<T, TJsonUnmarshallerContext>
    {
        // NetStandard2.0 does not support default interface methods
//#if NETCOREAPP3_1_OR_GREATER
//        /// <summary>
//        /// Given the current position in the JSON stream, extract a T
//        /// </summary>
//        /// <param name="input">The Json parsing context</param>
//        /// <param name="reader">The Utf8JsonReader</param>
//        /// <returns>An object of type T populated with data from the Json stream.</returns>
//        T Unmarshall(TJsonUnmarshallerContext input, ref Utf8JsonReader reader) => throw new NotImplementedException();
//#else
        /// <summary>
        /// Given the current position in the JSON stream, extract a T
        /// </summary>
        /// <param name="input">The Json parsing context</param>
        /// <param name="reader">The Utf8JsonReader</param>
        /// <returns>An object of type T populated with data from the Json stream.</returns>
        T Unmarshall(TJsonUnmarshallerContext input, ref Utf8JsonReader reader);
//#endif
    }
}
