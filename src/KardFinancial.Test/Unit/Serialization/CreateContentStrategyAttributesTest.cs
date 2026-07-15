using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateContentStrategyAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Featured Travel",
              "sort": "HIGHEST_CASHBACK",
              "filters": {
                "offerFeatures": [
                  "INTERACTIVE"
                ]
              },
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
            """;
        var expectedObject = new CreateContentStrategyAttributes
        {
            Name = "Featured Travel",
            Sort = ContentStrategySort.HighestCashback,
            Filters = new ContentStrategyFilters
            {
                OfferFeatures = new List<OfferFeatures>() { OfferFeatures.Interactive },
            },
            Categories = new List<CategoryOption>() { CategoryOption.Travel },
            CategoryExclusions = new List<CategoryOption>() { CategoryOption.Gas },
            MerchantExclusions = new List<string>() { "merchant-abc" },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateContentStrategyAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Featured Travel",
              "sort": "HIGHEST_CASHBACK",
              "filters": {
                "offerFeatures": [
                  "INTERACTIVE"
                ]
              },
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
            """;
        JsonAssert.Roundtrips<CreateContentStrategyAttributes>(inputJson);
    }
}
