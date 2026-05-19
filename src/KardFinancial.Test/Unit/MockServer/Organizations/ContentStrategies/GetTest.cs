using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.ContentStrategies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "type": "contentStrategy",
              "id": "id",
              "attributes": {
                "name": "name",
                "organizationId": "organizationId",
                "filters": [
                  "NEWLY_LIVE",
                  "NEWLY_LIVE"
                ],
                "categories": [
                  "Arts & Entertainment",
                  "Arts & Entertainment"
                ],
                "categoryExclusions": [
                  "Arts & Entertainment",
                  "Arts & Entertainment"
                ],
                "merchantExclusions": [
                  "merchantExclusions",
                  "merchantExclusions"
                ],
                "createdAt": "2024-01-15T09:30:00.000Z",
                "lastModified": "2024-01-15T09:30:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organizationId/contentStrategies/contentStrategyId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.ContentStrategies.GetAsync(
            "organizationId",
            "contentStrategyId"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
