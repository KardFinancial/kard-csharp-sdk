using KardApi.Core;
using KardApi.Organizations;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePlacementRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "data": {
                "type": "placementMainPage",
                "attributes": {
                  "name": "Homepage Banner",
                  "availableSlots": 5
                }
              }
            }
            """;
        var expectedObject = new CreatePlacementRequestBody
        {
            Data = new CreatePlacementDataUnion(
                new CreatePlacementDataUnion.PlacementMainPage(
                    new CreateMainPagePlacementData
                    {
                        Attributes = new CreateMainPageAttributes
                        {
                            Name = "Homepage Banner",
                            AvailableSlots = 5,
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<CreatePlacementRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var inputJson = """
            {
              "data": {
                "type": "placementMainPage",
                "attributes": {
                  "name": "Homepage Banner",
                  "availableSlots": 5
                }
              }
            }
            """;
        JsonAssert.Roundtrips<CreatePlacementRequestBody>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
              "data": {
                "type": "placementPushNotification",
                "attributes": {
                  "name": "Daily Deal Alert",
                  "cadence": {
                    "frequency": "DAILY",
                    "timeOfDay": "09:00"
                  }
                }
              }
            }
            """;
        var expectedObject = new CreatePlacementRequestBody
        {
            Data = new CreatePlacementDataUnion(
                new CreatePlacementDataUnion.PlacementPushNotification(
                    new CreatePushNotificationPlacementData
                    {
                        Attributes = new CreatePushNotificationAttributes
                        {
                            Name = "Daily Deal Alert",
                            Cadence = new Cadence
                            {
                                Frequency = CadenceFrequency.Daily,
                                TimeOfDay = "09:00",
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<CreatePlacementRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var inputJson = """
            {
              "data": {
                "type": "placementPushNotification",
                "attributes": {
                  "name": "Daily Deal Alert",
                  "cadence": {
                    "frequency": "DAILY",
                    "timeOfDay": "09:00"
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<CreatePlacementRequestBody>(inputJson);
    }
}
