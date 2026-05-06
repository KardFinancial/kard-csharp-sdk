using KardFinancial;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Users;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
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

        const string mockResponse = """
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

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.CreateAsync(
            "organization-123",
            new CreateUsersObject
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
