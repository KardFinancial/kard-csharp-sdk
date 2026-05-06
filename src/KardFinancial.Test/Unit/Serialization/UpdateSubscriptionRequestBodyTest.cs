using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Notifications;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateSubscriptionRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
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
        var expectedObject = new UpdateSubscriptionRequestBody
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
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateSubscriptionRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
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
        JsonAssert.Roundtrips<UpdateSubscriptionRequestBody>(inputJson);
    }
}
