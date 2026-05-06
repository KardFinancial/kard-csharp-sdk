using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.Placements;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "type": "placementMainPage",
              "id": "id",
              "attributes": {
                "name": "name",
                "organizationId": "organizationId",
                "availableSlots": 1,
                "createdAt": "2024-01-15T09:30:00.000Z",
                "lastModified": "2024-01-15T09:30:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organizationId/placements/placementId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.GetAsync(
            "organizationId",
            "placementId"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
