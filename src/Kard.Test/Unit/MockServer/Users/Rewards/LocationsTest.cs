using Kard.Test.Unit.MockServer;
using Kard.Test.Utils;
using Kard.Users;
using NUnit.Framework;

namespace Kard.Test.Unit.MockServer.Users.Rewards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LocationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "location",
                  "id": "5e27318c9b346f00087fba8l",
                  "attributes": {
                    "name": "Worlds Greatest Chicken",
                    "address": {
                      "street": "120 Main St",
                      "city": "Philadelphia",
                      "state": "PA",
                      "zipCode": "19147"
                    },
                    "coordinates": {
                      "longitude": -75.1446869,
                      "latitude": 39.9419429
                    },
                    "phone": "+1 (123) 555-8880",
                    "operationHours": {
                      "periods": [
                        {
                          "close": {
                            "day": 1,
                            "time": "1700"
                          },
                          "open": {
                            "day": 1,
                            "time": "0900"
                          }
                        },
                        {
                          "close": {
                            "day": 2,
                            "time": "1700"
                          },
                          "open": {
                            "day": 2,
                            "time": "0900"
                          }
                        },
                        {
                          "close": {
                            "day": 3,
                            "time": "1700"
                          },
                          "open": {
                            "day": 3,
                            "time": "0900"
                          }
                        },
                        {
                          "close": {
                            "day": 4,
                            "time": "1700"
                          },
                          "open": {
                            "day": 4,
                            "time": "0900"
                          }
                        },
                        {
                          "close": {
                            "day": 5,
                            "time": "1700"
                          },
                          "open": {
                            "day": 5,
                            "time": "0900"
                          }
                        }
                      ],
                      "weekdayText": [
                        "Monday: 9:00 AM – 5:00 PM",
                        "Tuesday: 9:00 AM – 5:00 PM",
                        "Wednesday: 9:00 AM – 5:00 PM",
                        "Thursday: 9:00 AM – 5:00 PM",
                        "Friday: 9:00 AM – 5:00 PM",
                        "Saturday: Closed",
                        "Sunday: Closed"
                      ]
                    }
                  },
                  "relationships": {
                    "offers": {
                      "data": [
                        {
                          "type": "standardOffer",
                          "id": "5e27318c9b346f00087fbb5b"
                        }
                      ]
                    },
                    "category": {
                      "data": [
                        {
                          "type": "category",
                          "id": "65920081b524d126068de24a"
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
                    "startDate": "2022-01-01T05:00:00.000Z",
                    "expirationDate": "2022-01-01T05:00:00.000Z",
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
                      "value": 2000
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
                  }
                }
              ],
              "links": {
                "self": "/v2/issuers/{organizationId}/users/{userId}/locations?page[size]=1&filter[latitude]=39.9419429&filter[longitude]=-75.1446869&filter[radius]=10&include=offers,categories",
                "next": "/v2/issuers/{organizationId}/users/{userId}/locations?page[after]=NDMyNzQyODI3OTQw&page[size]=1&filter[latitude]=39.9419429&filter[longitude]=-75.1446869&filter[radius]=10&include=offers,categories"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users/user-123/locations")
                    .WithParam("page%5Bsize%5D", "1")
                    .WithParam("filter%5Blatitude%5D", "39.9419429")
                    .WithParam("filter%5Blongitude%5D", "-75.1446869")
                    .WithParam("filter%5Bradius%5D", "10")
                    .WithParam("include", "offers", "categories")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Rewards.LocationsAsync(
            "organization-123",
            "user-123",
            new GetLocationsByUserRequest
            {
                PageSize = 1,
                FilterLatitude = 39.9419429,
                FilterLongitude = -75.1446869,
                FilterRadius = 10,
                Include = ["offers,categories"],
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
