using Kard;
using Kard.Core;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PingResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "message": "Ping successful",
              "status": "OK",
              "timestamp": "02/Oct/2025:17:52:43 +0000"
            }
            """;
        var expectedObject = new PingResponseObject
        {
            Message = "Ping successful",
            Status = "OK",
            Timestamp = "02/Oct/2025:17:52:43 +0000",
        };
        var deserializedObject = JsonUtils.Deserialize<PingResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "message": "Ping successful",
              "status": "OK",
              "timestamp": "02/Oct/2025:17:52:43 +0000"
            }
            """;
        JsonAssert.Roundtrips<PingResponseObject>(inputJson);
    }
}
