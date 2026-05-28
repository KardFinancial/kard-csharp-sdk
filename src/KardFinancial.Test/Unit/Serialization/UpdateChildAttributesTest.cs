using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateChildAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "name": "New Child Name"
            }
            """;
        var expectedObject = new UpdateChildAttributes { Name = "New Child Name" };
        var deserializedObject = JsonUtils.Deserialize<UpdateChildAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var inputJson = """
            {
              "name": "New Child Name"
            }
            """;
        JsonAssert.Roundtrips<UpdateChildAttributes>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
              "bins": [
                "123456",
                "789012"
              ]
            }
            """;
        var expectedObject = new UpdateChildAttributes
        {
            Bins = new List<string>() { "123456", "789012" },
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateChildAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var inputJson = """
            {
              "bins": [
                "123456",
                "789012"
              ]
            }
            """;
        JsonAssert.Roundtrips<UpdateChildAttributes>(inputJson);
    }
}
