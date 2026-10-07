using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateUsersObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "data": [
                {
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
                    "birthYear": "1990",
                    "historicalTransactionsSent": true
                  }
                }
              ]
            }
            """;
        var expectedObject = new CreateUsersObject
        {
            Data = new List<UserRequestDataUnion>()
            {
                new UserRequestDataUnion(
                    new UserRequestDataUnion.User(
                        new UserRequestData
                        {
                            Id = "1234567890",
                            Attributes = new UserRequestAttributes
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
                                HistoricalTransactionsSent = true,
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateUsersObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var inputJson = """
            {
              "data": [
                {
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
                    "birthYear": "1990",
                    "historicalTransactionsSent": true
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateUsersObject>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
              "data": [
                {
                  "type": "user",
                  "id": "1234567890",
                  "attributes": {
                    "enrolledRewards": [
                      "CARDLINKED"
                    ],
                    "email": "user@example.com",
                    "phoneNumbers": [
                      {
                        "number": "+14155552671",
                        "type": "MOBILE"
                      },
                      {
                        "number": "+12125550188",
                        "type": "HOME"
                      }
                    ],
                    "postalCodes": [
                      {
                        "code": "11238",
                        "type": "PHYSICAL"
                      },
                      {
                        "code": "10028",
                        "type": "BILLING"
                      }
                    ]
                  }
                }
              ]
            }
            """;
        var expectedObject = new CreateUsersObject
        {
            Data = new List<UserRequestDataUnion>()
            {
                new UserRequestDataUnion(
                    new UserRequestDataUnion.User(
                        new UserRequestData
                        {
                            Id = "1234567890",
                            Attributes = new UserRequestAttributes
                            {
                                EnrolledRewards = new List<EnrolledRewardsType>()
                                {
                                    EnrolledRewardsType.Cardlinked,
                                },
                                Email = "user@example.com",
                                PhoneNumbers = new List<PhoneNumber>()
                                {
                                    new PhoneNumber
                                    {
                                        Number = "+14155552671",
                                        Type = PhoneNumberType.Mobile,
                                    },
                                    new PhoneNumber
                                    {
                                        Number = "+12125550188",
                                        Type = PhoneNumberType.Home,
                                    },
                                },
                                PostalCodes = new List<PostalCode>()
                                {
                                    new PostalCode
                                    {
                                        Code = "11238",
                                        Type = PostalCodeType.Physical,
                                    },
                                    new PostalCode
                                    {
                                        Code = "10028",
                                        Type = PostalCodeType.Billing,
                                    },
                                },
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<CreateUsersObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var inputJson = """
            {
              "data": [
                {
                  "type": "user",
                  "id": "1234567890",
                  "attributes": {
                    "enrolledRewards": [
                      "CARDLINKED"
                    ],
                    "email": "user@example.com",
                    "phoneNumbers": [
                      {
                        "number": "+14155552671",
                        "type": "MOBILE"
                      },
                      {
                        "number": "+12125550188",
                        "type": "HOME"
                      }
                    ],
                    "postalCodes": [
                      {
                        "code": "11238",
                        "type": "PHYSICAL"
                      },
                      {
                        "code": "10028",
                        "type": "BILLING"
                      }
                    ]
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<CreateUsersObject>(inputJson);
    }
}
