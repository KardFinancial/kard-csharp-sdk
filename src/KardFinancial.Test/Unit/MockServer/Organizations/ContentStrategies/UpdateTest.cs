using KardFinancial;
using KardFinancial.Organizations;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.ContentStrategies;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": {
                "type": "contentStrategy",
                "attributes": {
                  "name": "name",
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
                  ]
                }
              }
            }
            """;

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
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.ContentStrategies.UpdateAsync(
            "organizationId",
            "contentStrategyId",
            new UpdateContentStrategyRequestBody
            {
                Data = new UpdateContentStrategyRequestData
                {
                    Type = "contentStrategy",
                    Attributes = new UpdateContentStrategyAttributes
                    {
                        Name = "name",
                        Filters = new List<ContentStrategyFilter>()
                        {
                            ContentStrategyFilter.NewlyLive,
                            ContentStrategyFilter.NewlyLive,
                        },
                        Categories = new List<CategoryOption>()
                        {
                            CategoryOption.ArtsEntertainment,
                            CategoryOption.ArtsEntertainment,
                        },
                        CategoryExclusions = new List<CategoryOption>()
                        {
                            CategoryOption.ArtsEntertainment,
                            CategoryOption.ArtsEntertainment,
                        },
                        MerchantExclusions = new List<string>()
                        {
                            "merchantExclusions",
                            "merchantExclusions",
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
