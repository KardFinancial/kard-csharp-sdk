using Kard;
using Kard.Core;
using Kard.Test.Utils;
using Kard.Users;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateUploadPartResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "historicalTransaction",
                  "id": "txnId123",
                  "attributes": {}
                }
              ]
            }
            """;
        var expectedObject = new CreateUploadPartResponseObject
        {
            Data = new List<CreateUploadPartResponseDataUnion>()
            {
                new CreateUploadPartResponseDataUnion(
                    new CreateUploadPartResponseDataUnion.HistoricalTransaction(
                        new CreateUploadPartResponseData
                        {
                            Id = "txnId123",
                            Attributes = new EmptyObject(),
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateUploadPartResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": [
                {
                  "type": "historicalTransaction",
                  "id": "txnId123",
                  "attributes": {}
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateUploadPartResponseObject>(inputJson);
    }
}
