using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Users.Rewards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlacementContentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "standardOffer",
                  "id": "5e27318c9b346f00087fbb5c",
                  "attributes": {
                    "name": "World's Greatest Chicken",
                    "terms": "Offer valid at US locations only.",
                    "purchaseChannel": [
                      "INSTORE"
                    ],
                    "userReward": {
                      "type": "PERCENT",
                      "value": 5.7
                    },
                    "startDate": "2024-11-17T05:00:00.000Z",
                    "expirationDate": "2025-03-17T05:00:00.000Z",
                    "isTargeted": true,
                    "assets": [
                      {
                        "type": "IMG_VIEW",
                        "url": "https://attribution.getkard.com/logos/wgc_logo.png?token=example",
                        "alt": ""
                      }
                    ],
                    "websiteUrl": "https://worldsgreatestchicken.test.com",
                    "description": "Crispy, double-fried spicy chicken."
                  },
                  "relationships": {
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
                }
              ],
              "links": {
                "self": "/v2/issuers/organization-123/users/user-123/placements/placement-homepage-banner/content"
              },
              "meta": {
                "placementName": "Homepage Banner",
                "availableCategories": [
                  {
                    "type": "category",
                    "id": "65920081b524d126068de24a",
                    "attributes": {
                      "name": "Food & Beverage"
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
                    .WithPath(
                        "/v2/issuers/organization-123/users/user-123/placements/placement-homepage-banner/content"
                    )
                    .WithParam("include", "categories")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Rewards.PlacementContentAsync(
            "organization-123",
            "user-123",
            "placement-homepage-banner",
            new GetPlacementContentRequest { Include = ["categories"] }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "placementBatch",
                  "id": "slot-newly-live",
                  "attributes": {
                    "name": "Newly Live",
                    "isActive": true,
                    "lastActivatedAt": "2026-05-20T06:00:00.000Z",
                    "expiresAt": "2026-05-21T06:00:00.000Z",
                    "assets": [],
                    "offers": [
                      {
                        "type": "standardOffer",
                        "id": "5e27318c9b346f00087fbb5c",
                        "attributes": {
                          "name": "World's Greatest Chicken",
                          "terms": "Offer valid at US locations only.",
                          "purchaseChannel": [
                            "INSTORE"
                          ],
                          "userReward": {
                            "type": "PERCENT",
                            "value": 5.7
                          },
                          "startDate": "2024-11-17T05:00:00.000Z",
                          "expirationDate": "2025-03-17T05:00:00.000Z",
                          "isTargeted": false,
                          "assets": []
                        }
                      }
                    ]
                  }
                },
                {
                  "type": "placementBatch",
                  "id": "slot-travel",
                  "attributes": {
                    "name": "Travel",
                    "isActive": true,
                    "assets": [],
                    "offers": []
                  }
                }
              ],
              "meta": {
                "placementName": "Weekly Bundles"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/issuers/organization-123/users/user-123/placements/placement-weekly-bundles/content"
                    )
                    .WithParam("supportedComponents", "baseReward")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Rewards.PlacementContentAsync(
            "organization-123",
            "user-123",
            "placement-weekly-bundles",
            new GetPlacementContentRequest { SupportedComponents = [ComponentType.BaseReward] }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
