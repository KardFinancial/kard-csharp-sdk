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
                "filter": "HIGHEST_CASHBACK",
                "categories": [
                  "Travel"
                ],
                "categoryExclusions": [
                  "Gas"
                ],
                "merchantExclusions": [
                  "merchant-abc"
                ]
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
                Filter = ContentStrategyFilter.HighestCashback,
                Categories = new List<CategoryOption>() { CategoryOption.Travel },
                CategoryExclusions = new List<CategoryOption>() { CategoryOption.Gas },
                MerchantExclusions = new List<string>() { "merchant-abc" },
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
                "filter": "HIGHEST_CASHBACK",
                "categories": [
                  "Travel"
                ],
                "categoryExclusions": [
                  "Gas"
                ],
                "merchantExclusions": [
                  "merchant-abc"
                ]
              }
            }
            """;
        JsonAssert.Roundtrips<ContentStrategyResponse>(inputJson);
    }
}
