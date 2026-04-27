using KardApi;
using KardApi.Core;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class FraudulentTransactionObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "fraudulentTransaction",
                  "id": "myTxnId123",
                  "attributes": {
                    "userId": "user123"
                  }
                }
              ]
            }
            """;
        var expectedObject = new FraudulentTransactionObject
        {
            Data = new List<FraudulentTransactionData>()
            {
                new FraudulentTransactionData
                {
                    Type = "fraudulentTransaction",
                    Id = "myTxnId123",
                    Attributes = new FraudulentTransactionAttributes { UserId = "user123" },
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<FraudulentTransactionObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": [
                {
                  "type": "fraudulentTransaction",
                  "id": "myTxnId123",
                  "attributes": {
                    "userId": "user123"
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<FraudulentTransactionObject>(inputJson);
    }
}
