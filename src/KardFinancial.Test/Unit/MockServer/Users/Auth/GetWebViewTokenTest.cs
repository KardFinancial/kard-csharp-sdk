using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Users.Auth;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetWebViewTokenTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
              "expires_in": 3600,
              "token_type": "Bearer"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/auth/issuers/organization-123/users/user-123/token")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Auth.GetWebViewTokenAsync("organization-123", "user-123");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
