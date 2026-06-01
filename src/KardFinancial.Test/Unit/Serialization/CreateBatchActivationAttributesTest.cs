using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBatchActivationAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Weekly Cohort",
              "refreshInterval": "P7D",
              "slots": [
                {
                  "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary",
                  "shortDescription": "Featured deals refreshed each week"
                }
              ]
            }
            """;
        var expectedObject = new CreateBatchActivationAttributes
        {
            Name = "Weekly Cohort",
            RefreshInterval = "P7D",
            Slots = new List<CreateBatchActivationSlot>()
            {
                new CreateBatchActivationSlot
                {
                    PlacementId = "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                    Alias = "primary",
                    ShortDescription = "Featured deals refreshed each week",
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateBatchActivationAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Weekly Cohort",
              "refreshInterval": "P7D",
              "slots": [
                {
                  "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                  "alias": "primary",
                  "shortDescription": "Featured deals refreshed each week"
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateBatchActivationAttributes>(inputJson);
    }
}
