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
    /// This is the response object from the UpdateComponentType operation.
    /// </summary>
    public partial class UpdateComponentTypeResponse : AmazonWebServiceResponse
    {
        private string _arn;
        private string _componentTypeId;
        private State _state;
        private string _workspaceId;

        /// <summary>
        /// Gets and sets the property Arn. 
        /// <para>
        /// The ARN of the component type.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=20, Max=2048)]
        public string Arn
        {
            get { return this._arn; }
            set { this._arn = value; }
        }

        // Check to see if Arn property is set
        internal bool IsSetArn()
        {
            return this._arn != null;
        }

        /// <summary>
        /// Gets and sets the property ComponentTypeId. 
        /// <para>
        /// The ID of the component type.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=256)]
        public string ComponentTypeId
        {
            get { return this._componentTypeId; }
            set { this._componentTypeId = value; }
        }

        // Check to see if ComponentTypeId property is set
        internal bool IsSetComponentTypeId()
        {
            return this._componentTypeId != null;
        }

        /// <summary>
        /// Gets and sets the property State. 
        /// <para>
        /// The current state of the component type.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public State State
        {
            get { return this._state; }
            set { this._state = value; }
        }

        // Check to see if State property is set
        internal bool IsSetState()
        {
            return this._state != null;
        }

        /// <summary>
        /// Gets and sets the property WorkspaceId. 
        /// <para>
        /// The ID of the workspace that contains the component type.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=128)]
        public string WorkspaceId
        {
            get { return this._workspaceId; }
            set { this._workspaceId = value; }
        }

        // Check to see if WorkspaceId property is set
        internal bool IsSetWorkspaceId()
        {
            return this._workspaceId != null;
        }

    }
}