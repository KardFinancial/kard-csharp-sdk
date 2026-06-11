using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateGroupAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Updated Collection",
              "slots": [
                {
                  "slotId": "01961e5a-b59c-7f77-9d8c-4d0af3ce7b9a",
                  "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary",
                  "shortDescription": "Seasonal picks"
                }
              ]
            }
            """;
        var expectedObject = new UpdateGroupAttributes
        {
            Name = "Updated Collection",
            Slots = new List<UpdateBatchActivationSlot>()
            {
                new UpdateBatchActivationSlot
                {
                    SlotId = "01961e5a-b59c-7f77-9d8c-4d0af3ce7b9a",
                    PlacementId = "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                    Alias = "primary",
                    ShortDescription = "Seasonal picks",
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateGroupAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Updated Collection",
              "slots": [
                {
                  "slotId": "01961e5a-b59c-7f77-9d8c-4d0af3ce7b9a",
                  "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary",
                  "shortDescription": "Seasonal picks"
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<UpdateGroupAttributes>(inputJson);
    }
}
