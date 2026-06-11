using KardFinancial.Organizations;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.Placements;

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
                  "type": "placement",
                  "id": "id",
                  "attributes": {
                    "name": "name",
                    "organizationId": "organizationId",
                    "availableSlots": 1,
                    "contentStrategyId": "contentStrategyId"
                  },
                  "relationships": {
                    "contentStrategy": {
                      "data": {
                        "type": "type",
                        "id": "id"
                      }
                    }
                  }
                },
                {
                  "type": "placement",
                  "id": "id",
                  "attributes": {
                    "name": "name",
                    "organizationId": "organizationId",
                    "availableSlots": 1,
                    "contentStrategyId": "contentStrategyId"
                  },
                  "relationships": {
                    "contentStrategy": {
                      "data": {
                        "type": "type",
                        "id": "id"
                      }
                    }
                  }
                }
              ],
              "included": [
                {
                  "type": "contentStrategy",
                  "id": "id",
                  "attributes": {
                    "name": "name",
                    "organizationId": "organizationId",
                    "sort": "NEWLY_LIVE",
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
                    ]
                  }
                },
                {
                  "type": "contentStrategy",
                  "id": "id",
                  "attributes": {
                    "name": "name",
                    "organizationId": "organizationId",
                    "sort": "NEWLY_LIVE",
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
                    ]
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
                    .WithPath("/v2/issuers/organizationId/placements")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.ListAsync(
            "organizationId",
            new ListPlacementsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
