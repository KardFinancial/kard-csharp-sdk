using Kard.Test.Unit.MockServer;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test.Unit.MockServer.Organizations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "type": "organization",
              "id": "id",
              "attributes": {
                "name": "name",
                "enrolledRewards": [
                  "CARDLINKED",
                  "CARDLINKED"
                ],
                "cardNetworks": [
                  "VISA",
                  "VISA"
                ],
                "bins": [
                  "bins",
                  "bins"
                ],
                "affiliateCommissionSplit": 1.1,
                "cardlinkedCommissionSplit": 1.1,
                "cardlinkedUserCommissionSplit": 1.1
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/issuer").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organizations.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
