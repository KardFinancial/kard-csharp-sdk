using KardFinancial.Core;
using KardFinancial.Organizations;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateChildAttributesTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "name": "Acme Child Bank",
              "externalId": "ext-123",
              "bins": [
                "123456",
                "789012"
              ]
            }
            """;
        var expectedObject = new CreateChildAttributes
        {
            Name = "Acme Child Bank",
            ExternalId = "ext-123",
            Bins = new List<string>() { "123456", "789012" },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateChildAttributes>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "name": "Acme Child Bank",
              "externalId": "ext-123",
              "bins": [
                "123456",
                "789012"
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateChildAttributes>(inputJson);
    }
}
