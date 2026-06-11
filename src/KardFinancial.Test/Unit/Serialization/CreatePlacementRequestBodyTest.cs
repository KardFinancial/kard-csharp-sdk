using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

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
                "type": "placement",
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
                new CreatePlacementDataUnion.Placement(
                    new CreateStandardPlacementData
                    {
                        Attributes = new CreateStandardAttributes
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
                "type": "placement",
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

    [NUnit.Framework.Test]
    public void TestDeserialization_3()
    {
        var json = """
            {
              "data": {
                "type": "placementEmail",
                "attributes": {
                  "name": "Weekly Deals Email",
                  "availableSlots": 10,
                  "cadence": {
                    "frequency": "WEEKLY",
                    "timeOfDay": "10:00",
                    "dayOfWeek": "MON"
                  }
                }
              }
            }
            """;
        var expectedObject = new CreatePlacementRequestBody
        {
            Data = new CreatePlacementDataUnion(
                new CreatePlacementDataUnion.PlacementEmail(
                    new CreateEmailPlacementData
                    {
                        Attributes = new CreateEmailAttributes
                        {
                            Name = "Weekly Deals Email",
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
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<CreatePlacementRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_3()
    {
        var inputJson = """
            {
              "data": {
                "type": "placementEmail",
                "attributes": {
                  "name": "Weekly Deals Email",
                  "availableSlots": 10,
                  "cadence": {
                    "frequency": "WEEKLY",
                    "timeOfDay": "10:00",
                    "dayOfWeek": "MON"
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<CreatePlacementRequestBody>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_4()
    {
        var json = """
            {
              "data": {
                "type": "placementBatchActivation",
                "attributes": {
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
              }
            }
            """;
        var expectedObject = new CreatePlacementRequestBody
        {
            Data = new CreatePlacementDataUnion(
                new CreatePlacementDataUnion.PlacementBatchActivation(
                    new CreateBatchActivationPlacementData
                    {
                        Attributes = new CreateBatchActivationAttributes
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
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<CreatePlacementRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_4()
    {
        var inputJson = """
            {
              "data": {
                "type": "placementBatchActivation",
                "attributes": {
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
              }
            }
            """;
        JsonAssert.Roundtrips<CreatePlacementRequestBody>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_5()
    {
        var json = """
            {
              "data": {
                "type": "placementGroup",
                "attributes": {
                  "name": "Seasonal Collection",
                  "slots": [
                    {
                      "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                      "alias": "primary",
                      "shortDescription": "Seasonal picks"
                    }
                  ]
                }
              }
            }
            """;
        var expectedObject = new CreatePlacementRequestBody
        {
            Data = new CreatePlacementDataUnion(
                new CreatePlacementDataUnion.PlacementGroup(
                    new CreateGroupPlacementData
                    {
                        Attributes = new CreateGroupAttributes
                        {
                            Name = "Seasonal Collection",
                            Slots = new List<CreateBatchActivationSlot>()
                            {
                                new CreateBatchActivationSlot
                                {
                                    PlacementId = "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                                    Alias = "primary",
                                    ShortDescription = "Seasonal picks",
                                },
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
    public void TestSerialization_5()
    {
        var inputJson = """
            {
              "data": {
                "type": "placementGroup",
                "attributes": {
                  "name": "Seasonal Collection",
                  "slots": [
                    {
                      "placementId": "01961e5a-f26f-7e44-ce5f-1ad7c9fb4e67",
                      "alias": "primary",
                      "shortDescription": "Seasonal picks"
                    }
                  ]
                }
              }
            }
            """;
        JsonAssert.Roundtrips<CreatePlacementRequestBody>(inputJson);
    }
}
