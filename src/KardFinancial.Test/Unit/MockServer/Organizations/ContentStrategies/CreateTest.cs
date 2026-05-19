using KardFinancial;
using KardFinancial.Organizations;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.ContentStrategies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": {
                "type": "contentStrategy",
                "attributes": {
                  "name": "Featured Travel",
                  "filters": [
                    "HIGHEST_CASHBACK",
                    "NEWLY_LIVE"
                  ],
                  "categories": [
                    "Travel"
                  ],
                  "categoryExclusions": [
                    "Gas"
                  ],
                  "merchantExclusions": [
                    "merchant-abc"
                  ]
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "type": "contentStrategy",
              "id": "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
              "attributes": {
                "name": "Featured Travel",
                "organizationId": "org-123",
                "filters": [
                  "HIGHEST_CASHBACK",
                  "NEWLY_LIVE"
                ],
                "categories": [
                  "Travel"
                ],
                "categoryExclusions": [
                  "Gas"
                ],
                "merchantExclusions": [
                  "merchant-abc"
                ],
                "createdAt": "2026-04-15T12:00:00.000Z",
                "lastModified": "2026-04-15T12:00:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/org-123/contentStrategies")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.ContentStrategies.CreateAsync(
            "org-123",
            new CreateContentStrategyRequestBody
            {
                Data = new CreateContentStrategyRequestData
                {
                    Type = "contentStrategy",
                    Attributes = new CreateContentStrategyAttributes
                    {
                        Name = "Featured Travel",
                        Filters = new List<ContentStrategyFilter>()
                        {
                            ContentStrategyFilter.HighestCashback,
                            ContentStrategyFilter.NewlyLive,
                        },
                        Categories = new List<CategoryOption>() { CategoryOption.Travel },
                        CategoryExclusions = new List<CategoryOption>() { CategoryOption.Gas },
                        MerchantExclusions = new List<string>() { "merchant-abc" },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
