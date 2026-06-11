using KardFinancial.Organizations;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.Placements;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
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

        const string mockResponse = """
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

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/org-123/placements")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.CreateAsync(
            "org-123",
            new CreatePlacementRequestBody
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
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

        const string mockResponse = """
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

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/org-123/placements")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.CreateAsync(
            "org-123",
            new CreatePlacementRequestBody
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
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

        const string mockResponse = """
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

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/org-123/placements")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.CreateAsync(
            "org-123",
            new CreatePlacementRequestBody
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
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

        const string mockResponse = """
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

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/org-123/placements")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.CreateAsync(
            "org-123",
            new CreatePlacementRequestBody
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
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

        const string mockResponse = """
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

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/org-123/placements")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.CreateAsync(
            "org-123",
            new CreatePlacementRequestBody
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
