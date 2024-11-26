using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using Amazon;
using Amazon.Runtime.Internal.Transform;
using System;
using System.Text;
using Amazon.Runtime.Internal.Transform;
using Amazon.Util;
using System.Text.Json;
using Amazon.JsonProtocol.Model.Internal.MarshallTransformations;
using Amazon.JsonProtocol.Model;
namespace Performance
{
    [MemoryDiagnoser]
    public class MarshallingBenchmarks
    {
        #region testString
        static string testResponseString = @"
{
  ""Messages"": [
    {
      ""Body"": ""test message 1"",
      ""MD5OfBody"": ""4b1c2ba4e668c5b16b76124b2715fb84"",
      ""MessageId"": ""dde4d5c4-6520-42c8-bb3b-bcdba752ae4c"",
      ""ReceiptHandle"": ""AQEBc6794b""
    },
    {
      ""Body"": ""test message 2"",
      ""MD5OfBody"": ""639ce91e3642398aca7f1cb47d1e9ed1"",
      ""MessageId"": ""a32f4e1a-9bc6-43fb-ac72-0944beaab514"",
      ""ReceiptHandle"": ""AQEBbbde1e""
    },
    {
      ""Body"": ""test message 3"",
      ""MD5OfBody"": ""6ab756a597bb7fd5e62a310fe107f572"",
      ""MessageId"": ""e7f46187-10b8-4d04-aab3-476a3840163a"",
      ""ReceiptHandle"": ""AQEBc55997""
    },
    {
      ""Body"": ""test message 4"",
      ""MD5OfBody"": ""8fd321e1ab0d53b662fcb32408091b5e"",
      ""MessageId"": ""cd302c3f-79a5-4e43-ba4b-d4dd2cdd6d62"",
      ""ReceiptHandle"": ""AQEBad7b25""
    },
    {
      ""Body"": ""test message 5"",
      ""MD5OfBody"": ""60d4d18980a19b8778ac2c24a0567241"",
      ""MessageId"": ""c853738e-2984-459b-b456-43d9fd9d0163"",
      ""ReceiptHandle"": ""AQEB95976a""
    },
    {
      ""Body"": ""test message 6"",
      ""MD5OfBody"": ""16cbaf8a892792c2c71b3772a20be8eb"",
      ""MessageId"": ""c3366ce8-fe55-422d-9166-4c1fce72a47e"",
      ""ReceiptHandle"": ""AQEBacb4f7""
    },
    {
      ""Body"": ""test message 7"",
      ""MD5OfBody"": ""c87359805fda584a9fee944541a7344b"",
      ""MessageId"": ""744bf836-30df-4b98-98b8-15903ee1c850"",
      ""ReceiptHandle"": ""AQEB2974a7""
    },
    {
      ""Body"": ""test message 8"",
      ""MD5OfBody"": ""1c1e3d9846492ba6b67ca47bc455bcd4"",
      ""MessageId"": ""c857e603-82ec-4755-bab8-5015bb34e11d"",
      ""ReceiptHandle"": ""AQEB90f2ba""
    },
    {
      ""Body"": ""test message 9"",
      ""MD5OfBody"": ""fa3df1fb12f3981fdfaa9fa0058dcc9e"",
      ""MessageId"": ""165b12fe-b24d-4f98-ad96-302270241cf5"",
      ""ReceiptHandle"": ""AQEBa6ebad""
    },
    {
      ""Body"": ""test message 10"",
      ""MD5OfBody"": ""a2c4086739c2c97e1a4e4ecc4a4793fb"",
      ""MessageId"": ""87d13fdb-23b9-4cc2-9005-11deef6b37c2"",
      ""ReceiptHandle"": ""AQEBb3fd25""
    }
  ]
}
";
        #endregion
        //private ReceiveMessageResponseUnmarshaller unmarshaller;
        //private JsonUnmarshallerContext context;
        //private MemoryStream stream;
        //private byte[] testResponseBytes;
        //[GlobalSetup]
        //public void Setup()
        //{
        //    AWSConfigs.LoggingConfig.LogResponsesSizeLimit = 1024 * 1024 * 100;
        //    testResponseBytes = Encoding.UTF8.GetBytes(testResponseString);
        //    unmarshaller = new ReceiveMessageResponseUnmarshaller();
        //    stream = new MemoryStream(testResponseBytes);
        //    context = new JsonUnmarshallerContext(stream, true, null);
        //}

        //[Benchmark]
        //public void UnmarshallJsonResponse()
        //{
        //    //var unmarshaller = new ReceiveMessageResponseUnmarshaller();
        //    //var stream = new MemoryStream(testResponseBytes);
        //    //var context = new JsonUnmarshallerContext(stream, true, null);
        //    unmarshaller.Unmarshall(context);
        //    stream.Position = 0;
        //}
        KitchenSinkOperationRequestMarshaller marshaller;
        KitchenSinkOperationRequest request;

        [GlobalSetup(Target = nameof(Marshall1KBRequest))]
        public void Setup()
        {
            marshaller = new KitchenSinkOperationRequestMarshaller();
            request = new KitchenSinkOperationRequest
            {
                Blob = new MemoryStream(Encoding.UTF8.GetBytes("hello world")),
                EmptyStruct = new EmptyStruct(),
                JsonValue = "{\"string\":\"value\",\"number\":1234.5,\"boolTrue\":true,\"boolFalse\":false,\"array\":[1,2,3,4],\"object\":{\"key\":\"value\"},\"null\":null}",
                ListOfLists = new List<List<string>> { new List<string> { "string" } },
                ListOfMapsOfStrings = new List<Dictionary<string, string>>()
                {
                    new Dictionary<string, string>()
                    {

                        { "foo", "bar" },
                    },
                    new Dictionary<string, string>()
                    {

                        { "abc", "xyz" },
                    },
                    new Dictionary<string, string>()
                    {

                        { "red", "blue" },
                    },
                },
                String = "stringstringstringst",
                Integer = 1,
                Boolean = true,
                Float = 1.1f,
                Double = 1.1,
                Long = 1,
                Iso8601Timestamp = DateTime.Now,
                SimpleStruct = new SimpleStruct
                {
                    Value = "abc",
                },
                ListOfStrings = new List<string>()
                {
                    "abc",
                    "mno",
                    "xyz",
                },
                RecursiveList = new List<KitchenSink>()
                {
                    new KitchenSink
                    {
                        RecursiveList =  new List<KitchenSink>()
                        {
                            new KitchenSink
                            {
                                RecursiveList =  new List<KitchenSink>()
                                {
                                    new KitchenSink
                                    {
                                        Integer = 123,
                                    },
                                },
                            },
                        },
                    },
                },
                MapOfStrings = new Dictionary<string, string>()
                {

                    { "abc", "xyz" },
                    { "mno", "hjk" },
                },
                MapOfListsOfStrings = new Dictionary<string, List<string>>()
                {

                    { "abc",  new List<string>()
                    {
                        "abc",
                        "xyz",
                    } },
                    { "mno",  new List<string>()
                    {
                        "xyz",
                        "abc",
                    } },
                },
                RecursiveMap = new Dictionary<string, KitchenSink>()
                {

                    { "key1", new KitchenSink
                    {
                        RecursiveMap = new Dictionary<string, KitchenSink>()
                        {

                            { "key2", new KitchenSink
                            {
                                RecursiveMap = new Dictionary<string, KitchenSink>()
                                {

                                    { "key3", new KitchenSink
                                    {
                                        Boolean = false,
                                    } },
                                },
                            } },
                        },
                    } },
                },
                RecursiveStruct = new KitchenSink
                {
                    String = "nested-value",
                    Boolean = true,
                    RecursiveList = new List<KitchenSink>()
                    {
                        new KitchenSink
                        {
                            RecursiveStruct = new KitchenSink
                            {
                                MapOfStrings = new Dictionary<string, string>()
                                {

                                    { "color", "red" },
                                    { "size", "large" },
                                },
                            },
                        },
                    },
                }
            };
        }

        [Benchmark]
        public void Marshall1KBRequest()
        {
            marshaller.Marshall(request);
        }
    }
}
