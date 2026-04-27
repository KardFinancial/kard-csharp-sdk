using KardApi.Core;
using KardApi.Organizations;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePushNotificationAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Updated Alert",
              "cadence": {
                "frequency": "WEEKLY",
                "timeOfDay": "14:00",
                "dayOfWeek": "FRI"
              }
            }
            """;
        var expectedObject = new UpdatePushNotificationAttributes
        {
            Name = "Updated Alert",
            Cadence = new Cadence
            {
                Frequency = CadenceFrequency.Weekly,
                TimeOfDay = "14:00",
                DayOfWeek = KardApi.Organizations.DayOfWeek.Fri,
            },
        };
        var deserializedObject = JsonUtils.Deserialize<UpdatePushNotificationAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Updated Alert",
              "cadence": {
                "frequency": "WEEKLY",
                "timeOfDay": "14:00",
                "dayOfWeek": "FRI"
              }
            }
            """;
        JsonAssert.Roundtrips<UpdatePushNotificationAttributes>(inputJson);
    }
}
