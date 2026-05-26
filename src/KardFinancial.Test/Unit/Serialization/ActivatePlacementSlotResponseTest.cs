using global::System.Globalization;
using KardFinancial.Core;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ActivatePlacementSlotResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "placementSlotAttribution",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "placementId": "018f8d6b-1abc-7def-9012-345678901234",
                  "slotId": "slot-a",
                  "eventCode": "ACTIVATE",
                  "medium": "CTA",
                  "eventDate": "2025-01-01T00:00:00Z",
                  "offerIds": [
                    "offer-1",
                    "offer-2",
                    "offer-3"
                  ]
                }
              }
            }
            """;
        var expectedObject = new ActivatePlacementSlotResponse
        {
            Data = new ActivatePlacementSlotResponseData
            {
                Type = "placementSlotAttribution",
                Id = "c94a93a7-beb9-4e58-960c-2c812f849398",
                Attributes = new ActivatePlacementSlotResponseAttributes
                {
                    PlacementId = "018f8d6b-1abc-7def-9012-345678901234",
                    SlotId = "slot-a",
                    EventCode = "ACTIVATE",
                    Medium = "CTA",
                    EventDate = DateTime.Parse(
                        "2025-01-01T00:00:00.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    OfferIds = new List<string>() { "offer-1", "offer-2", "offer-3" },
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<ActivatePlacementSlotResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "placementSlotAttribution",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "placementId": "018f8d6b-1abc-7def-9012-345678901234",
                  "slotId": "slot-a",
                  "eventCode": "ACTIVATE",
                  "medium": "CTA",
                  "eventDate": "2025-01-01T00:00:00Z",
                  "offerIds": [
                    "offer-1",
                    "offer-2",
                    "offer-3"
                  ]
                }
              }
            }
            """;
        JsonAssert.Roundtrips<ActivatePlacementSlotResponse>(inputJson);
    }
}
