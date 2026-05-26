using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Users.Attributions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ActivatePlacementSlotTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": {
                "type": "placementSlotAttribution",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "placementId": "018f8d6b-1abc-7def-9012-345678901234",
                  "slotId": "slot-a",
                  "eventCode": "ACTIVATE",
                  "medium": "CTA",
                  "eventDate": "2025-01-01T00:00:00.000Z",
                  "offerIds": [
                    "offer-1",
                    "offer-2",
                    "offer-3"
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/issuers/organization-123/users/user-123/placements/018f8d6b-1abc-7def-9012-345678901234/slot/slot-a/activate"
                    )
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Attributions.ActivatePlacementSlotAsync(
            "organization-123",
            "user-123",
            "018f8d6b-1abc-7def-9012-345678901234",
            "slot-a"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
