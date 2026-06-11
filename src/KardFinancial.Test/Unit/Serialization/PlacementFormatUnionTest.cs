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
              "type": "placement",
              "id": "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
              "attributes": {
                "name": "Homepage Banner",
                "organizationId": "org-123",
                "availableSlots": 5
              }
            }
            """;
        var expectedObject = new PlacementFormatUnion(
            new PlacementFormatUnion.Placement(
                new PlacementData
                {
                    Id = "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
                    Attributes = new PlacementAttributes
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
              "type": "placement",
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
              "type": "placementEmail",
              "id": "01961e5a-f37a-7b55-9d6a-2be8d1ac5f78",
              "attributes": {
                "name": "Weekly Deals Email",
                "organizationId": "org-123",
                "availableSlots": 10,
                "cadence": {
                  "frequency": "WEEKLY",
                  "timeOfDay": "10:00",
                  "dayOfWeek": "MON"
                }
              }
            }
            """;
        var expectedObject = new PlacementFormatUnion(
            new PlacementFormatUnion.PlacementEmail(
                new EmailPlacementData
                {
                    Id = "01961e5a-f37a-7b55-9d6a-2be8d1ac5f78",
                    Attributes = new EmailPlacementAttributes
                    {
                        Name = "Weekly Deals Email",
                        OrganizationId = "org-123",
                        AvailableSlots = 10,
                        Cadence = new Cadence
                        {
                            Frequency = CadenceFrequency.Weekly,
                            TimeOfDay = "10:00",
                            DayOfWeek = KardFinancial.Organizations.DayOfWeek.Mon,
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
              "type": "placementEmail",
              "id": "01961e5a-f37a-7b55-9d6a-2be8d1ac5f78",
              "attributes": {
                "name": "Weekly Deals Email",
                "organizationId": "org-123",
                "availableSlots": 10,
                "cadence": {
                  "frequency": "WEEKLY",
                  "timeOfDay": "10:00",
                  "dayOfWeek": "MON"
                }
              }
            }
            """;
        JsonAssert.Roundtrips<PlacementFormatUnion>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_4()
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
                    Relationships = new SlottedPlacementRelationships
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
    public void TestSerialization_4()
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

    [NUnit.Framework.Test]
    public void TestDeserialization_5()
    {
        var json = """
            {
              "type": "placementGroup",
              "id": "01961e5a-a48b-7e66-8c7b-3cf9e2bd6a89",
              "attributes": {
                "name": "Seasonal Collection",
                "organizationId": "org-123"
              },
              "relationships": {
                "slots": {
                  "data": [
                    {
                      "type": "batchActivationSlot",
                      "id": "01961e5a-b59c-7f77-9d8c-4d0af3ce7b9a"
                    }
                  ]
                }
              }
            }
            """;
        var expectedObject = new PlacementFormatUnion(
            new PlacementFormatUnion.PlacementGroup(
                new GroupPlacementData
                {
                    Id = "01961e5a-a48b-7e66-8c7b-3cf9e2bd6a89",
                    Attributes = new GroupPlacementAttributes
                    {
                        Name = "Seasonal Collection",
                        OrganizationId = "org-123",
                    },
                    Relationships = new SlottedPlacementRelationships
                    {
                        Slots = new ToManyRelationship
                        {
                            Data = new List<ResourceIdentifier>()
                            {
                                new ResourceIdentifier
                                {
                                    Type = "batchActivationSlot",
                                    Id = "01961e5a-b59c-7f77-9d8c-4d0af3ce7b9a",
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
    public void TestSerialization_5()
    {
        var inputJson = """
            {
              "type": "placementGroup",
              "id": "01961e5a-a48b-7e66-8c7b-3cf9e2bd6a89",
              "attributes": {
                "name": "Seasonal Collection",
                "organizationId": "org-123"
              },
              "relationships": {
                "slots": {
                  "data": [
                    {
                      "type": "batchActivationSlot",
                      "id": "01961e5a-b59c-7f77-9d8c-4d0af3ce7b9a"
                    }
                  ]
                }
              }
            }
            """;
        JsonAssert.Roundtrips<PlacementFormatUnion>(inputJson);
    }
}
