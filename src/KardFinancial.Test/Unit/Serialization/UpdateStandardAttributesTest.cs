using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateStandardAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Updated Banner",
              "availableSlots": 10
            }
            """;
        var expectedObject = new UpdateStandardAttributes
        {
            Name = "Updated Banner",
            AvailableSlots = 10,
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateStandardAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Updated Banner",
              "availableSlots": 10
            }
            """;
        JsonAssert.Roundtrips<UpdateStandardAttributes>(inputJson);
    }
}
