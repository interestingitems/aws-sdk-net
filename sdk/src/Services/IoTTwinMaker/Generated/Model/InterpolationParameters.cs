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

/*
 * Do not modify this file. This file is generated from the iottwinmaker-2021-11-29.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Net;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.IoTTwinMaker.Model
{
    /// <summary>
    /// An object that specifies how to interpolate data in a list.
    /// </summary>
    public partial class InterpolationParameters
    {
        private InterpolationType _interpolationType;
        private long? _intervalInSeconds;

        /// <summary>
        /// Gets and sets the property InterpolationType. 
        /// <para>
        /// The interpolation type.
        /// </para>
        /// </summary>
        public InterpolationType InterpolationType
        {
            get { return this._interpolationType; }
            set { this._interpolationType = value; }
        }

        // Check to see if InterpolationType property is set
        internal bool IsSetInterpolationType()
        {
            return this._interpolationType != null;
        }

        /// <summary>
        /// Gets and sets the property IntervalInSeconds. 
        /// <para>
        /// The interpolation time interval in seconds.
        /// </para>
        /// </summary>
        public long IntervalInSeconds
        {
            get { return this._intervalInSeconds.GetValueOrDefault(); }
            set { this._intervalInSeconds = value; }
        }

        // Check to see if IntervalInSeconds property is set
        internal bool IsSetIntervalInSeconds()
        {
            return this._intervalInSeconds.HasValue; 
        }

    }
}