using global::System.Globalization;
using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ContentStrategyResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "type": "contentStrategy",
              "id": "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
              "attributes": {
                "name": "Featured Travel",
                "organizationId": "org-123",
                "filters": [
                  "HIGHEST_CASHBACK",
                  "NEWLY_LIVE"
                ],
                "categories": [
                  "Travel"
                ],
                "categoryExclusions": [
                  "Gas"
                ],
                "merchantExclusions": [
                  "merchant-abc"
                ],
                "createdAt": "2026-04-15T12:00:00Z",
                "lastModified": "2026-04-15T12:00:00Z"
              }
            }
            """;
        var expectedObject = new ContentStrategyResponse
        {
            Type = "contentStrategy",
            Id = "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
            Attributes = new ContentStrategyAttributes
            {
                Name = "Featured Travel",
                OrganizationId = "org-123",
                Filters = new List<ContentStrategyFilter>()
                {
                    ContentStrategyFilter.HighestCashback,
                    ContentStrategyFilter.NewlyLive,
                },
                Categories = new List<CategoryOption>() { CategoryOption.Travel },
                CategoryExclusions = new List<CategoryOption>() { CategoryOption.Gas },
                MerchantExclusions = new List<string>() { "merchant-abc" },
                CreatedAt = DateTime.Parse(
                    "2026-04-15T12:00:00.000Z",
                    null,
                    DateTimeStyles.AdjustToUniversal
                ),
                LastModified = DateTime.Parse(
                    "2026-04-15T12:00:00.000Z",
                    null,
                    DateTimeStyles.AdjustToUniversal
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<ContentStrategyResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "type": "contentStrategy",
              "id": "01961e5a-b74c-7d42-8456-d3a1f2c90e71",
              "attributes": {
                "name": "Featured Travel",
                "organizationId": "org-123",
                "filters": [
                  "HIGHEST_CASHBACK",
                  "NEWLY_LIVE"
                ],
                "categories": [
                  "Travel"
                ],
                "categoryExclusions": [
                  "Gas"
                ],
                "merchantExclusions": [
                  "merchant-abc"
                ],
                "createdAt": "2026-04-15T12:00:00Z",
                "lastModified": "2026-04-15T12:00:00Z"
              }
            }
            """;
        JsonAssert.Roundtrips<ContentStrategyResponse>(inputJson);
    }
}
