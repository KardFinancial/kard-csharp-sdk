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

    [NUnit.Framework.Test]
    public void TestDeserialization_3()
    {
        var json = """
            {
              "type": "placementBatchActivation",
              "id": "01961e5a-d94e-7c22-ac3f-f8b5a7e92c45",
              "attributes": {
                "name": "Weekly Cohort",
                "organizationId": "org-123",
                "refreshInterval": "P7D"
              },
              "relationships": {
                "slots": {
                  "data": [
                    {
                      "type": "batchActivationSlot",
                      "id": "01961e5a-e15f-7d33-bd4f-09c6b8fa3d56"
                    }
                  ]
                }
              }
            }
            """;
        var expectedObject = new PlacementFormatUnion(
            new PlacementFormatUnion.PlacementBatchActivation(
                new BatchActivationPlacementData
                {
                    Id = "01961e5a-d94e-7c22-ac3f-f8b5a7e92c45",
                    Attributes = new BatchActivationPlacementAttributes
                    {
                        Name = "Weekly Cohort",
                        OrganizationId = "org-123",
                        RefreshInterval = "P7D",
                    },
                    Relationships = new BatchActivationPlacementRelationships
                    {
                        Slots = new ToManyRelationship
                        {
                            Data = new List<ResourceIdentifier>()
                            {
                                new ResourceIdentifier
                                {
                                    Type = "batchActivationSlot",
                                    Id = "01961e5a-e15f-7d33-bd4f-09c6b8fa3d56",
                                },
                            },
                        },
                    },
                }
            )
        );
        var deserializedObject = JsonUtils.Deserialize<PlacementFormatUnion>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_3()
    {
        var inputJson = """
            {
              "type": "placementBatchActivation",
              "id": "01961e5a-d94e-7c22-ac3f-f8b5a7e92c45",
              "attributes": {
                "name": "Weekly Cohort",
                "organizationId": "org-123",
                "refreshInterval": "P7D"
              },
              "relationships": {
                "slots": {
                  "data": [
                    {
                      "type": "batchActivationSlot",
                      "id": "01961e5a-e15f-7d33-bd4f-09c6b8fa3d56"
                    }
                  ]
                }
              }
            }
            """;
        JsonAssert.Roundtrips<PlacementFormatUnion>(inputJson);
    }
}
