using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Notifications;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubscriptionsResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
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
        var expectedObject = new SubscriptionsResponseObject
        {
            Data = new List<SubscriptionUnion>()
            {
                new SubscriptionUnion(
                    new SubscriptionUnion.Subscription(
                        new Subscription
                        {
                            Id = "0193i257-014e-7dd2-9455-fb964d9c85cr",
                            Attributes = new SubscriptionAttributes
                            {
                                EventName = NotificationType.EarnedRewardApproved,
                                WebhookUrl = "https://webhookUrl.com/post",
                                Enabled = true,
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<SubscriptionsResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
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
        JsonAssert.Roundtrips<SubscriptionsResponseObject>(inputJson);
    }
}
