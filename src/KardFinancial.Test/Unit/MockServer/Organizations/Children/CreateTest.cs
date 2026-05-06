using KardFinancial.Organizations;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.Children;

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
                "type": "organization",
                "attributes": {
                  "name": "name"
                }
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
                    .WithPath("/v2/issuers/organizationId/children")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Children.CreateAsync(
            "organizationId",
            new CreateChildRequestBody
            {
                Data = new CreateChildRequestData
                {
                    Type = "organization",
                    Attributes = new CreateChildAttributes { Name = "name" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
