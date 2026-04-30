using Kard.Core;
using Kard.Organizations;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateMainPageAttributesTest
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
        var expectedObject = new UpdateMainPageAttributes
        {
            Name = "Updated Banner",
            AvailableSlots = 10,
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateMainPageAttributes>(json);
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
        JsonAssert.Roundtrips<UpdateMainPageAttributes>(inputJson);
    }
}
