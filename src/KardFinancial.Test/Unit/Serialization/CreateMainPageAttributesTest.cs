using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateMainPageAttributesTest
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
        var expectedObject = new CreateMainPageAttributes
        {
            Name = "Homepage Banner",
            AvailableSlots = 5,
        };
        var deserializedObject = JsonUtils.Deserialize<CreateMainPageAttributes>(json);
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
        JsonAssert.Roundtrips<CreateMainPageAttributes>(inputJson);
    }
}
