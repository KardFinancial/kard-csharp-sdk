using KardFinancial.Organizations;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.ContentStrategies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "contentStrategy",
                  "id": "id",
                  "attributes": {
                    "name": "name",
                    "organizationId": "organizationId",
                    "filter": "NEWLY_LIVE",
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
                },
                {
                  "type": "contentStrategy",
                  "id": "id",
                  "attributes": {
                    "name": "name",
                    "organizationId": "organizationId",
                    "filter": "NEWLY_LIVE",
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
              ],
              "links": {
                "self": "self",
                "prev": "prev",
                "next": "next"
              },
              "meta": {
                "pageSize": 1,
                "hasNextPage": true
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organizationId/contentStrategies")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.ContentStrategies.ListAsync(
            "organizationId",
            new ListContentStrategiesRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
