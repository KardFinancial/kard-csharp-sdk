using KardApi;
using KardApi.Core;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateAttributionResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "job",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "status": "queued",
                  "message": "Attribution events are queued for processing"
                }
              }
            }
            """;
        var expectedObject = new CreateAttributionResponse
        {
            Data = new JobResponse
            {
                Type = "job",
                Id = "c94a93a7-beb9-4e58-960c-2c812f849398",
                Attributes = new Job
                {
                    Status = JobStatus.Queued,
                    Message = "Attribution events are queued for processing",
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateAttributionResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": {
                "type": "job",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "status": "queued",
                  "message": "Attribution events are queued for processing"
                }
              }
            }
            """;
        JsonAssert.Roundtrips<CreateAttributionResponse>(inputJson);
    }
}
