using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateContentStrategyRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "contentStrategy",
                "attributes": {
                  "name": "Featured Travel",
                  "sort": "HIGHEST_CASHBACK",
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
            }
            """;
        var expectedObject = new CreateContentStrategyRequestBody
        {
            Data = new CreateContentStrategyRequestData
            {
                Type = "contentStrategy",
                Attributes = new CreateContentStrategyAttributes
                {
                    Name = "Featured Travel",
                    Sort = ContentStrategySort.HighestCashback,
                    Categories = new List<CategoryOption>() { CategoryOption.Travel },
                    CategoryExclusions = new List<CategoryOption>() { CategoryOption.Gas },
                    MerchantExclusions = new List<string>() { "merchant-abc" },
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateContentStrategyRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "contentStrategy",
                "attributes": {
                  "name": "Featured Travel",
                  "sort": "HIGHEST_CASHBACK",
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
            }
            """;
        JsonAssert.Roundtrips<CreateContentStrategyRequestBody>(inputJson);
    }
}
