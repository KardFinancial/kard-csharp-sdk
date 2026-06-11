using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateEmailAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Weekly Deals Email",
              "availableSlots": 10,
              "cadence": {
                "frequency": "WEEKLY",
                "timeOfDay": "10:00",
                "dayOfWeek": "MON"
              }
            }
            """;
        var expectedObject = new CreateEmailAttributes
        {
            Name = "Weekly Deals Email",
            AvailableSlots = 10,
            Cadence = new Cadence
            {
                Frequency = CadenceFrequency.Weekly,
                TimeOfDay = "10:00",
                DayOfWeek = KardFinancial.Organizations.DayOfWeek.Mon,
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateEmailAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Weekly Deals Email",
              "availableSlots": 10,
              "cadence": {
                "frequency": "WEEKLY",
                "timeOfDay": "10:00",
                "dayOfWeek": "MON"
              }
            }
            """;
        JsonAssert.Roundtrips<CreateEmailAttributes>(inputJson);
    }
}
