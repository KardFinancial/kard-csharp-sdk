using global::System.Globalization;
using KardFinancial;
using KardFinancial.Core;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class NotificationPayloadTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "data": {
                "id": "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                "type": "earnedRewardSettled",
                "attributes": {
                  "message": "You have earned a 72 cent reward on your transaction at McDonald's",
                  "name": "McDonald's",
                  "commissionEarned": {
                    "type": "cents",
                    "value": 72
                  },
                  "attributionUrl": "www.attribution.com/token",
                  "surveyUrl": "www.survey.com",
                  "cardProductId": "card_product_123",
                  "transactionTimestamp": "2024-10-01T14:32:10.000Z",
                  "transactionId": "019df940-babd-7cd3-acfc-a96de16643e9",
                  "transactionAmountInCents": 3000
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.EarnedRewardSettled(
                    new EarnedRewardSettledData
                    {
                        Id = "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                        Attributes = new EarnedRewardSettledAttributes
                        {
                            Message =
                                "You have earned a 72 cent reward on your transaction at McDonald's",
                            Name = "McDonald's",
                            CommissionEarned = new CommissionValue
                            {
                                Type = CommissionValueType.Cents,
                                Value = 72,
                            },
                            AttributionUrl = "www.attribution.com/token",
                            SurveyUrl = "www.survey.com",
                            CardProductId = "card_product_123",
                            TransactionTimestamp = DateTime.Parse(
                                "2024-10-01T14:32:10.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            TransactionId = "019df940-babd-7cd3-acfc-a96de16643e9",
                            TransactionAmountInCents = 3000,
                        },
                        Relationships = new EarnedRewardRelationships
                        {
                            User = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "user", Id = "1234567890" },
                            },
                            Transaction = new RelationshipSingle
                            {
                                Data = new RelationshipData
                                {
                                    Type = "transaction",
                                    Id = "0987654321",
                                },
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var inputJson = """
            {
              "data": {
                "id": "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                "type": "earnedRewardSettled",
                "attributes": {
                  "message": "You have earned a 72 cent reward on your transaction at McDonald's",
                  "name": "McDonald's",
                  "commissionEarned": {
                    "type": "cents",
                    "value": 72
                  },
                  "attributionUrl": "www.attribution.com/token",
                  "surveyUrl": "www.survey.com",
                  "cardProductId": "card_product_123",
                  "transactionTimestamp": "2024-10-01T14:32:10.000Z",
                  "transactionId": "019df940-babd-7cd3-acfc-a96de16643e9",
                  "transactionAmountInCents": 3000
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
              "data": {
                "id": "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                "type": "earnedRewardApproved",
                "attributes": {
                  "message": "Thanks for shopping at McDonald's! We're checking to see if your purchase qualifies for cash back.",
                  "name": "McDonald's",
                  "attributionUrl": "www.attribution.com/token",
                  "surveyUrl": "www.survey.com",
                  "cardProductId": "card_product_123",
                  "transactionTimestamp": "2024-10-01T14:32:10.000Z",
                  "transactionId": "019df940-babd-7cd3-acfc-a96de16643e9",
                  "transactionAmountInCents": 3000
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.EarnedRewardApproved(
                    new EarnedRewardApprovedData
                    {
                        Id = "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                        Attributes = new RewardNotificationAttributes
                        {
                            Message =
                                "Thanks for shopping at McDonald's! We're checking to see if your purchase qualifies for cash back.",
                            Name = "McDonald's",
                            AttributionUrl = "www.attribution.com/token",
                            SurveyUrl = "www.survey.com",
                            CardProductId = "card_product_123",
                            TransactionTimestamp = DateTime.Parse(
                                "2024-10-01T14:32:10.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            TransactionId = "019df940-babd-7cd3-acfc-a96de16643e9",
                            TransactionAmountInCents = 3000,
                        },
                        Relationships = new EarnedRewardRelationships
                        {
                            User = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "user", Id = "1234567890" },
                            },
                            Transaction = new RelationshipSingle
                            {
                                Data = new RelationshipData
                                {
                                    Type = "transaction",
                                    Id = "0987654321",
                                },
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var inputJson = """
            {
              "data": {
                "id": "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                "type": "earnedRewardApproved",
                "attributes": {
                  "message": "Thanks for shopping at McDonald's! We're checking to see if your purchase qualifies for cash back.",
                  "name": "McDonald's",
                  "attributionUrl": "www.attribution.com/token",
                  "surveyUrl": "www.survey.com",
                  "cardProductId": "card_product_123",
                  "transactionTimestamp": "2024-10-01T14:32:10.000Z",
                  "transactionId": "019df940-babd-7cd3-acfc-a96de16643e9",
                  "transactionAmountInCents": 3000
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_3()
    {
        var json = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "validTransaction",
                "attributes": {
                  "message": "Your transaction at Amazon has been validated successfully.",
                  "name": "Amazon",
                  "commissionEarned": {
                    "issuer": {
                      "type": "cents",
                      "value": 100
                    },
                    "user": {
                      "type": "cents",
                      "value": 320
                    }
                  },
                  "attributionUrl": "www.attribution.com/token",
                  "surveyUrl": "www.survey.com",
                  "cardProductId": "card_product_123",
                  "transactionId": "019df940-babd-7cd3-acfc-a96de16643e9",
                  "transactionAmountInCents": 3000
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "offer": {
                    "data": {
                      "type": "offer",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.ValidTransaction(
                    new ValidTransactionData
                    {
                        Id = "a12b34c56d78e90f1234",
                        Attributes = new ValidTransactionAttributes
                        {
                            Message = "Your transaction at Amazon has been validated successfully.",
                            Name = "Amazon",
                            CommissionEarned = new ValidTransactionCommissionEarned
                            {
                                Issuer = new CommissionValue
                                {
                                    Type = CommissionValueType.Cents,
                                    Value = 100,
                                },
                                User = new CommissionValue
                                {
                                    Type = CommissionValueType.Cents,
                                    Value = 320,
                                },
                            },
                            AttributionUrl = "www.attribution.com/token",
                            SurveyUrl = "www.survey.com",
                            CardProductId = "card_product_123",
                            TransactionId = "019df940-babd-7cd3-acfc-a96de16643e9",
                            TransactionAmountInCents = 3000,
                        },
                        Relationships = new TransactionRelationships
                        {
                            User = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "user", Id = "9876543210" },
                            },
                            Offer = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "offer", Id = "1234567890" },
                            },
                            Transaction = new RelationshipSingle
                            {
                                Data = new RelationshipData
                                {
                                    Type = "transaction",
                                    Id = "0987654321",
                                },
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_3()
    {
        var inputJson = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "validTransaction",
                "attributes": {
                  "message": "Your transaction at Amazon has been validated successfully.",
                  "name": "Amazon",
                  "commissionEarned": {
                    "issuer": {
                      "type": "cents",
                      "value": 100
                    },
                    "user": {
                      "type": "cents",
                      "value": 320
                    }
                  },
                  "attributionUrl": "www.attribution.com/token",
                  "surveyUrl": "www.survey.com",
                  "cardProductId": "card_product_123",
                  "transactionId": "019df940-babd-7cd3-acfc-a96de16643e9",
                  "transactionAmountInCents": 3000
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "offer": {
                    "data": {
                      "type": "offer",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_4()
    {
        var json = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "failedTransaction",
                "attributes": {
                  "message": "Transaction validation failed",
                  "reason": "User is not part of the targeted audience eligible to redeem this offer",
                  "name": "Walmart",
                  "cardProductId": "card_product_123"
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "offer": {
                    "data": {
                      "type": "offer",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.FailedTransaction(
                    new FailedTransactionData
                    {
                        Id = "a12b34c56d78e90f1234",
                        Attributes = new FailedTransactionAttributes
                        {
                            Message = "Transaction validation failed",
                            Reason =
                                "User is not part of the targeted audience eligible to redeem this offer",
                            Name = "Walmart",
                            CardProductId = "card_product_123",
                        },
                        Relationships = new FailedTransactionRelationships
                        {
                            User = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "user", Id = "9876543210" },
                            },
                            Offer = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "offer", Id = "1234567890" },
                            },
                            Transaction = new RelationshipSingle
                            {
                                Data = new RelationshipData
                                {
                                    Type = "transaction",
                                    Id = "0987654321",
                                },
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_4()
    {
        var inputJson = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "failedTransaction",
                "attributes": {
                  "message": "Transaction validation failed",
                  "reason": "User is not part of the targeted audience eligible to redeem this offer",
                  "name": "Walmart",
                  "cardProductId": "card_product_123"
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "offer": {
                    "data": {
                      "type": "offer",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_5()
    {
        var json = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "clawback",
                "attributes": {
                  "message": "Transaction has been marked for clawback",
                  "reason": "This transaction was previously rewarded in another system",
                  "name": "Starbucks",
                  "cardProductId": "card_product_123"
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "offer": {
                    "data": {
                      "type": "offer",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.Clawback(
                    new ClawbackData
                    {
                        Id = "a12b34c56d78e90f1234",
                        Attributes = new FailedTransactionAttributes
                        {
                            Message = "Transaction has been marked for clawback",
                            Reason = "This transaction was previously rewarded in another system",
                            Name = "Starbucks",
                            CardProductId = "card_product_123",
                        },
                        Relationships = new FailedTransactionRelationships
                        {
                            User = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "user", Id = "9876543210" },
                            },
                            Offer = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "offer", Id = "1234567890" },
                            },
                            Transaction = new RelationshipSingle
                            {
                                Data = new RelationshipData
                                {
                                    Type = "transaction",
                                    Id = "0987654321",
                                },
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_5()
    {
        var inputJson = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "clawback",
                "attributes": {
                  "message": "Transaction has been marked for clawback",
                  "reason": "This transaction was previously rewarded in another system",
                  "name": "Starbucks",
                  "cardProductId": "card_product_123"
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "offer": {
                    "data": {
                      "type": "offer",
                      "id": "1234567890"
                    }
                  },
                  "transaction": {
                    "data": {
                      "type": "transaction",
                      "id": "0987654321"
                    }
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_6()
    {
        var json = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "auditUpdate",
                "attributes": {
                  "status": "IN_PROGRESS",
                  "auditCode": 8001,
                  "merchantName": "Caribbean Goodness",
                  "auditDescription": "duplicate",
                  "transactionId": "txn-123"
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "audit": {
                    "data": {
                      "type": "audit",
                      "id": "5eb2d4a39ce24e00081488c4"
                    }
                  }
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.AuditUpdate(
                    new AuditUpdateData
                    {
                        Id = "a12b34c56d78e90f1234",
                        Attributes = new AuditUpdateAttributes
                        {
                            Status = AuditStatus.InProgress,
                            AuditCode = 8001,
                            MerchantName = "Caribbean Goodness",
                            AuditDescription = "duplicate",
                            TransactionId = "txn-123",
                        },
                        Relationships = new AuditUpdateRelationships
                        {
                            User = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "user", Id = "9876543210" },
                            },
                            Audit = new RelationshipSingle
                            {
                                Data = new RelationshipData
                                {
                                    Type = "audit",
                                    Id = "5eb2d4a39ce24e00081488c4",
                                },
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_6()
    {
        var inputJson = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "auditUpdate",
                "attributes": {
                  "status": "IN_PROGRESS",
                  "auditCode": 8001,
                  "merchantName": "Caribbean Goodness",
                  "auditDescription": "duplicate",
                  "transactionId": "txn-123"
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "audit": {
                    "data": {
                      "type": "audit",
                      "id": "5eb2d4a39ce24e00081488c4"
                    }
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_7()
    {
        var json = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "auditUpdate",
                "attributes": {
                  "status": "CLOSED",
                  "auditCode": 3006,
                  "merchantName": "Caribbean Goodness",
                  "auditDescription": "reward was not given for offer",
                  "transactionId": "txn-123",
                  "resolutionDescription": "offer had expired",
                  "resolutionTimeStamp": "2022-09-15T19:03:26.236Z",
                  "resolutionCode": 9003
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "audit": {
                    "data": {
                      "type": "audit",
                      "id": "5eb2d4a39ce24e00081488c4"
                    }
                  }
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.AuditUpdate(
                    new AuditUpdateData
                    {
                        Id = "a12b34c56d78e90f1234",
                        Attributes = new AuditUpdateAttributes
                        {
                            Status = AuditStatus.Closed,
                            AuditCode = 3006,
                            MerchantName = "Caribbean Goodness",
                            AuditDescription = "reward was not given for offer",
                            TransactionId = "txn-123",
                            ResolutionDescription = "offer had expired",
                            ResolutionTimeStamp = DateTime.Parse(
                                "2022-09-15T19:03:26.236Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            ResolutionCode = 9003,
                        },
                        Relationships = new AuditUpdateRelationships
                        {
                            User = new RelationshipSingle
                            {
                                Data = new RelationshipData { Type = "user", Id = "9876543210" },
                            },
                            Audit = new RelationshipSingle
                            {
                                Data = new RelationshipData
                                {
                                    Type = "audit",
                                    Id = "5eb2d4a39ce24e00081488c4",
                                },
                            },
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_7()
    {
        var inputJson = """
            {
              "data": {
                "id": "a12b34c56d78e90f1234",
                "type": "auditUpdate",
                "attributes": {
                  "status": "CLOSED",
                  "auditCode": 3006,
                  "merchantName": "Caribbean Goodness",
                  "auditDescription": "reward was not given for offer",
                  "transactionId": "txn-123",
                  "resolutionDescription": "offer had expired",
                  "resolutionTimeStamp": "2022-09-15T19:03:26.236Z",
                  "resolutionCode": 9003
                },
                "relationships": {
                  "user": {
                    "data": {
                      "type": "user",
                      "id": "9876543210"
                    }
                  },
                  "audit": {
                    "data": {
                      "type": "audit",
                      "id": "5eb2d4a39ce24e00081488c4"
                    }
                  }
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_8()
    {
        var json = """
            {
              "data": {
                "id": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
                "type": "fileProcessingResult",
                "attributes": {
                  "fileName": "incomingTxns_2026-06-23.jsonl",
                  "lastModified": "2026-06-23T12:00:00Z",
                  "sentAt": "2026-06-23T12:05:00Z",
                  "downloadUrl": "https://example.com/processed/incomingTxns_2026-06-23.csv"
                }
              }
            }
            """;
        var expectedObject = new NotificationPayload
        {
            Data = new NotificationDataUnion(
                new NotificationDataUnion.FileProcessingResult(
                    new FileResultData
                    {
                        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
                        Attributes = new FileMetadataAttribute
                        {
                            FileName = "incomingTxns_2026-06-23.jsonl",
                            LastModified = "2026-06-23T12:00:00Z",
                            SentAt = "2026-06-23T12:05:00Z",
                            DownloadUrl =
                                "https://example.com/processed/incomingTxns_2026-06-23.csv",
                        },
                    }
                )
            ),
        };
        var deserializedObject = JsonUtils.Deserialize<NotificationPayload>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_8()
    {
        var inputJson = """
            {
              "data": {
                "id": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
                "type": "fileProcessingResult",
                "attributes": {
                  "fileName": "incomingTxns_2026-06-23.jsonl",
                  "lastModified": "2026-06-23T12:00:00Z",
                  "sentAt": "2026-06-23T12:05:00Z",
                  "downloadUrl": "https://example.com/processed/incomingTxns_2026-06-23.csv"
                }
              }
            }
            """;
        JsonAssert.Roundtrips<NotificationPayload>(inputJson);
    }
}
