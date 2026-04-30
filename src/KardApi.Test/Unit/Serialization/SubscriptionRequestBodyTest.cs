using KardApi;
using KardApi.Core;
using KardApi.Notifications;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubscriptionRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "subscription",
                  "attributes": {
                    "eventName": "earnedRewardApproved",
                    "webhookUrl": "https://webhookUrl.com/post",
                    "enabled": true
                  }
                }
              ]
            }
            """;
        var expectedObject = new SubscriptionRequestBody
        {
            Data = new List<SubscriptionRequestUnion>()
            {
                new SubscriptionRequestUnion(
                    new SubscriptionRequestUnion.Subscription(
                        new SubscriptionRequest
                        {
                            Attributes = new SubscriptionRequestAttributes
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
        var deserializedObject = JsonUtils.Deserialize<SubscriptionRequestBody>(json);
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
                  "attributes": {
                    "eventName": "earnedRewardApproved",
                    "webhookUrl": "https://webhookUrl.com/post",
                    "enabled": true
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<SubscriptionRequestBody>(inputJson);
    }
}
