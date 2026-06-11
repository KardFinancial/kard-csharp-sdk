using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateGroupAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Seasonal Collection",
              "slots": [
                {
                  "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary",
                  "shortDescription": "Seasonal picks"
                }
              ]
            }
            """;
        var expectedObject = new CreateGroupAttributes
        {
            Name = "Seasonal Collection",
            Slots = new List<CreateBatchActivationSlot>()
            {
                new CreateBatchActivationSlot
                {
                    PlacementId = "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                    Alias = "primary",
                    ShortDescription = "Seasonal picks",
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateGroupAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Seasonal Collection",
              "slots": [
                {
                  "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary",
                  "shortDescription": "Seasonal picks"
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateGroupAttributes>(inputJson);
    }
}
