using KardApi;
using KardApi.Notifications;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Notifications.Subscriptions;

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
                "type": "subscription",
                "attributes": {
                  "eventName": "earnedRewardApproved",
                  "webhookUrl": "https://webhookUrl.com/post",
                  "enabled": true
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "data": {
                "type": "subscription",
                "id": "0193i257-014e-7dd2-9455-fb964d9c85cr",
                "attributes": {
                  "eventName": "earnedRewardApproved",
                  "webhookUrl": "https://webhookUrl.com/post",
                  "enabled": true
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/subscriptions/subscription-123")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Notifications.Subscriptions.UpdateAsync(
            "organization-123",
            "subscription-123",
            new UpdateSubscriptionRequestBody
            {
                Data = new UpdateSubscriptionRequestUnion(
                    new UpdateSubscriptionRequestUnion.Subscription(
                        new UpdateSubscriptionRequest
                        {
                            Attributes = new UpdateSubscriptionRequestAttributes
                            {
                                EventName = NotificationType.EarnedRewardApproved,
                                WebhookUrl = "https://webhookUrl.com/post",
                                Enabled = true,
                            },
                        }
                    )
                ),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
