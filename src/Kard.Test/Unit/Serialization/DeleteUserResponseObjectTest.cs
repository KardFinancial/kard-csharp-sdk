using Kard;
using Kard.Core;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteUserResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "user",
                "id": "1234567890",
                "attributes": {}
              }
            }
            """;
        var expectedObject = new DeleteUserResponseObject
        {
            Data = new UserResponseUnionNoData(
                new UserResponseUnionNoData.User(
                    new UserResponseNoData { Id = "1234567890", Attributes = new EmptyObject() }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<DeleteUserResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "user",
                "id": "1234567890",
                "attributes": {}
              }
            }
            """;
        JsonAssert.Roundtrips<DeleteUserResponseObject>(inputJson);
    }
}
