using Kard.Core;
using Kard.Organizations;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateChildAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "name": "NEWCHILDNAME"
            }
            """;
        var expectedObject = new UpdateChildAttributes { Name = "NEWCHILDNAME" };
        var deserializedObject = JsonUtils.Deserialize<UpdateChildAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var inputJson = """
            {
              "name": "NEWCHILDNAME"
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
