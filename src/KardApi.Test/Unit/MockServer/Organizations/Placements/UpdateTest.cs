using KardApi.Organizations;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Organizations.Placements;

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
                "type": "placementMainPage",
                "attributes": {
                  "name": "name",
                  "availableSlots": 1
                }
              }
            }
            """;

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
                    new UpdatePlacementDataUnion.PlacementMainPage(
                        new UpdateMainPagePlacementData
                        {
                            Attributes = new UpdateMainPageAttributes
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
