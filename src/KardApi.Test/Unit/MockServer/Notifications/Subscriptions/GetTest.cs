using KardApi.Notifications;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Notifications.Subscriptions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "subscription",
                  "id": "0193i257-014e-7dd2-9455-fb964d9c85cr",
                  "attributes": {
                    "eventName": "earnedRewardApproved",
                    "webhookUrl": "https://webhookUrl.com/post",
                    "enabled": true
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/subscriptions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Notifications.Subscriptions.GetAsync(
            "organization-123",
            new GetSubscriptionsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
