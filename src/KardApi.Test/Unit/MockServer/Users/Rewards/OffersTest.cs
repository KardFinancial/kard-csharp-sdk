using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Users.Rewards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class OffersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "standardOffer",
                  "id": "5e27318c9b346f00087fbb5c",
                  "attributes": {
                    "name": "Worlds Greatest Chicken",
                    "terms": "Worlds Greatest Chicken offers are only available within US Locations.",
                    "purchaseChannel": [
                      "INSTORE"
                    ],
                    "userReward": {
                      "type": "PERCENT",
                      "value": 5.7
                    },
                    "startDate": "2024-11-17T05:00:00.000Z",
                    "expirationDate": "2025-03-17T05:00:00.000Z",
                    "minRewardAmount": {
                      "type": "CENTS",
                      "value": 500
                    },
                    "maxRewardAmount": {
                      "type": "CENTS",
                      "value": 2000
                    },
                    "minTransactionAmount": {
                      "type": "CENTS",
                      "value": 500
                    },
                    "maxTransactionAmount": {
                      "type": "CENTS",
                      "value": 10000
                    },
                    "maxRedemptions": 1,
                    "isTargeted": true,
                    "assets": [
                      {
                        "type": "IMG_VIEW",
                        "url": "http://assets.getkard.com/logo/img?attribution-tokens",
                        "alt": "Worlds Greatest Chicken Logo Image"
                      },
                      {
                        "type": "BANNER_VIEW",
                        "url": "http://assets.getkard.com/banner/img?attribution-tokens",
                        "alt": "Worlds Greatest Chicken Banner Image"
                      }
                    ],
                    "websiteUrl": "http://worldsgreatestchickent.test.com",
                    "description": "Worlds Greatest Chicken brings you the tastiest crispy, double fried spicy chicken in the world."
                  },
                  "relationships": {
                    "category": {
                      "data": [
                        {
                          "type": "category",
                          "id": "65920081b524d126068de24a"
                        },
                        {
                          "type": "category",
                          "id": "65920081b524d126068de24c"
                        }
                      ]
                    }
                  }
                }
              ],
              "included": [
                {
                  "type": "category",
                  "id": "65920081b524d126068de24a",
                  "attributes": {
                    "name": "Food & Beverage"
                  }
                },
                {
                  "type": "category",
                  "id": "65920081b524d126068de24c",
                  "attributes": {
                    "name": "Department Stores"
                  }
                }
              ],
              "links": {
                "self": "/v2/issuers/{organizationId}/users/{userId}/offers?page[size]=1?sort=-startDate",
                "next": "/v2/issuers/{organizationId}/users/{userId}/offers?page[after]=NDMyNzQyODI3OTQw&page[size]=1?&sort=-startDate"
              },
              "meta": {
                "availableCategories": [
                  {
                    "type": "category",
                    "id": "65920081b524d126068de24a",
                    "attributes": {
                      "name": "Food & Beverage"
                    }
                  },
                  {
                    "type": "category",
                    "id": "65920081b524d126068de24c",
                    "attributes": {
                      "name": "Department Stores"
                    }
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users/user-123/offers")
                    .WithParam("page[size]", "1")
                    .WithParam("sort", "-startDate")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Rewards.OffersAsync(
            "organization-123",
            "user-123",
            new GetOffersByUserRequest
            {
                PageSize = 1,
                FilterIsTargeted = true,
                Sort = [OfferSortOptions.StartDateDesc],
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
