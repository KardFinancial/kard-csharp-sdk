using global::System.Globalization;
using KardApi;
using KardApi.Core;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;
using OneOf;

namespace KardApi.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LocationsResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
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
                    "startDate": "2022-01-01T05:00:00Z",
                    "expirationDate": "2022-01-01T05:00:00Z",
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
                "prev": null,
                "next": "/v2/issuers/{organizationId}/users/{userId}/locations?page[after]=NDMyNzQyODI3OTQw&page[size]=1&filter[latitude]=39.9419429&filter[longitude]=-75.1446869&filter[radius]=10&include=offers,categories"
              }
            }
            """;
        var expectedObject = new LocationsResponseObject
        {
            Data = new List<LocationData>()
            {
                new LocationData
                {
                    Type = "location",
                    Id = "5e27318c9b346f00087fba8l",
                    Attributes = new LocationAttributes
                    {
                        Name = "Worlds Greatest Chicken",
                        Address = new EligibilityLocationAddress
                        {
                            Street = "120 Main St",
                            City = "Philadelphia",
                            State = "PA",
                            ZipCode = "19147",
                        },
                        Coordinates = new Coordinates
                        {
                            Longitude = -75.1446869,
                            Latitude = 39.9419429,
                        },
                        Phone = "+1 (123) 555-8880",
                        OperationHours = new OperationHours
                        {
                            Periods = new List<OperationPeriod>()
                            {
                                new OperationPeriod
                                {
                                    Close = new OperationTime { Day = 1, Time = "1700" },
                                    Open = new OperationTime { Day = 1, Time = "0900" },
                                },
                                new OperationPeriod
                                {
                                    Close = new OperationTime { Day = 2, Time = "1700" },
                                    Open = new OperationTime { Day = 2, Time = "0900" },
                                },
                                new OperationPeriod
                                {
                                    Close = new OperationTime { Day = 3, Time = "1700" },
                                    Open = new OperationTime { Day = 3, Time = "0900" },
                                },
                                new OperationPeriod
                                {
                                    Close = new OperationTime { Day = 4, Time = "1700" },
                                    Open = new OperationTime { Day = 4, Time = "0900" },
                                },
                                new OperationPeriod
                                {
                                    Close = new OperationTime { Day = 5, Time = "1700" },
                                    Open = new OperationTime { Day = 5, Time = "0900" },
                                },
                            },
                            WeekdayText = new List<string>()
                            {
                                "Monday: 9:00 AM – 5:00 PM",
                                "Tuesday: 9:00 AM – 5:00 PM",
                                "Wednesday: 9:00 AM – 5:00 PM",
                                "Thursday: 9:00 AM – 5:00 PM",
                                "Friday: 9:00 AM – 5:00 PM",
                                "Saturday: Closed",
                                "Sunday: Closed",
                            },
                        },
                    },
                    Relationships = new LocationRelationships
                    {
                        Offers = new RelationshipMultiple
                        {
                            Data = new List<RelationshipData>()
                            {
                                new RelationshipData
                                {
                                    Type = "standardOffer",
                                    Id = "5e27318c9b346f00087fbb5b",
                                },
                            },
                        },
                        Category = new RelationshipMultiple
                        {
                            Data = new List<RelationshipData>()
                            {
                                new RelationshipData
                                {
                                    Type = "category",
                                    Id = "65920081b524d126068de24a",
                                },
                            },
                        },
                    },
                },
            },
            Included = new List<OneOf<OfferDataUnion, CategoryIncluded>>()
            {
                new CategoryIncluded
                {
                    Type = "category",
                    Id = "65920081b524d126068de24a",
                    Attributes = new CategoryFields { Name = CategoryOption.FoodBeverage },
                },
                new OfferDataUnion(
                    new OfferDataUnion.StandardOffer(
                        new StandardOffer
                        {
                            Id = "5e27318c9b346f00087fbb5c",
                            Attributes = new StandardOfferFields
                            {
                                Name = "Worlds Greatest Chicken",
                                Terms =
                                    "Worlds Greatest Chicken offers are only available within US Locations.",
                                PurchaseChannel = new List<PurchaseChannel>()
                                {
                                    PurchaseChannel.Instore,
                                },
                                UserReward = new Commission
                                {
                                    Type = CommissionType.Percent,
                                    Value = 5.7,
                                },
                                StartDate = DateTime.Parse(
                                    "2022-01-01T05:00:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                ExpirationDate = DateTime.Parse(
                                    "2022-01-01T05:00:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                MinRewardAmount = new Amount
                                {
                                    Type = AmountType.Cents,
                                    Value = 500,
                                },
                                MaxRewardAmount = new Amount
                                {
                                    Type = AmountType.Cents,
                                    Value = 2000,
                                },
                                MinTransactionAmount = new Amount
                                {
                                    Type = AmountType.Cents,
                                    Value = 500,
                                },
                                MaxTransactionAmount = new Amount
                                {
                                    Type = AmountType.Cents,
                                    Value = 2000,
                                },
                                MaxRedemptions = 1,
                                IsTargeted = true,
                                Assets = new List<Asset>()
                                {
                                    new Asset
                                    {
                                        Url =
                                            "http://attribution.getkard.com/logos/breakfastbunny_logo.png?subtype=IMG_VIEW&offerId=629fc220b7a4290009a188ec&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyZWZlcnJpbmdQYXJ0bmVyVXNlcklkIjoiNDM4MTAzIiwiaXNzdWVySWQiOiIwMDAwNDMyMSIsInR5cGUiOiJPRkZFUiIsInBheWxvYWQiOnsiand0VGltZXN0YW1wIjoiMjAyNi0wNC0yMyJ9fQ.4f9QmoGpgXVIXu9Tq8XFVcx7Rz0jptsYNYpmaIBszyc&state=eyJyYW5rIjoxLCJmaWx0ZXJzIjpbXX0%3D",
                                        Alt = "",
                                        Type = "IMG_VIEW",
                                    },
                                    new Asset
                                    {
                                        Url =
                                            "https://attribution.getkard.com/public/banners/breakfast-bunny-banner.jpg?subtype=BANNER_VIEW&offerId=629fc220b7a4290009a188ec&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyZWZlcnJpbmdQYXJ0bmVyVXNlcklkIjoiNDM4MTAzIiwiaXNzdWVySWQiOiIwMDAwNDMyMSIsInR5cGUiOiJPRkZFUiIsInBheWxvYWQiOnsiand0VGltZXN0YW1wIjoiMjAyNi0wNC0yMyJ9fQ.4f9QmoGpgXVIXu9Tq8XFVcx7Rz0jptsYNYpmaIBszyc&state=eyJyYW5rIjoxLCJmaWx0ZXJzIjpbXX0%3D",
                                        Alt = "",
                                        Type = "BANNER_VIEW",
                                    },
                                },
                                WebsiteUrl = "http://worldsgreatestchickent.test.com",
                                Description =
                                    "Worlds Greatest Chicken brings you the tastiest crispy, double fried spicy chicken in the world.",
                            },
                        }
                    )
                ),
            },
            Links = new Links
            {
                Self =
                    "/v2/issuers/{organizationId}/users/{userId}/locations?page[size]=1&filter[latitude]=39.9419429&filter[longitude]=-75.1446869&filter[radius]=10&include=offers,categories",
                Next =
                    "/v2/issuers/{organizationId}/users/{userId}/locations?page[after]=NDMyNzQyODI3OTQw&page[size]=1&filter[latitude]=39.9419429&filter[longitude]=-75.1446869&filter[radius]=10&include=offers,categories",
            },
        };
        var deserializedObject = JsonUtils.Deserialize<LocationsResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
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
                    "startDate": "2022-01-01T05:00:00Z",
                    "expirationDate": "2022-01-01T05:00:00Z",
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
                "prev": null,
                "next": "/v2/issuers/{organizationId}/users/{userId}/locations?page[after]=NDMyNzQyODI3OTQw&page[size]=1&filter[latitude]=39.9419429&filter[longitude]=-75.1446869&filter[radius]=10&include=offers,categories"
              }
            }
            """;
        JsonAssert.Roundtrips<LocationsResponseObject>(inputJson);
    }
}
