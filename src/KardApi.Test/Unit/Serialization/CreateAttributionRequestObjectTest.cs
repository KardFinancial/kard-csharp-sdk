using global::System.Globalization;
using KardApi.Core;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateAttributionRequestObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "offerAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c075",
                    "eventCode": "VIEW",
                    "medium": "SEARCH",
                    "eventDate": "2025-01-01T00:00:00Z"
                  }
                },
                {
                  "type": "offerAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c077",
                    "eventCode": "IMPRESSION",
                    "medium": "EMAIL",
                    "eventDate": "2025-01-01T00:00:00Z"
                  }
                },
                {
                  "type": "notificationAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c076",
                    "eventCode": "IMPRESSION",
                    "medium": "PUSH",
                    "eventDate": "2025-01-01T00:00:00Z"
                  }
                }
              ]
            }
            """;
        var expectedObject = new CreateAttributionRequestObject
        {
            Data = new List<CreateAttributionRequestUnion>()
            {
                new CreateAttributionRequestUnion(
                    new CreateAttributionRequestUnion.OfferAttribution(
                        new OfferAttributionRequest
                        {
                            Attributes = new OfferAttributionAttributes
                            {
                                EntityId = "60e4ba1da31c5a22a144c075",
                                EventCode = EventCode.View,
                                Medium = OfferMedium.Search,
                                EventDate = DateTime.Parse(
                                    "2025-01-01T00:00:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                            },
                        }
                    )
                ),
                new CreateAttributionRequestUnion(
                    new CreateAttributionRequestUnion.OfferAttribution(
                        new OfferAttributionRequest
                        {
                            Attributes = new OfferAttributionAttributes
                            {
                                EntityId = "60e4ba1da31c5a22a144c077",
                                EventCode = EventCode.Impression,
                                Medium = OfferMedium.Email,
                                EventDate = DateTime.Parse(
                                    "2025-01-01T00:00:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                            },
                        }
                    )
                ),
                new CreateAttributionRequestUnion(
                    new CreateAttributionRequestUnion.NotificationAttribution(
                        new NotificationAttributionRequest
                        {
                            Attributes = new NotificationAttributionAttributes
                            {
                                EntityId = "60e4ba1da31c5a22a144c076",
                                EventCode = EventCode.Impression,
                                Medium = NotificationMedium.Push,
                                EventDate = DateTime.Parse(
                                    "2025-01-01T00:00:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateAttributionRequestObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": [
                {
                  "type": "offerAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c075",
                    "eventCode": "VIEW",
                    "medium": "SEARCH",
                    "eventDate": "2025-01-01T00:00:00Z"
                  }
                },
                {
                  "type": "offerAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c077",
                    "eventCode": "IMPRESSION",
                    "medium": "EMAIL",
                    "eventDate": "2025-01-01T00:00:00Z"
                  }
                },
                {
                  "type": "notificationAttribution",
                  "attributes": {
                    "entityId": "60e4ba1da31c5a22a144c076",
                    "eventCode": "IMPRESSION",
                    "medium": "PUSH",
                    "eventDate": "2025-01-01T00:00:00Z"
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateAttributionRequestObject>(inputJson);
    }
}
