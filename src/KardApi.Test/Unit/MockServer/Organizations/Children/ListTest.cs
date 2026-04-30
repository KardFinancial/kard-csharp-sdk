using KardApi.Organizations;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Organizations.Children;

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
                },
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
                    .WithPath("/v2/issuers/organizationId/children")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Children.ListAsync(
            "organizationId",
            new ListChildrenRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
