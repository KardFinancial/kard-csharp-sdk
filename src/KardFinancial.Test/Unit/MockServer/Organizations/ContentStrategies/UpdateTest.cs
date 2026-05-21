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
