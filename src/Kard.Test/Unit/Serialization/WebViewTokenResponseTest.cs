using Kard.Core;
using Kard.Test.Utils;
using Kard.Users;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class WebViewTokenResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
              "expires_in": 3600,
              "token_type": "Bearer"
            }
            """;
        var expectedObject = new WebViewTokenResponse
        {
            AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
            ExpiresIn = 3600,
            TokenType = "Bearer",
        };
        var deserializedObject = JsonUtils.Deserialize<WebViewTokenResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
              "expires_in": 3600,
              "token_type": "Bearer"
            }
            """;
        JsonAssert.Roundtrips<WebViewTokenResponse>(inputJson);
    }
}
