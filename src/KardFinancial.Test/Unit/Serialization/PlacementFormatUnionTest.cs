using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlacementFormatUnionTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "type": "placementMainPage",
              "id": "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
              "attributes": {
                "name": "Homepage Banner",
                "organizationId": "org-123",
                "availableSlots": 5
              }
            }
            """;
        var expectedObject = new PlacementFormatUnion(
            new PlacementFormatUnion.PlacementMainPage(
                new MainPagePlacementData
                {
                    Id = "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
                    Attributes = new MainPagePlacementAttributes
                    {
                        Name = "Homepage Banner",
                        OrganizationId = "org-123",
                        AvailableSlots = 5,
                    },
                }
            )
        );
        var deserializedObject = JsonUtils.Deserialize<PlacementFormatUnion>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var inputJson = """
            {
              "type": "placementMainPage",
              "id": "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
              "attributes": {
                "name": "Homepage Banner",
                "organizationId": "org-123",
                "availableSlots": 5
              }
            }
            """;
        JsonAssert.Roundtrips<PlacementFormatUnion>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
              "type": "placementPushNotification",
              "id": "01961e5a-c83d-7a11-9b2e-e7f4a6d81b34",
              "attributes": {
                "name": "Daily Deal Alert",
                "organizationId": "org-123",
                "cadence": {
                  "frequency": "DAILY",
                  "timeOfDay": "09:00"
                }
              }
            }
            """;
        var expectedObject = new PlacementFormatUnion(
            new PlacementFormatUnion.PlacementPushNotification(
                new PushNotificationPlacementData
                {
                    Id = "01961e5a-c83d-7a11-9b2e-e7f4a6d81b34",
                    Attributes = new PushNotificationPlacementAttributes
                    {
                        Name = "Daily Deal Alert",
                        OrganizationId = "org-123",
                        Cadence = new Cadence
                        {
                            Frequency = CadenceFrequency.Daily,
                            TimeOfDay = "09:00",
                        },
                    },
                }
            )
        );
        var deserializedObject = JsonUtils.Deserialize<PlacementFormatUnion>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var inputJson = """
            {
              "type": "placementPushNotification",
              "id": "01961e5a-c83d-7a11-9b2e-e7f4a6d81b34",
              "attributes": {
                "name": "Daily Deal Alert",
                "organizationId": "org-123",
                "cadence": {
                  "frequency": "DAILY",
                  "timeOfDay": "09:00"
                }
              }
            }
            """;
        JsonAssert.Roundtrips<PlacementFormatUnion>(inputJson);
    }
}
