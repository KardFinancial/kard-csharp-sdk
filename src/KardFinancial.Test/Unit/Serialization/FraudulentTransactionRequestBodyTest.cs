using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class FraudulentTransactionRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "id": "myTxnId12345",
                  "type": "fraudulentTransaction",
                  "attributes": {
                    "userId": "userId123"
                  }
                }
              ]
            }
            """;
        var expectedObject = new FraudulentTransactionRequestBody
        {
            Data = new List<FraudulentTransactionData>()
            {
                new FraudulentTransactionData
                {
                    Id = "myTxnId12345",
                    Type = "fraudulentTransaction",
                    Attributes = new FraudulentTransactionAttributes { UserId = "userId123" },
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<FraudulentTransactionRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": [
                {
                  "id": "myTxnId12345",
                  "type": "fraudulentTransaction",
                  "attributes": {
                    "userId": "userId123"
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<FraudulentTransactionRequestBody>(inputJson);
    }
}
