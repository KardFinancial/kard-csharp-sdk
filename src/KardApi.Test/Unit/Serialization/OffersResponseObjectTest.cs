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
public class OffersResponseObjectTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
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
                    "startDate": "2024-11-17T05:00:00Z",
                    "expirationDate": "2025-03-17T05:00:00Z",
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
                "prev": null,
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
        var expectedObject = new OffersResponseObject
        {
            Data = new List<OfferDataUnion>()
            {
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
                                    "2024-11-17T05:00:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                ExpirationDate = DateTime.Parse(
                                    "2025-03-17T05:00:00.000Z",
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
                                    Value = 10000,
                                },
                                MaxRedemptions = 1,
                                IsTargeted = true,
                                Assets = new List<Asset>()
                                {
                                    new Asset
                                    {
                                        Type = "IMG_VIEW",
                                        Url =
                                            "http://assets.getkard.com/logo/img?attribution-tokens",
                                        Alt = "Worlds Greatest Chicken Logo Image",
                                    },
                                    new Asset
                                    {
                                        Type = "BANNER_VIEW",
                                        Url =
                                            "http://assets.getkard.com/banner/img?attribution-tokens",
                                        Alt = "Worlds Greatest Chicken Banner Image",
                                    },
                                },
                                WebsiteUrl = "http://worldsgreatestchickent.test.com",
                                Description =
                                    "Worlds Greatest Chicken brings you the tastiest crispy, double fried spicy chicken in the world.",
                            },
                            Relationships = new CategoryRelationshipObject
                            {
                                Category = new CategoryRelationship
                                {
                                    Data = new List<CategoryData>()
                                    {
                                        new CategoryData
                                        {
                                            Type = "category",
                                            Id = "65920081b524d126068de24a",
                                        },
                                        new CategoryData
                                        {
                                            Type = "category",
                                            Id = "65920081b524d126068de24c",
                                        },
                                    },
                                },
                            },
                        }
                    )
                ),
            },
            Included = new List<OneOf<CategoryIncluded>>()
            {
                new CategoryIncluded
                {
                    Type = "category",
                    Id = "65920081b524d126068de24a",
                    Attributes = new CategoryFields { Name = CategoryOption.FoodBeverage },
                },
                new CategoryIncluded
                {
                    Type = "category",
                    Id = "65920081b524d126068de24c",
                    Attributes = new CategoryFields { Name = CategoryOption.DepartmentStores },
                },
            },
            Links = new Links
            {
                Self =
                    "/v2/issuers/{organizationId}/users/{userId}/offers?page[size]=1?sort=-startDate",
                Next =
                    "/v2/issuers/{organizationId}/users/{userId}/offers?page[after]=NDMyNzQyODI3OTQw&page[size]=1?&sort=-startDate",
            },
            Meta = new OffersMeta
            {
                AvailableCategories = new List<CategoryIncluded>()
                {
                    new CategoryIncluded
                    {
                        Type = "category",
                        Id = "65920081b524d126068de24a",
                        Attributes = new CategoryFields { Name = CategoryOption.FoodBeverage },
                    },
                    new CategoryIncluded
                    {
                        Type = "category",
                        Id = "65920081b524d126068de24c",
                        Attributes = new CategoryFields { Name = CategoryOption.DepartmentStores },
                    },
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<OffersResponseObject>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
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
                    "startDate": "2024-11-17T05:00:00Z",
                    "expirationDate": "2025-03-17T05:00:00Z",
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
                "prev": null,
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
        JsonAssert.Roundtrips<OffersResponseObject>(inputJson);
    }
}
