using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateEmailAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Updated Email",
              "availableSlots": 8,
              "cadence": {
                "frequency": "MONTHLY",
                "timeOfDay": "08:00",
                "dayOfMonth": 1
              }
            }
            """;
        var expectedObject = new UpdateEmailAttributes
        {
            Name = "Updated Email",
            AvailableSlots = 8,
            Cadence = new Cadence
            {
                Frequency = CadenceFrequency.Monthly,
                TimeOfDay = "08:00",
                DayOfMonth = 1,
            },
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateEmailAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Updated Email",
              "availableSlots": 8,
              "cadence": {
                "frequency": "MONTHLY",
                "timeOfDay": "08:00",
                "dayOfMonth": 1
              }
            }
            """;
        JsonAssert.Roundtrips<UpdateEmailAttributes>(inputJson);
    }
}
