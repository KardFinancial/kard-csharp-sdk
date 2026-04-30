using KardApi.Core;
using KardApi.Organizations;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePushNotificationAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Push Alert",
              "cadence": {
                "frequency": "DAILY",
                "timeOfDay": "09:00"
              }
            }
            """;
        var expectedObject = new CreatePushNotificationAttributes
        {
            Name = "Push Alert",
            Cadence = new Cadence { Frequency = CadenceFrequency.Daily, TimeOfDay = "09:00" },
        };
        var deserializedObject = JsonUtils.Deserialize<CreatePushNotificationAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Push Alert",
              "cadence": {
                "frequency": "DAILY",
                "timeOfDay": "09:00"
              }
            }
            """;
        JsonAssert.Roundtrips<CreatePushNotificationAttributes>(inputJson);
    }
}
