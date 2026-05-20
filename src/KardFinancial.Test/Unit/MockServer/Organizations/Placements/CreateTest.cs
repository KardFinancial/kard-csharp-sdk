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
                "type": "placementMainPage",
                "attributes": {
                  "name": "Homepage Banner",
                  "availableSlots": 5
                }
              }
            }
            """;

        const string mockResponse = """
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
}
