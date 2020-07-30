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
 * Do not modify this file. This file is generated from the sesv2-2019-09-27.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

using Amazon.SimpleEmailV2.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.SimpleEmailV2.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Response Unmarshaller for GetAccount operation
    /// </summary>  
    public class GetAccountResponseUnmarshaller : JsonResponseUnmarshaller
    {
        /// <summary>
        /// Unmarshaller the response from the service to the response class.
        /// </summary>  
        /// <param name="context"></param>
        /// <returns></returns>
        public override AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext context)
        {
            GetAccountResponse response = new GetAccountResponse();

            context.Read();
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
                if (context.TestExpression("DedicatedIpAutoWarmupEnabled", targetDepth))
                {
                    var unmarshaller = BoolUnmarshaller.Instance;
                    response.DedicatedIpAutoWarmupEnabled = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("Details", targetDepth))
                {
                    var unmarshaller = AccountDetailsUnmarshaller.Instance;
                    response.Details = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("EnforcementStatus", targetDepth))
                {
                    var unmarshaller = StringUnmarshaller.Instance;
                    response.EnforcementStatus = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("ProductionAccessEnabled", targetDepth))
                {
                    var unmarshaller = BoolUnmarshaller.Instance;
                    response.ProductionAccessEnabled = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("SendingEnabled", targetDepth))
                {
                    var unmarshaller = BoolUnmarshaller.Instance;
                    response.SendingEnabled = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("SendQuota", targetDepth))
                {
                    var unmarshaller = SendQuotaUnmarshaller.Instance;
                    response.SendQuota = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("SuppressionAttributes", targetDepth))
                {
                    var unmarshaller = SuppressionAttributesUnmarshaller.Instance;
                    response.SuppressionAttributes = unmarshaller.Unmarshall(context);
                    continue;
                }
            }

            return response;
        }

        /// <summary>
        /// Unmarshaller error response to exception.
        /// </summary>  
        /// <param name="context"></param>
        /// <param name="innerException"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public override AmazonServiceException UnmarshallException(JsonUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            var errorResponse = JsonErrorResponseUnmarshaller.GetInstance().Unmarshall(context);
            errorResponse.InnerException = innerException;
            errorResponse.StatusCode = statusCode;

            var responseBodyBytes = context.GetResponseBodyBytes();

            using (var streamCopy = new MemoryStream(responseBodyBytes))
            using (var contextCopy = new JsonUnmarshallerContext(streamCopy, false, null))
            {
                if (errorResponse.Code != null && errorResponse.Code.Equals("BadRequestException"))
                {
                    return BadRequestExceptionUnmarshaller.Instance.Unmarshall(contextCopy, errorResponse);
                }
                if (errorResponse.Code != null && errorResponse.Code.Equals("TooManyRequestsException"))
                {
                    return TooManyRequestsExceptionUnmarshaller.Instance.Unmarshall(contextCopy, errorResponse);
                }
            }
            return new AmazonSimpleEmailServiceV2Exception(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode);
        }

        private static GetAccountResponseUnmarshaller _instance = new GetAccountResponseUnmarshaller();        

        internal static GetAccountResponseUnmarshaller GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// Gets the singleton.
        /// </summary>  
        public static GetAccountResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}