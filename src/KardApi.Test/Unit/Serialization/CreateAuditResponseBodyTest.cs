using KardApi;
using KardApi.Core;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateAuditResponseBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "audit",
                  "id": "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                  "attributes": {
                    "transactionId": "issuerTransaction123"
                  }
                }
              ]
            }
            """;
        var expectedObject = new CreateAuditResponseBody
        {
            Data = new List<CreateAuditResponseDataUnion>()
            {
                new CreateAuditResponseDataUnion(
                    new CreateAuditResponseDataUnion.Audit(
                        new AuditResponseData
                        {
                            Id = "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                            Attributes = new AuditResponseAttributes
                            {
                                TransactionId = "issuerTransaction123",
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateAuditResponseBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": [
                {
                  "type": "audit",
                  "id": "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                  "attributes": {
                    "transactionId": "issuerTransaction123"
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateAuditResponseBody>(inputJson);
    }
}
