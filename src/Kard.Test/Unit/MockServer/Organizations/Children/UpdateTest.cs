using Kard.Organizations;
using Kard.Test.Unit.MockServer;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test.Unit.MockServer.Organizations.Children;

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
                "type": "organization",
                "attributes": {}
              }
            }
            """;

        const string mockResponse = """
            {
              "type": "organization",
              "id": "id",
              "attributes": {
                "name": "name",
                "externalId": "externalId",
                "bins": [
                  "bins",
                  "bins"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organizationId/children/childId")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Children.UpdateAsync(
            "organizationId",
            "childId",
            new UpdateChildRequestBody
            {
                Data = new UpdateChildRequestData
                {
                    Type = "organization",
                    Attributes = new UpdateChildAttributes(),
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
