using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Users.Rewards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlacementBatchesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "slotId": "slotId",
                  "alias": "alias",
                  "isActive": true,
                  "lastActivatedAt": "2024-01-15T09:30:00.000Z",
                  "expiresAt": "2024-01-15T09:30:00.000Z",
                  "offers": [
                    {
                      "type": "standardOffer",
                      "relationships": {
                        "category": {
                          "data": []
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
                            "buttonStyle": "PRIMARY"
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
                            "borderColor": "PRIMARY"
                          }
                        }
                      }
                    },
                    {
                      "type": "standardOffer",
                      "relationships": {
                        "category": {
                          "data": []
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
                            "buttonStyle": "PRIMARY"
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
                            "borderColor": "PRIMARY"
                          }
                        }
                      }
                    }
                  ]
                },
                {
                  "slotId": "slotId",
                  "alias": "alias",
                  "isActive": true,
                  "lastActivatedAt": "2024-01-15T09:30:00.000Z",
                  "expiresAt": "2024-01-15T09:30:00.000Z",
                  "offers": [
                    {
                      "type": "standardOffer",
                      "relationships": {
                        "category": {
                          "data": []
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
                            "buttonStyle": "PRIMARY"
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
                            "borderColor": "PRIMARY"
                          }
                        }
                      }
                    },
                    {
                      "type": "standardOffer",
                      "relationships": {
                        "category": {
                          "data": []
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
                            "buttonStyle": "PRIMARY"
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
                            "borderColor": "PRIMARY"
                          }
                        }
                      }
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/issuers/organizationId/users/userId/placements/placementId/batches"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Rewards.PlacementBatchesAsync(
            "organizationId",
            "userId",
            "placementId",
            new GetBatchesByPlacementRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
