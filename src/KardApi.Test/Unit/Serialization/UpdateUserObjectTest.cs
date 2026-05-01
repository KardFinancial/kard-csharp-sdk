using KardApi;
using KardApi.Core;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateUserObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": {
                "type": "user",
                "id": "1234567890",
                "attributes": {
                  "zipCode": "11238",
                  "enrolledRewards": [
                    "CARDLINKED"
                  ],
                  "email": "user@example.com",
                  "hashedEmail": "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3e2d8a5b76e45a1d4c4e2e3a1",
                  "phoneNumber": "+14155552671",
                  "birthYear": "1990"
                }
              }
            }
            """;
        var expectedObject = new UpdateUserObject
        {
            Data = new UpdateUserRequestDataUnion(
                new UpdateUserRequestDataUnion.User(
                    new UpdateUserRequestData
                    {
                        Id = "1234567890",
                        Attributes = new UpdateUserRequestAttributes
                        {
                            ZipCode = "11238",
                            EnrolledRewards = new List<EnrolledRewardsType>()
                            {
                                EnrolledRewardsType.Cardlinked,
                            },
                            Email = "user@example.com",
                            HashedEmail =
                                "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3e2d8a5b76e45a1d4c4e2e3a1",
                            PhoneNumber = "+14155552671",
                            BirthYear = "1990",
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<UpdateUserObject>(json);
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
                "attributes": {
                  "zipCode": "11238",
                  "enrolledRewards": [
                    "CARDLINKED"
                  ],
                  "email": "user@example.com",
                  "hashedEmail": "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3e2d8a5b76e45a1d4c4e2e3a1",
                  "phoneNumber": "+14155552671",
                  "birthYear": "1990"
                }
              }
            }
            """;
        JsonAssert.Roundtrips<UpdateUserObject>(inputJson);
    }
}
