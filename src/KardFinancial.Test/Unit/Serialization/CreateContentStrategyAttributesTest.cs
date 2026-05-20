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
            """;
        var expectedObject = new CreateContentStrategyAttributes
        {
            Name = "Featured Travel",
            Filter = ContentStrategyFilter.HighestCashback,
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
            """;
        JsonAssert.Roundtrips<CreateContentStrategyAttributes>(inputJson);
    }
}
