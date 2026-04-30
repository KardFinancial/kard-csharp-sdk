using global::System.Globalization;
using Kard;
using Kard.Core;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetEarnedRewardsResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "data": [
                {
                  "type": "approvedTransaction",
                  "id": "fcabf024-3870-41f3-9fbd-b43ea85a3d19",
                  "attributes": {
                    "status": "APPROVED",
                    "transactionId": "TXN-20241001-F21-127964",
                    "transactionAmountInCents": 12796,
                    "transactionTimestamp": "2024-10-01T01:36:57Z"
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
                    "transactionTimestamp": "2024-09-28T14:11:22Z",
                    "paidToIssuer": "PAID_IN_FULL",
                    "payoutTimestamp": "2024-09-29T10:15:00Z",
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
        var expectedObject = new GetEarnedRewardsResponse
        {
            Data = new List<RewardedTransactionUnion>()
            {
                new RewardedTransactionUnion(
                    new RewardedTransactionUnion.ApprovedTransaction(
                        new ApprovedTransaction
                        {
                            Id = "fcabf024-3870-41f3-9fbd-b43ea85a3d19",
                            Attributes = new ApprovedTransactionAttributes
                            {
                                Status = "APPROVED",
                                TransactionId = "TXN-20241001-F21-127964",
                                TransactionAmountInCents = 12796,
                                TransactionTimestamp = DateTime.Parse(
                                    "2024-10-01T01:36:57.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                            },
                            Relationships = new RewardedTransactionRelationships
                            {
                                User = new RelationshipSingle
                                {
                                    Data = new RelationshipData
                                    {
                                        Type = "user",
                                        Id = "8c52423a-c319-44ee-8fc7-508e97b43892",
                                    },
                                },
                                Merchant = new RelationshipSingle
                                {
                                    Data = new RelationshipData
                                    {
                                        Type = "merchant",
                                        Id = "633ed2ab30dcb60009dd5699",
                                    },
                                },
                                Offer = new RelationshipSingle
                                {
                                    Data = new RelationshipData
                                    {
                                        Type = "offer",
                                        Id = "OFF-F21-INSTORE-2024Q4-001",
                                    },
                                },
                            },
                        }
                    )
                ),
                new RewardedTransactionUnion(
                    new RewardedTransactionUnion.RewardedTransaction(
                        new RewardedTransaction
                        {
                            Id = "7bcbdb95-f3a5-4f56-a9be-4c25f313eb0a",
                            Attributes = new RewardedTransactionAttributes
                            {
                                Status = "SETTLED",
                                TransactionId = "TXN-20240928-TGT-778813",
                                TransactionAmountInCents = 8800,
                                TransactionTimestamp = DateTime.Parse(
                                    "2024-09-28T14:11:22.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                PaidToIssuer = PaymentStatus.PaidInFull,
                                PayoutTimestamp = DateTime.Parse(
                                    "2024-09-29T10:15:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                CommissionEarned = new CommissionEarnedDetails
                                {
                                    User = new CommissionValue
                                    {
                                        Type = CommissionValueType.Cents,
                                        Value = 220,
                                    },
                                },
                            },
                            Relationships = new RewardedTransactionRelationships
                            {
                                User = new RelationshipSingle
                                {
                                    Data = new RelationshipData
                                    {
                                        Type = "user",
                                        Id = "8c52423a-c319-44ee-8fc7-508e97b43892",
                                    },
                                },
                                Merchant = new RelationshipSingle
                                {
                                    Data = new RelationshipData
                                    {
                                        Type = "merchant",
                                        Id = "5f3e2d1c40abc50008cc4821",
                                    },
                                },
                                Offer = new RelationshipSingle
                                {
                                    Data = new RelationshipData
                                    {
                                        Type = "offer",
                                        Id = "OFF-TGT-ONLINE-2024Q4-002",
                                    },
                                },
                            },
                        }
                    )
                ),
            },
            Links = new Links
            {
                Self = "/v2/issuers/org-123/users/user-456/earned-rewards?page[size]=10",
                Next =
                    "/v2/issuers/org-123/users/user-456/earned-rewards?page[size]=10&page[after]=eyJpZCI6ImZjYWJmMDI0LTM4NzAtNDFmMy05ZmJkLWI0M2VhODVhM2QxOSIsInRzIjoiMjAyNC0xMC0wMVQwMTozNjo1N1oifQ==",
            },
            Meta = new GetEarnedRewardsMeta { LifetimeRewardsInCents = 540 },
            Included = new List<TransactionIncludedResource>()
            {
                new TransactionIncludedResource(
                    new TransactionIncludedResource.Merchant(
                        new TransactionMerchantResource
                        {
                            Id = "633ed2ab30dcb60009dd5699",
                            Attributes = new TransactionMerchantAttributes
                            {
                                Name = "Forever 21",
                                Assets = new List<MerchantAsset>()
                                {
                                    new MerchantAsset
                                    {
                                        Type = MerchantAssetType.ImgView,
                                        Url =
                                            "https://attribution.getkard.com/public/logos/forever21.jpg?subtype=IMG_VIEW&offerId=OFF-F21-INSTORE-2024Q4-001&token=signed-token",
                                        Alt = "Forever 21 Logo Image",
                                    },
                                    new MerchantAsset
                                    {
                                        Type = MerchantAssetType.BannerView,
                                        Url =
                                            "https://attribution.getkard.com/public/banners/forever21.jpg?subtype=BANNER_VIEW&offerId=OFF-F21-INSTORE-2024Q4-001&token=signed-token",
                                        Alt = "Forever 21 Banner Image",
                                    },
                                },
                            },
                        }
                    )
                ),
                new TransactionIncludedResource(
                    new TransactionIncludedResource.Merchant(
                        new TransactionMerchantResource
                        {
                            Id = "5f3e2d1c40abc50008cc4821",
                            Attributes = new TransactionMerchantAttributes
                            {
                                Name = "Target",
                                Assets = new List<MerchantAsset>()
                                {
                                    new MerchantAsset
                                    {
                                        Type = MerchantAssetType.ImgView,
                                        Url =
                                            "https://attribution.getkard.com/public/logos/target.jpg?subtype=IMG_VIEW&offerId=OFF-TGT-ONLINE-2024Q4-002&token=signed-token",
                                        Alt = "Target Logo Image",
                                    },
                                },
                            },
                        }
                    )
                ),
                new TransactionIncludedResource(
                    new TransactionIncludedResource.Offer(
                        new TransactionOfferResource
                        {
                            Id = "OFF-F21-INSTORE-2024Q4-001",
                            Attributes = new TransactionOfferAttributes
                            {
                                PurchaseChannel = new List<string>() { "INSTORE" },
                            },
                        }
                    )
                ),
                new TransactionIncludedResource(
                    new TransactionIncludedResource.Offer(
                        new TransactionOfferResource
                        {
                            Id = "OFF-TGT-ONLINE-2024Q4-002",
                            Attributes = new TransactionOfferAttributes
                            {
                                PurchaseChannel = new List<string>() { "ONLINE" },
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<GetEarnedRewardsResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var inputJson = """
            {
              "data": [
                {
                  "type": "approvedTransaction",
                  "id": "fcabf024-3870-41f3-9fbd-b43ea85a3d19",
                  "attributes": {
                    "status": "APPROVED",
                    "transactionId": "TXN-20241001-F21-127964",
                    "transactionAmountInCents": 12796,
                    "transactionTimestamp": "2024-10-01T01:36:57Z"
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
                    "transactionTimestamp": "2024-09-28T14:11:22Z",
                    "paidToIssuer": "PAID_IN_FULL",
                    "payoutTimestamp": "2024-09-29T10:15:00Z",
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
        JsonAssert.Roundtrips<GetEarnedRewardsResponse>(inputJson);
    }
}
