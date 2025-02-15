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
 * Do not modify this file. This file is generated from the iotfleetwise-2021-06-17.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Net;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

#pragma warning disable CS0612,CS0618,CS1570
namespace Amazon.IoTFleetWise.Model
{
    /// <summary>
    /// The update strategy for the state template. Vehicles associated with the state template
    /// can stream telemetry data with either an <c>onChange</c> or <c>periodic</c> update
    /// strategy. 
    /// 
    ///  <important> 
    /// <para>
    /// Access to certain Amazon Web Services IoT FleetWise features is currently gated. For
    /// more information, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/fleetwise-regions.html">Amazon
    /// Web Services Region and feature availability</a> in the <i>Amazon Web Services IoT
    /// FleetWise Developer Guide</i>.
    /// </para>
    ///  </important>
    /// </summary>
    public partial class StateTemplateUpdateStrategy
    {
        private OnChangeStateTemplateUpdateStrategy _onChange;
        private PeriodicStateTemplateUpdateStrategy _periodic;

        /// <summary>
        /// Gets and sets the property OnChange.
        /// </summary>
        public OnChangeStateTemplateUpdateStrategy OnChange
        {
            get { return this._onChange; }
            set { this._onChange = value; }
        }

        // Check to see if OnChange property is set
        internal bool IsSetOnChange()
        {
            return this._onChange != null;
        }

        /// <summary>
        /// Gets and sets the property Periodic.
        /// </summary>
        public PeriodicStateTemplateUpdateStrategy Periodic
        {
            get { return this._periodic; }
            set { this._periodic = value; }
        }

        // Check to see if Periodic property is set
        internal bool IsSetPeriodic()
        {
            return this._periodic != null;
        }

    }
}