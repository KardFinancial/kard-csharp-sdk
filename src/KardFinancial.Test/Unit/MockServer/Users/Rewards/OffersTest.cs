using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Users.Rewards;

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
                        "url": "http://attribution.getkard.com/logos/breakfastbunny_logo.png?subtype=IMG_VIEW&offerId=629fc220b7a4290009a188ec&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyZWZlcnJpbmdQYXJ0bmVyVXNlcklkIjoiNDM4MTAzIiwiaXNzdWVySWQiOiIwMDAwNDMyMSIsInR5cGUiOiJPRkZFUiIsInBheWxvYWQiOnsiand0VGltZXN0YW1wIjoiMjAyNi0wNC0yMyJ9fQ.4f9QmoGpgXVIXu9Tq8XFVcx7Rz0jptsYNYpmaIBszyc&state=eyJyYW5rIjoxLCJmaWx0ZXJzIjpbXX0%3D",
                        "alt": "",
                        "type": "IMG_VIEW"
                      },
                      {
                        "url": "https://attribution.getkard.com/public/banners/breakfast-bunny-banner.jpg?subtype=BANNER_VIEW&offerId=629fc220b7a4290009a188ec&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyZWZlcnJpbmdQYXJ0bmVyVXNlcklkIjoiNDM4MTAzIiwiaXNzdWVySWQiOiIwMDAwNDMyMSIsInR5cGUiOiJPRkZFUiIsInBheWxvYWQiOnsiand0VGltZXN0YW1wIjoiMjAyNi0wNC0yMyJ9fQ.4f9QmoGpgXVIXu9Tq8XFVcx7Rz0jptsYNYpmaIBszyc&state=eyJyYW5rIjoxLCJmaWx0ZXJzIjpbXX0%3D",
                        "alt": "",
                        "type": "BANNER_VIEW"
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
                    .WithParam("page%5Bsize%5D", "1")
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
