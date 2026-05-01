using KardApi;
using KardApi.Core;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class NetworkBlockedErrorBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "message": "Unauthorized"
            }
            """;
        var expectedObject = new NetworkBlockedErrorBody { Message = "Unauthorized" };
        var deserializedObject = JsonUtils.Deserialize<NetworkBlockedErrorBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "message": "Unauthorized"
            }
            """;
        JsonAssert.Roundtrips<NetworkBlockedErrorBody>(inputJson);
    }
}
