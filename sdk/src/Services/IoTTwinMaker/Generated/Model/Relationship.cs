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
    /// An object that specifies a relationship with another component type.
    /// </summary>
    public partial class Relationship
    {
        private string _relationshipType;
        private string _targetComponentTypeId;

        /// <summary>
        /// Gets and sets the property RelationshipType. 
        /// <para>
        /// The type of the relationship.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=256)]
        public string RelationshipType
        {
            get { return this._relationshipType; }
            set { this._relationshipType = value; }
        }

        // Check to see if RelationshipType property is set
        internal bool IsSetRelationshipType()
        {
            return this._relationshipType != null;
        }

        /// <summary>
        /// Gets and sets the property TargetComponentTypeId. 
        /// <para>
        /// The ID of the target component type associated with this relationship.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=256)]
        public string TargetComponentTypeId
        {
            get { return this._targetComponentTypeId; }
            set { this._targetComponentTypeId = value; }
        }

        // Check to see if TargetComponentTypeId property is set
        internal bool IsSetTargetComponentTypeId()
        {
            return this._targetComponentTypeId != null;
        }

    }
}