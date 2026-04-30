using global::System.Globalization;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Users.Attributions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": [
                {
                  "type": "offerAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c075",
                    "eventCode": "VIEW",
                    "medium": "SEARCH",
                    "eventDate": "2025-01-01T00:00:00.000Z"
                  }
                },
                {
                  "type": "offerAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c077",
                    "eventCode": "IMPRESSION",
                    "medium": "EMAIL",
                    "eventDate": "2025-01-01T00:00:00.000Z"
                  }
                },
                {
                  "type": "notificationAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c076",
                    "eventCode": "IMPRESSION",
                    "medium": "PUSH",
                    "eventDate": "2025-01-01T00:00:00.000Z"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "data": {
                "type": "job",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "status": "queued",
                  "message": "Attribution events are queued for processing"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users/user-123/attributions")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Attributions.CreateAsync(
            "organization-123",
            "user-123",
            new CreateAttributionRequestObject
            {
                Data = new List<CreateAttributionRequestUnion>()
                {
                    new CreateAttributionRequestUnion(
                        new CreateAttributionRequestUnion.OfferAttribution(
                            new OfferAttributionRequest
                            {
                                Attributes = new OfferAttributionAttributes
                                {
                                    EntityId = "60e4ba1da31c5a22a144c075",
                                    EventCode = EventCode.View,
                                    Medium = OfferMedium.Search,
                                    EventDate = DateTime.Parse(
                                        "2025-01-01T00:00:00.000Z",
                                        null,
                                        DateTimeStyles.AdjustToUniversal
                                    ),
                                },
                            }
                        )
                    ),
                    new CreateAttributionRequestUnion(
                        new CreateAttributionRequestUnion.OfferAttribution(
                            new OfferAttributionRequest
                            {
                                Attributes = new OfferAttributionAttributes
                                {
                                    EntityId = "60e4ba1da31c5a22a144c077",
                                    EventCode = EventCode.Impression,
                                    Medium = OfferMedium.Email,
                                    EventDate = DateTime.Parse(
                                        "2025-01-01T00:00:00.000Z",
                                        null,
                                        DateTimeStyles.AdjustToUniversal
                                    ),
                                },
                            }
                        )
                    ),
                    new CreateAttributionRequestUnion(
                        new CreateAttributionRequestUnion.NotificationAttribution(
                            new NotificationAttributionRequest
                            {
                                Attributes = new NotificationAttributionAttributes
                                {
                                    EntityId = "60e4ba1da31c5a22a144c076",
                                    EventCode = EventCode.Impression,
                                    Medium = NotificationMedium.Push,
                                    EventDate = DateTime.Parse(
                                        "2025-01-01T00:00:00.000Z",
                                        null,
                                        DateTimeStyles.AdjustToUniversal
                                    ),
                                },
                            }
                        )
                    ),
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
