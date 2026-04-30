using Kard.Test.Unit.MockServer;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test.Unit.MockServer.Ping;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Ping successful",
              "status": "OK",
              "timestamp": "02/Oct/2025:17:52:43 +0000"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/ping").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Ping.PingAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
