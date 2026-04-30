using Kard;
using Kard.Core;
using Kard.Test.Utils;
using Kard.Users;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateUploadRequestObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "type": "historicalTransactionComplete",
                "attributes": {}
              }
            }
            """;
        var expectedObject = new UpdateUploadRequestObject
        {
            Data = new UpdateUploadRequestDataUnion(
                new UpdateUploadRequestDataUnion.HistoricalTransactionComplete(
                    new HistoricalTransactionCompleteNoData
                    {
                        Id = "7e382223-b9a5-4825-91fb-436c8957a2e7",
                        Attributes = new EmptyObject(),
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateUploadRequestObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "type": "historicalTransactionComplete",
                "attributes": {}
              }
            }
            """;
        JsonAssert.Roundtrips<UpdateUploadRequestObject>(inputJson);
    }
}
