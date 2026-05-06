using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateUploadResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "historicalTransactionComplete",
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "attributes": {}
              }
            }
            """;
        var expectedObject = new UpdateUploadResponseObject
        {
            Data = new UpdateUploadResponseDataUnion(
                new UpdateUploadResponseDataUnion.HistoricalTransactionComplete(
                    new UpdateUploadResponseData
                    {
                        Id = "7e382223-b9a5-4825-91fb-436c8957a2e7",
                        Attributes = new EmptyObject(),
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateUploadResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "historicalTransactionComplete",
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "attributes": {}
              }
            }
            """;
        JsonAssert.Roundtrips<UpdateUploadResponseObject>(inputJson);
    }
}
