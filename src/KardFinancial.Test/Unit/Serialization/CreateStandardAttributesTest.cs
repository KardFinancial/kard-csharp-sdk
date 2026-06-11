using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateStandardAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Homepage Banner",
              "availableSlots": 5
            }
            """;
        var expectedObject = new CreateStandardAttributes
        {
            Name = "Homepage Banner",
            AvailableSlots = 5,
        };
        var deserializedObject = JsonUtils.Deserialize<CreateStandardAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Homepage Banner",
              "availableSlots": 5
            }
            """;
        JsonAssert.Roundtrips<CreateStandardAttributes>(inputJson);
    }
}
