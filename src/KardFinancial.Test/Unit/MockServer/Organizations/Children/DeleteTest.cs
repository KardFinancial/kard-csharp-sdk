using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Organizations.Children;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": {
                "type": "type",
                "id": "id",
                "attributes": {}
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organizationId/children/childId")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.Children.DeleteAsync("organizationId", "childId");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
