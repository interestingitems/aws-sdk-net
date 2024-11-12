using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Transform
{
    public interface IJsonErrorResponseUnmarshaller<T, TJsonUnmarshallerContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">The jsonunmarshaller context</param>
        /// <param name="errorResponse">The error response</param>
        /// <param name="reader">The json reader</param>
        /// <returns>T, the error shape that is unmarshalled from the json context</returns>
        T Unmarshall(TJsonUnmarshallerContext context, ErrorResponse errorResponse, ref Utf8JsonReader reader);
    }
}
