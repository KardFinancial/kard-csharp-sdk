using global::System.Globalization;
using KardApi.Core;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ActivateOfferResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "offerAttribution",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "entityId": "offer-456",
                  "eventCode": "ACTIVATE",
                  "medium": "CTA",
                  "eventDate": "2025-01-01T00:00:00Z"
                }
              }
            }
            """;
        var expectedObject = new ActivateOfferResponse
        {
            Data = new ActivateOfferResponseData
            {
                Type = "offerAttribution",
                Id = "c94a93a7-beb9-4e58-960c-2c812f849398",
                Attributes = new ActivateOfferResponseAttributes
                {
                    EntityId = "offer-456",
                    EventCode = "ACTIVATE",
                    Medium = "CTA",
                    EventDate = DateTime.Parse(
                        "2025-01-01T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<ActivateOfferResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "offerAttribution",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "entityId": "offer-456",
                  "eventCode": "ACTIVATE",
                  "medium": "CTA",
                  "eventDate": "2025-01-01T00:00:00Z"
                }
              }
            }
            """;
        JsonAssert.Roundtrips<ActivateOfferResponse>(inputJson);
    }
}
