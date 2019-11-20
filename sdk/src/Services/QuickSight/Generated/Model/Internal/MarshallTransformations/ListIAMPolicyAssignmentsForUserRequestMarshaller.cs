/*
 * Copyright 2010-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
 * Do not modify this file. This file is generated from the quicksight-2018-04-01.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.QuickSight.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.QuickSight.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// ListIAMPolicyAssignmentsForUser Request Marshaller
    /// </summary>       
    public class ListIAMPolicyAssignmentsForUserRequestMarshaller : IMarshaller<IRequest, ListIAMPolicyAssignmentsForUserRequest> , IMarshaller<IRequest,AmazonWebServiceRequest>
    {
        /// <summary>
        /// Marshaller the request object to the HTTP request.
        /// </summary>  
        /// <param name="input"></param>
        /// <returns></returns>
        public IRequest Marshall(AmazonWebServiceRequest input)
        {
            return this.Marshall((ListIAMPolicyAssignmentsForUserRequest)input);
        }

        /// <summary>
        /// Marshaller the request object to the HTTP request.
        /// </summary>  
        /// <param name="publicRequest"></param>
        /// <returns></returns>
        public IRequest Marshall(ListIAMPolicyAssignmentsForUserRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.QuickSight");
            request.Headers[Amazon.Util.HeaderKeys.XAmzApiVersion] = "2018-04-01";            
            request.HttpMethod = "GET";

            if (!publicRequest.IsSetAwsAccountId())
                throw new AmazonQuickSightException("Request object does not have required field AwsAccountId set");
            request.AddPathResource("{AwsAccountId}", StringUtils.FromString(publicRequest.AwsAccountId));
            if (!publicRequest.IsSetNamespace())
                throw new AmazonQuickSightException("Request object does not have required field Namespace set");
            request.AddPathResource("{Namespace}", StringUtils.FromString(publicRequest.Namespace));
            if (!publicRequest.IsSetUserName())
                throw new AmazonQuickSightException("Request object does not have required field UserName set");
            request.AddPathResource("{UserName}", StringUtils.FromString(publicRequest.UserName));
            
            if (publicRequest.IsSetMaxResults())
                request.Parameters.Add("max-results", StringUtils.FromInt(publicRequest.MaxResults));
            
            if (publicRequest.IsSetNextToken())
                request.Parameters.Add("next-token", StringUtils.FromString(publicRequest.NextToken));
            request.ResourcePath = "/accounts/{AwsAccountId}/namespaces/{Namespace}/users/{UserName}/iam-policy-assignments";
            request.MarshallerVersion = 2;
            request.UseQueryString = true;

            return request;
        }
        private static ListIAMPolicyAssignmentsForUserRequestMarshaller _instance = new ListIAMPolicyAssignmentsForUserRequestMarshaller();        

        internal static ListIAMPolicyAssignmentsForUserRequestMarshaller GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// Gets the singleton.
        /// </summary>  
        public static ListIAMPolicyAssignmentsForUserRequestMarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}