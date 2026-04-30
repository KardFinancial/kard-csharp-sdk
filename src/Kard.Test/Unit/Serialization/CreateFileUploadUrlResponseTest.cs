using Kard;
using Kard.Core;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateFileUploadUrlResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "incomingTransactionsFile",
                  "id": "2NxKz7TYmqVH8UrjGP1xK3hF2gs",
                  "attributes": {
                    "url": "https://s3.amazonaws.com/bucket/key1?X-Amz-Algorithm=...",
                    "expiresIn": 900
                  }
                },
                {
                  "type": "incomingTransactionsFile",
                  "id": "3PqLa8UZnrWI9VskHQ2yL4iG3ht",
                  "attributes": {
                    "url": "https://s3.amazonaws.com/bucket/key2?X-Amz-Algorithm=...",
                    "expiresIn": 900
                  }
                }
              ]
            }
            """;
        var expectedObject = new CreateFileUploadUrlResponse
        {
            Data = new List<FileUploadUrlData>()
            {
                new FileUploadUrlData
                {
                    Type = FileUploadType.IncomingTransactionsFile,
                    Id = "2NxKz7TYmqVH8UrjGP1xK3hF2gs",
                    Attributes = new FileUploadUrlAttributes
                    {
                        Url = "https://s3.amazonaws.com/bucket/key1?X-Amz-Algorithm=...",
                        ExpiresIn = 900,
                    },
                },
                new FileUploadUrlData
                {
                    Type = FileUploadType.IncomingTransactionsFile,
                    Id = "3PqLa8UZnrWI9VskHQ2yL4iG3ht",
                    Attributes = new FileUploadUrlAttributes
                    {
                        Url = "https://s3.amazonaws.com/bucket/key2?X-Amz-Algorithm=...",
                        ExpiresIn = 900,
                    },
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateFileUploadUrlResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": [
                {
                  "type": "incomingTransactionsFile",
                  "id": "2NxKz7TYmqVH8UrjGP1xK3hF2gs",
                  "attributes": {
                    "url": "https://s3.amazonaws.com/bucket/key1?X-Amz-Algorithm=...",
                    "expiresIn": 900
                  }
                },
                {
                  "type": "incomingTransactionsFile",
                  "id": "3PqLa8UZnrWI9VskHQ2yL4iG3ht",
                  "attributes": {
                    "url": "https://s3.amazonaws.com/bucket/key2?X-Amz-Algorithm=...",
                    "expiresIn": 900
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateFileUploadUrlResponse>(inputJson);
    }
}
