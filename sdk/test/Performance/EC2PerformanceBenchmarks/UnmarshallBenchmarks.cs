using Amazon.JsonProtocol.Model;
using Amazon.Runtime.Internal.Transform;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.JsonProtocol.Model;
using Amazon.JsonProtocol.Model.Internal.MarshallTransformations;


namespace Performance
{
    [MemoryDiagnoser]
    public class UnmarshallingBenchmarks
    {
        string smallJsonPayload;
        JsonUnmarshallerContext smallJsonUnmarshallerContext;
        MemoryStream smallJsonStream;


        string largeJsonPayload;
        JsonUnmarshallerContext largeJsonUnmarshallerContext;
        MemoryStream largeJsonStream;



        [GlobalSetup(Target = nameof(Unmarshall1378ByteResponse))]
        public void SetupSmallPayload()
        {
            smallJsonPayload = @"
{
  ""Blob"": ""aGVsbG8gd29ybGQ="",
  ""EmptyStruct"": {},
  ""ListOfLists"": [
    [""string""]
  ],
  ""ListOfMapsOfStrings"": [
    {
      ""foo"": ""bar""
    },
    {
      ""abc"": ""xyz""
    },
    {
      ""red"": ""blue""
    }
  ],
  ""String"": ""stringstringstringst"",
  ""Integer"": 1,
  ""Boolean"": true,
  ""Float"": 1.1,
  ""Double"": 1.1,
  ""Long"": 1,
  ""Iso8601Timestamp"": ""2024-11-22T13:57:00.000Z"",
  ""SimpleStruct"": {
    ""Value"": ""abc""
  },
  ""ListOfStrings"": [
    ""abc"",
    ""mno"",
    ""xyz""
  ],
  ""RecursiveList"": [
    {
      ""RecursiveList"": [
        {
          ""RecursiveList"": [
            {
              ""Integer"": 123
            }
          ]
        }
      ]
    }
  ],
  ""MapOfStrings"": {
    ""abc"": ""xyz"",
    ""mno"": ""hjk""
  },
  ""MapOfListsOfStrings"": {
    ""abc"": [""abc"", ""xyz""],
    ""mno"": [""xyz"", ""abc""]
  },
  ""RecursiveMap"": {
    ""key1"": {
      ""RecursiveMap"": {
        ""key2"": {
          ""RecursiveMap"": {
            ""key3"": {
              ""Boolean"": false
            }
          }
        }
      }
    }
  },
  ""RecursiveStruct"": {
    ""String"": ""nested-value"",
    ""Boolean"": true,
    ""RecursiveList"": [
      {
        ""RecursiveStruct"": {
          ""MapOfStrings"": {
            ""color"": ""red"",
            ""size"": ""large""
          }
        }
      }
    ]
  }
}

";
            smallJsonStream = new MemoryStream(Encoding.UTF8.GetBytes(smallJsonPayload));
            smallJsonUnmarshallerContext = new JsonUnmarshallerContext(smallJsonStream, false, null);
        }
        [Benchmark]
        public void Unmarshall1378ByteResponse()
        {
            KitchenSinkOperationResponseUnmarshaller.Instance.Unmarshall(smallJsonUnmarshallerContext);
            smallJsonStream.Position = 0;
        }

        [GlobalSetup(Target = nameof(Unmarshall8031BytesResponse))]
        public void SetupLargePayload()
        {
            largeJsonPayload = @"
            {
              ""Blob"": ""aGVsbG8gd29ybGQ="",
              ""EmptyStruct"": {},
              ""ListOfLists"": [
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""],
                [""string""]
              ],
              ""ListOfMapsOfStrings"": [
                  {
                    ""foo1"": ""bar""
                  },
                  {
                    ""abc1"": ""xyz""
                  },
                  {
                    ""red1"": ""blue""
                  },
                  {
                    ""foo2"": ""bar""
                  },
                  {
                    ""abc2"": ""xyz""
                  },
                  {
                    ""red2"": ""blue""
                  },
                  {
                    ""foo3"": ""bar""
                  },
                  {
                    ""abc3"": ""xyz""
                  },
                  {
                    ""red3"": ""blue""
                  }
              ],
              ""String"": ""stringstringstringststringstringstringststringstringstringststringstringstringststringstringstringststringstringstringststringstringstringststringstringstringststringstringstringststringstringstringststringstringstringst"",
              ""Integer"": 1,
              ""Boolean"": true,
              ""Float"": 1.1,
              ""Double"": 1.1,
              ""Long"": 1,
              ""Iso8601Timestamp"": ""2024-11-22T13:57:00.000Z"",
              ""SimpleStruct"": {
                ""Value"": ""abc""
              },
              ""ListOfStrings"": [
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz"",
                ""abc"",
                ""mno"",
                ""xyz""
              ],
              ""RecursiveList"": [
                {
                  ""RecursiveList"": [
                    {
                      ""RecursiveList"": [
                        {
                          ""Integer"": 123
                        }
                      ]
                    }
                  ]
                }
              ],
              ""MapOfStrings"": {
                ""abc"": ""xyz"",
                ""mno"": ""hjk""
              },
              ""MapOfListsOfStrings"": {
              ""abc1"": [""abc"", ""xyz""],
              ""mno1"": [""xyz"", ""abc""],
              ""abc2"": [""abc"", ""xyz""],
              ""mno2"": [""xyz"", ""abc""],
              ""abc3"": [""abc"", ""xyz""],
              ""mno3"": [""xyz"", ""abc""],
              ""abc4"": [""abc"", ""xyz""],
              ""mno4"": [""xyz"", ""abc""],
              ""abc5"": [""abc"", ""xyz""],
              ""mno5"": [""xyz"", ""abc""],
              ""abc6"": [""abc"", ""xyz""],
              ""mno6"": [""xyz"", ""abc""],
              ""abc7"": [""abc"", ""xyz""],
              ""mno7"": [""xyz"", ""abc""],
              ""abc8"": [""abc"", ""xyz""],
              ""mno8"": [""xyz"", ""abc""],
              ""abc9"": [""abc"", ""xyz""],
              ""mno9"": [""xyz"", ""abc""],
              ""abc10"": [""abc"", ""xyz""],
              ""mno10"": [""xyz"", ""abc""]
              },
              ""RecursiveMap"": {
                ""key1"": {
                  ""RecursiveMap"": {
                    ""key2"": {
                      ""RecursiveMap"": {
                        ""key3"": {
                          ""Boolean"": false
                        }
                      }
                    }
                  }
                }
              },
              ""RecursiveStruct"": {
                ""String"": ""nested-value"",
                ""Boolean"": true,
                ""RecursiveList"": [
                  {
                    ""RecursiveStruct"": {
                      ""MapOfStrings"": {
                        ""color"": ""red"",
                        ""size"": ""large""
                      }
                    }
                  }
                ]
              }
            }
            ";
            largeJsonStream = new MemoryStream(Encoding.UTF8.GetBytes(largeJsonPayload));
            largeJsonUnmarshallerContext = new JsonUnmarshallerContext(largeJsonStream, false, null);
        }

        [Benchmark]
        public void Unmarshall8031BytesResponse()
        {
            KitchenSinkOperationResponseUnmarshaller.Instance.Unmarshall(largeJsonUnmarshallerContext);
            largeJsonStream.Position = 0;
        }
    }
}
