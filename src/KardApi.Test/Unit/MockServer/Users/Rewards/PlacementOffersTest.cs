using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Users.Rewards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlacementOffersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "standardOffer",
                  "relationships": {
                    "category": {
                      "data": [
                        {
                          "id": "id",
                          "type": "category"
                        },
                        {
                          "id": "id",
                          "type": "category"
                        }
                      ]
                    }
                  },
                  "id": "id",
                  "attributes": {
                    "terms": "terms",
                    "maxRedemptions": 1,
                    "name": "name",
                    "purchaseChannel": [
                      "INSTORE",
                      "INSTORE"
                    ],
                    "userReward": {
                      "type": "FLAT",
                      "value": 1.1
                    },
                    "assets": [
                      {
                        "type": "type",
                        "url": "url",
                        "alt": "alt"
                      },
                      {
                        "type": "type",
                        "url": "url",
                        "alt": "alt"
                      }
                    ],
                    "startDate": "2024-01-15T09:30:00.000Z",
                    "expirationDate": "2024-01-15T09:30:00.000Z",
                    "isTargeted": true,
                    "minTransactionAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "maxTransactionAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "minRewardAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "maxRewardAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "websiteUrl": "websiteUrl",
                    "description": "description",
                    "components": {
                      "shortDescription": "shortDescription",
                      "longDescription": "longDescription",
                      "baseReward": "baseReward",
                      "boostedReward": "boostedReward",
                      "cta": {
                        "buttonText": "buttonText",
                        "buttonStyle": "PRIMARY",
                        "action": {
                          "url": "url",
                          "method": "method"
                        },
                        "startIcon": "startIcon"
                      },
                      "tags": [
                        "tags",
                        "tags"
                      ],
                      "detailTags": [
                        "detailTags",
                        "detailTags"
                      ],
                      "logoFlare": {
                        "borderColor": "PRIMARY",
                        "badge": {
                          "icon": "icon",
                          "position": "TOP_RIGHT"
                        }
                      },
                      "progressBar": {
                        "total": 1,
                        "currentProgress": 1,
                        "label": "label",
                        "segmented": true,
                        "labels": {
                          "details": {},
                          "default": {}
                        }
                      }
                    }
                  }
                },
                {
                  "type": "standardOffer",
                  "relationships": {
                    "category": {
                      "data": [
                        {
                          "id": "id",
                          "type": "category"
                        },
                        {
                          "id": "id",
                          "type": "category"
                        }
                      ]
                    }
                  },
                  "id": "id",
                  "attributes": {
                    "terms": "terms",
                    "maxRedemptions": 1,
                    "name": "name",
                    "purchaseChannel": [
                      "INSTORE",
                      "INSTORE"
                    ],
                    "userReward": {
                      "type": "FLAT",
                      "value": 1.1
                    },
                    "assets": [
                      {
                        "type": "type",
                        "url": "url",
                        "alt": "alt"
                      },
                      {
                        "type": "type",
                        "url": "url",
                        "alt": "alt"
                      }
                    ],
                    "startDate": "2024-01-15T09:30:00.000Z",
                    "expirationDate": "2024-01-15T09:30:00.000Z",
                    "isTargeted": true,
                    "minTransactionAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "maxTransactionAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "minRewardAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "maxRewardAmount": {
                      "type": "CENTS",
                      "value": 1
                    },
                    "websiteUrl": "websiteUrl",
                    "description": "description",
                    "components": {
                      "shortDescription": "shortDescription",
                      "longDescription": "longDescription",
                      "baseReward": "baseReward",
                      "boostedReward": "boostedReward",
                      "cta": {
                        "buttonText": "buttonText",
                        "buttonStyle": "PRIMARY",
                        "action": {
                          "url": "url",
                          "method": "method"
                        },
                        "startIcon": "startIcon"
                      },
                      "tags": [
                        "tags",
                        "tags"
                      ],
                      "detailTags": [
                        "detailTags",
                        "detailTags"
                      ],
                      "logoFlare": {
                        "borderColor": "PRIMARY",
                        "badge": {
                          "icon": "icon",
                          "position": "TOP_RIGHT"
                        }
                      },
                      "progressBar": {
                        "total": 1,
                        "currentProgress": 1,
                        "label": "label",
                        "segmented": true,
                        "labels": {
                          "details": {},
                          "default": {}
                        }
                      }
                    }
                  }
                }
              ],
              "links": {
                "self": "self",
                "prev": "prev",
                "next": "next"
              },
              "included": [
                {
                  "attributes": {
                    "name": "Arts & Entertainment"
                  },
                  "id": "id",
                  "type": "category"
                },
                {
                  "attributes": {
                    "name": "Arts & Entertainment"
                  },
                  "id": "id",
                  "type": "category"
                }
              ],
              "meta": {
                "availableCategories": [
                  {
                    "attributes": {
                      "name": "Arts & Entertainment"
                    },
                    "id": "id",
                    "type": "category"
                  },
                  {
                    "attributes": {
                      "name": "Arts & Entertainment"
                    },
                    "id": "id",
                    "type": "category"
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/issuers/organizationId/users/userId/placements/placementId/offers"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Rewards.PlacementOffersAsync(
            "organizationId",
            "userId",
            "placementId",
            new GetOffersByPlacementRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
