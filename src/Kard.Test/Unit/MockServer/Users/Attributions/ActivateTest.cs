using Kard.Test.Unit.MockServer;
using Kard.Test.Utils;
using Kard.Users;
using NUnit.Framework;

namespace Kard.Test.Unit.MockServer.Users.Attributions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ActivateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": {
                "type": "offerAttribution",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "entityId": "offer-456",
                  "eventCode": "ACTIVATE",
                  "medium": "CTA",
                  "eventDate": "2025-01-01T00:00:00.000Z"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/issuers/organization-123/users/user-123/offers/offer-456/activate"
                    )
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Attributions.ActivateAsync(
            "organization-123",
            "user-123",
            "offer-456",
            new ActivateOfferRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
