using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateUploadRequestObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "historicalTransactionStart",
                "attributes": {}
              }
            }
            """;
        var expectedObject = new CreateUploadRequestObject
        {
            Data = new CreateUploadRequestDataUnion(
                new CreateUploadRequestDataUnion.HistoricalTransactionStart(
                    new StartHistoricalUploadNoData { Attributes = new EmptyObject() }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<CreateUploadRequestObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "historicalTransactionStart",
                "attributes": {}
              }
            }
            """;
        JsonAssert.Roundtrips<CreateUploadRequestObject>(inputJson);
    }
}
