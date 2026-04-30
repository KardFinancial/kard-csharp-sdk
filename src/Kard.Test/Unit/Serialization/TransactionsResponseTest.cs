using Kard;
using Kard.Core;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TransactionsResponseTest
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
                  "message": "Incoming Transactions event successfully queued for processing"
                }
              }
            }
            """;
        var expectedObject = new TransactionsResponse
        {
            Data = new TransactionsResponseData
            {
                Type = "job",
                Id = "c94a93a7-beb9-4e58-960c-2c812f849398",
                Attributes = new Job
                {
                    Status = JobStatus.Queued,
                    Message = "Incoming Transactions event successfully queued for processing",
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransactionsResponse>(json);
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
                  "message": "Incoming Transactions event successfully queued for processing"
                }
              }
            }
            """;
        JsonAssert.Roundtrips<TransactionsResponse>(inputJson);
    }
}
