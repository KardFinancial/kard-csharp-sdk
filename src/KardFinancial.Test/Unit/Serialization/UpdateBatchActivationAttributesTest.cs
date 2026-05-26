using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateBatchActivationAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Updated Cohort",
              "refreshInterval": "P14D",
              "slots": [
                {
                  "slotId": "01961e5a-e15f-7d33-bd4f-09c6b8fa3d56",
                  "contentStrategyId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary"
                }
              ]
            }
            """;
        var expectedObject = new UpdateBatchActivationAttributes
        {
            Name = "Updated Cohort",
            RefreshInterval = "P14D",
            Slots = new List<UpdateBatchActivationSlot>()
            {
                new UpdateBatchActivationSlot
                {
                    SlotId = "01961e5a-e15f-7d33-bd4f-09c6b8fa3d56",
                    ContentStrategyId = "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                    Alias = "primary",
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateBatchActivationAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Updated Cohort",
              "refreshInterval": "P14D",
              "slots": [
                {
                  "slotId": "01961e5a-e15f-7d33-bd4f-09c6b8fa3d56",
                  "contentStrategyId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary"
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<UpdateBatchActivationAttributes>(inputJson);
    }
}
