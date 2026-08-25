using KardFinancial.Organizations;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.Placements;

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
                "type": "placement",
                "attributes": {
                  "name": "name",
                  "availableSlots": 1
                }
              }
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organizationId/placements/placementId")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Placements.UpdateAsync(
            "organizationId",
            "placementId",
            new UpdatePlacementRequestBody
            {
                Data = new UpdatePlacementDataUnion(
                    new UpdatePlacementDataUnion.Placement(
                        new UpdateStandardPlacementData
                        {
                            Attributes = new UpdateStandardAttributes
                            {
                                Name = "name",
                                AvailableSlots = 1,
                            },
                        }
                    )
                ),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
