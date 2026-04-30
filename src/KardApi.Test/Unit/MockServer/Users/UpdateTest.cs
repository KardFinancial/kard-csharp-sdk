using KardApi;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Users;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
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

        const string mockResponse = """
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
                  "birthYear": "1990",
                  "historicalTransactionsSent": true
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users/user-123")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.UpdateAsync(
            "organization-123",
            "user-123",
            new UpdateUserObject
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
