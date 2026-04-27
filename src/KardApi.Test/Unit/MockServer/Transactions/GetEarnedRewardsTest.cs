using KardApi;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Transactions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetEarnedRewardsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "approvedTransaction",
                  "id": "fcabf024-3870-41f3-9fbd-b43ea85a3d19",
                  "attributes": {
                    "status": "APPROVED",
                    "transactionId": "TXN-20241001-F21-127964",
                    "transactionAmountInCents": 12796,
                    "transactionTimestamp": "2024-10-01T01:36:57.000Z"
                  },
                  "relationships": {
                    "user": {
                      "data": {
                        "type": "user",
                        "id": "8c52423a-c319-44ee-8fc7-508e97b43892"
                      }
                    },
                    "merchant": {
                      "data": {
                        "type": "merchant",
                        "id": "633ed2ab30dcb60009dd5699"
                      }
                    },
                    "offer": {
                      "data": {
                        "type": "offer",
                        "id": "OFF-F21-INSTORE-2024Q4-001"
                      }
                    }
                  }
                },
                {
                  "type": "rewardedTransaction",
                  "id": "7bcbdb95-f3a5-4f56-a9be-4c25f313eb0a",
                  "attributes": {
                    "status": "SETTLED",
                    "transactionId": "TXN-20240928-TGT-778813",
                    "transactionAmountInCents": 8800,
                    "transactionTimestamp": "2024-09-28T14:11:22.000Z",
                    "paidToIssuer": "PAID_IN_FULL",
                    "payoutTimestamp": "2024-09-29T10:15:00.000Z",
                    "commissionEarned": {
                      "user": {
                        "type": "cents",
                        "value": 220
                      }
                    }
                  },
                  "relationships": {
                    "user": {
                      "data": {
                        "type": "user",
                        "id": "8c52423a-c319-44ee-8fc7-508e97b43892"
                      }
                    },
                    "merchant": {
                      "data": {
                        "type": "merchant",
                        "id": "5f3e2d1c40abc50008cc4821"
                      }
                    },
                    "offer": {
                      "data": {
                        "type": "offer",
                        "id": "OFF-TGT-ONLINE-2024Q4-002"
                      }
                    }
                  }
                }
              ],
              "links": {
                "self": "/v2/issuers/org-123/users/user-456/earned-rewards?page[size]=10",
                "next": "/v2/issuers/org-123/users/user-456/earned-rewards?page[size]=10&page[after]=eyJpZCI6ImZjYWJmMDI0LTM4NzAtNDFmMy05ZmJkLWI0M2VhODVhM2QxOSIsInRzIjoiMjAyNC0xMC0wMVQwMTozNjo1N1oifQ=="
              },
              "meta": {
                "lifetimeRewardsInCents": 540
              },
              "included": [
                {
                  "type": "merchant",
                  "id": "633ed2ab30dcb60009dd5699",
                  "attributes": {
                    "name": "Forever 21",
                    "assets": [
                      {
                        "type": "IMG_VIEW",
                        "url": "https://attribution.getkard.com/public/logos/forever21.jpg?subtype=IMG_VIEW&offerId=OFF-F21-INSTORE-2024Q4-001&token=signed-token",
                        "alt": "Forever 21 Logo Image"
                      },
                      {
                        "type": "BANNER_VIEW",
                        "url": "https://attribution.getkard.com/public/banners/forever21.jpg?subtype=BANNER_VIEW&offerId=OFF-F21-INSTORE-2024Q4-001&token=signed-token",
                        "alt": "Forever 21 Banner Image"
                      }
                    ]
                  }
                },
                {
                  "type": "merchant",
                  "id": "5f3e2d1c40abc50008cc4821",
                  "attributes": {
                    "name": "Target",
                    "assets": [
                      {
                        "type": "IMG_VIEW",
                        "url": "https://attribution.getkard.com/public/logos/target.jpg?subtype=IMG_VIEW&offerId=OFF-TGT-ONLINE-2024Q4-002&token=signed-token",
                        "alt": "Target Logo Image"
                      }
                    ]
                  }
                },
                {
                  "type": "offer",
                  "id": "OFF-F21-INSTORE-2024Q4-001",
                  "attributes": {
                    "purchaseChannel": [
                      "INSTORE"
                    ]
                  }
                },
                {
                  "type": "offer",
                  "id": "OFF-TGT-ONLINE-2024Q4-002",
                  "attributes": {
                    "purchaseChannel": [
                      "ONLINE"
                    ]
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/org-123/users/user-456/earned-rewards")
                    .WithParam("page[size]", "10")
                    .WithParam("filter[status]", "APPROVED")
                    .WithParam("include", "merchant,offer")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Transactions.GetEarnedRewardsAsync(
            "org-123",
            "user-456",
            new GetEarnedRewardsRequest
            {
                PageSize = 10,
                FilterStatus = RewardedTransactionStatus.Approved,
                Include = "merchant,offer",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
