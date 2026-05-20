using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateContentStrategyAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Updated Travel Strategy",
              "filter": "EXPIRING_SOON",
              "categories": [
                "Travel",
                "Food & Beverage"
              ],
              "categoryExclusions": [],
              "merchantExclusions": [
                "merchant-xyz"
              ]
            }
            """;
        var expectedObject = new UpdateContentStrategyAttributes
        {
            Name = "Updated Travel Strategy",
            Filter = ContentStrategyFilter.ExpiringSoon,
            Categories = new List<CategoryOption>()
            {
                CategoryOption.Travel,
                CategoryOption.FoodBeverage,
            },
            CategoryExclusions = new List<CategoryOption>() { },
            MerchantExclusions = new List<string>() { "merchant-xyz" },
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateContentStrategyAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Updated Travel Strategy",
              "filter": "EXPIRING_SOON",
              "categories": [
                "Travel",
                "Food & Beverage"
              ],
              "categoryExclusions": [],
              "merchantExclusions": [
                "merchant-xyz"
              ]
            }
            """;
        JsonAssert.Roundtrips<UpdateContentStrategyAttributes>(inputJson);
    }
}
