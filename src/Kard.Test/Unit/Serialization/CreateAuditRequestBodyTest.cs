using Kard;
using Kard.Core;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateAuditRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "audit",
                  "attributes": {
                    "auditCode": 8001,
                    "merchantName": "Caribbean Goodness",
                    "auditDescription": "duplicate transaction",
                    "transactionId": "issuerTransaction123"
                  }
                }
              ]
            }
            """;
        var expectedObject = new CreateAuditRequestBody
        {
            Data = new List<CreateAuditRequestDataUnion>()
            {
                new CreateAuditRequestDataUnion(
                    new CreateAuditRequestDataUnion.Audit(
                        new AuditRequestData
                        {
                            Attributes = new AuditAttributes
                            {
                                AuditCode = 8001,
                                MerchantName = "Caribbean Goodness",
                                AuditDescription = "duplicate transaction",
                                TransactionId = "issuerTransaction123",
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateAuditRequestBody>(json);
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
                  "attributes": {
                    "auditCode": 8001,
                    "merchantName": "Caribbean Goodness",
                    "auditDescription": "duplicate transaction",
                    "transactionId": "issuerTransaction123"
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateAuditRequestBody>(inputJson);
    }
}
