using KardApi;
using NUnit.Framework;
using WireMock.Logging;
using WireMock.Server;
using WireMock.Settings;

namespace KardApi.Test.Unit.MockServer;

public class BaseMockServerTest
{
    protected WireMockServer Server { get; set; } = null!;

    protected KardApiClient Client { get; set; } = null!;

    protected RequestOptions RequestOptions { get; set; } = new();

    private void MockOAuthEndpoint()
    {
        const string requestJson = """
            {
              "client_id": "client_id",
              "client_secret": "client_secret"
            }
            """;

        const string mockResponse = """
            {
              "access_token": "access_token",
              "expires_in": 1,
              "token_type": "token_type"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/auth/token").UsingPost())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );
    }

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        // Start the WireMock server
        Server = WireMockServer.Start(
            new WireMockServerSettings { Logger = new WireMockConsoleLogger() }
        );

        // Initialize the Client
        Client = new KardApiClient(
            "client_id",
            "client_secret",
            clientOptions: new ClientOptions { BaseUrl = Server.Urls[0], MaxRetries = 0 }
        );
        MockOAuthEndpoint();
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        Server.Stop();
        Server.Dispose();
    }
}
