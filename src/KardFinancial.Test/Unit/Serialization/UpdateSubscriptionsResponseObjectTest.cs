using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Notifications;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateSubscriptionsResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
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
        var expectedObject = new UpdateSubscriptionsResponseObject
        {
            Data = new CreateSubscriptionUnion(
                new CreateSubscriptionUnion.Subscription(
                    new CreatedSubscription
                    {
                        Id = "0193i257-014e-7dd2-9455-fb964d9c85cr",
                        Attributes = new SubscriptionRequestAttributes
                        {
                            EventName = NotificationType.EarnedRewardApproved,
                            WebhookUrl = "https://webhookUrl.com/post",
                            Enabled = true,
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateSubscriptionsResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
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
        JsonAssert.Roundtrips<UpdateSubscriptionsResponseObject>(inputJson);
    }
}
