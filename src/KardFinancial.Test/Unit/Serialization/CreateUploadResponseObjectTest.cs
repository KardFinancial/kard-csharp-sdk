using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateUploadResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "historicalTransactionStart",
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "attributes": {}
              }
            }
            """;
        var expectedObject = new CreateUploadResponseObject
        {
            Data = new CreateUploadResponseDataUnion(
                new CreateUploadResponseDataUnion.HistoricalTransactionStart(
                    new CreateUploadResponseData
                    {
                        Id = "7e382223-b9a5-4825-91fb-436c8957a2e7",
                        Attributes = new EmptyObject(),
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<CreateUploadResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "historicalTransactionStart",
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "attributes": {}
              }
            }
            """;
        JsonAssert.Roundtrips<CreateUploadResponseObject>(inputJson);
    }
}
