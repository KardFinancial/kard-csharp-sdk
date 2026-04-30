using global::System.Globalization;
using Kard;
using Kard.Core;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TransactionsRequestBodyTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
            {
              "data": [
                {
                  "id": "309rjfoincor3icno3rind093cdow3jciwjdwcm",
                  "type": "transaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "status": "APPROVED",
                    "amount": 1000,
                    "subtotal": 800,
                    "currency": "USD",
                    "direction": "DEBIT",
                    "paymentType": "CARD",
                    "description": "ADVANCEAUTO",
                    "description2": "ADVANCEAUTO",
                    "mcc": "1234",
                    "cardBIN": "123456",
                    "cardLastFour": "4321",
                    "authorizationDate": "2021-07-02T17:47:06Z",
                    "merchant": {
                      "id": "12345678901234567",
                      "name": "ADVANCEAUTO",
                      "addrStreet": "125 Main St",
                      "addrCity": "Philadelphia",
                      "addrState": "PA",
                      "addrZipcode": "19147",
                      "addrCountry": "United States",
                      "latitude": "37.9419429",
                      "longitude": "-73.1446869",
                      "storeId": "12345"
                    },
                    "authorizationCode": "123456",
                    "retrievalReferenceNumber": "100804333919",
                    "acquirerReferenceNumber": "1234567890123456789012345678",
                    "systemTraceAuditNumber": "333828",
                    "transactionId": "2467de37-cbdc-416d-a359-75de87bfffb0",
                    "cardProductId": "1234567890123456789012345678",
                    "processorMids": {
                      "processor": "VISA",
                      "mids": {
                        "vmid": "12345678901",
                        "vsid": "12345678"
                      }
                    }
                  }
                }
              ]
            }
            """;
        var expectedObject = new TransactionsRequestBody
        {
            Data = new List<Transactions>()
            {
                new Transactions(
                    new Transactions.Transaction(
                        new TransactionsRequest
                        {
                            Id = "309rjfoincor3icno3rind093cdow3jciwjdwcm",
                            Attributes = new TransactionsAttributes
                            {
                                UserId = "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                                Status = TransactionStatus.Approved,
                                Amount = 1000,
                                Subtotal = 800,
                                Currency = "USD",
                                Direction = DirectionType.Debit,
                                PaymentType = TransactionPaymentType.Card,
                                Description = "ADVANCEAUTO",
                                Description2 = "ADVANCEAUTO",
                                Mcc = "1234",
                                CardBin = "123456",
                                CardLastFour = "4321",
                                AuthorizationDate = DateTime.Parse(
                                    "2021-07-02T17:47:06.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                Merchant = new Merchant
                                {
                                    Id = "12345678901234567",
                                    Name = "ADVANCEAUTO",
                                    AddrStreet = "125 Main St",
                                    AddrCity = "Philadelphia",
                                    AddrState = States.Pa,
                                    AddrZipcode = "19147",
                                    AddrCountry = "United States",
                                    Latitude = "37.9419429",
                                    Longitude = "-73.1446869",
                                    StoreId = "12345",
                                },
                                AuthorizationCode = "123456",
                                RetrievalReferenceNumber = "100804333919",
                                AcquirerReferenceNumber = "1234567890123456789012345678",
                                SystemTraceAuditNumber = "333828",
                                TransactionId = "2467de37-cbdc-416d-a359-75de87bfffb0",
                                CardProductId = "1234567890123456789012345678",
                                ProcessorMids = new ProcessorMid(
                                    new ProcessorMid.Visa(
                                        new VisaMid
                                        {
                                            Mids = new VisaMidDetails
                                            {
                                                Vmid = "12345678901",
                                                Vsid = "12345678",
                                            },
                                        }
                                    )
                                ),
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransactionsRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var inputJson = """
            {
              "data": [
                {
                  "id": "309rjfoincor3icno3rind093cdow3jciwjdwcm",
                  "type": "transaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "status": "APPROVED",
                    "amount": 1000,
                    "subtotal": 800,
                    "currency": "USD",
                    "direction": "DEBIT",
                    "paymentType": "CARD",
                    "description": "ADVANCEAUTO",
                    "description2": "ADVANCEAUTO",
                    "mcc": "1234",
                    "cardBIN": "123456",
                    "cardLastFour": "4321",
                    "authorizationDate": "2021-07-02T17:47:06Z",
                    "merchant": {
                      "id": "12345678901234567",
                      "name": "ADVANCEAUTO",
                      "addrStreet": "125 Main St",
                      "addrCity": "Philadelphia",
                      "addrState": "PA",
                      "addrZipcode": "19147",
                      "addrCountry": "United States",
                      "latitude": "37.9419429",
                      "longitude": "-73.1446869",
                      "storeId": "12345"
                    },
                    "authorizationCode": "123456",
                    "retrievalReferenceNumber": "100804333919",
                    "acquirerReferenceNumber": "1234567890123456789012345678",
                    "systemTraceAuditNumber": "333828",
                    "transactionId": "2467de37-cbdc-416d-a359-75de87bfffb0",
                    "cardProductId": "1234567890123456789012345678",
                    "processorMids": {
                      "processor": "VISA",
                      "mids": {
                        "vmid": "12345678901",
                        "vsid": "12345678"
                      }
                    }
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<TransactionsRequestBody>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
            {
              "data": [
                {
                  "id": "soduinfwoer82498h248h298heo2eic",
                  "type": "matchedTransaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "amount": 1000,
                    "subtotal": 800,
                    "description": "ADVANCEAUTO",
                    "authorizationDate": "2021-07-02T17:47:06Z",
                    "paymentType": "CARD",
                    "matchedOfferId": "5eb2d4a39ce24e00081488c4",
                    "matchedLocationId": "5eb2d4a39ce24e00081488d5",
                    "cardBIN": "12345",
                    "direction": "DEBIT",
                    "merchant": {
                      "id": "12345678901234567",
                      "name": "ADVANCEAUTO",
                      "addrStreet": "125 Main St",
                      "addrCity": "Philadephia",
                      "addrState": "PA",
                      "addrZipcode": "19147",
                      "addrCountry": "United States"
                    },
                    "cardLastFour": "4321",
                    "authorizationCode": "1234",
                    "retrievalReferenceNumber": "100804333919",
                    "systemTraceAuditNumber": "333828",
                    "acquirerReferenceNumber": "1234567890123456789012345678",
                    "transactionId": "2467de37-cbdc-416d-a359-75de87bfffb0",
                    "cardProductId": "1234567890123456789012345678",
                    "orderId": "23q49807iklasdf238904",
                    "receiptMedium": "ELECTRONIC"
                  }
                }
              ]
            }
            """;
        var expectedObject = new TransactionsRequestBody
        {
            Data = new List<Transactions>()
            {
                new Transactions(
                    new Transactions.MatchedTransaction(
                        new MatchedTransactionsRequest
                        {
                            Id = "soduinfwoer82498h248h298heo2eic",
                            Attributes = new MatchedTransactionsAttributes
                            {
                                UserId = "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                                Amount = 1000,
                                Subtotal = 800,
                                Description = "ADVANCEAUTO",
                                AuthorizationDate = DateTime.Parse(
                                    "2021-07-02T17:47:06.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                PaymentType = PaymentType.Card,
                                MatchedOfferId = "5eb2d4a39ce24e00081488c4",
                                MatchedLocationId = "5eb2d4a39ce24e00081488d5",
                                CardBin = "12345",
                                Direction = DirectionType.Debit,
                                Merchant = new Merchant
                                {
                                    Id = "12345678901234567",
                                    Name = "ADVANCEAUTO",
                                    AddrStreet = "125 Main St",
                                    AddrCity = "Philadephia",
                                    AddrState = States.Pa,
                                    AddrZipcode = "19147",
                                    AddrCountry = "United States",
                                },
                                CardLastFour = "4321",
                                AuthorizationCode = "1234",
                                RetrievalReferenceNumber = "100804333919",
                                SystemTraceAuditNumber = "333828",
                                AcquirerReferenceNumber = "1234567890123456789012345678",
                                TransactionId = "2467de37-cbdc-416d-a359-75de87bfffb0",
                                CardProductId = "1234567890123456789012345678",
                                OrderId = "23q49807iklasdf238904",
                                ReceiptMedium = ReceiptMediumType.Electronic,
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransactionsRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var inputJson = """
            {
              "data": [
                {
                  "id": "soduinfwoer82498h248h298heo2eic",
                  "type": "matchedTransaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "amount": 1000,
                    "subtotal": 800,
                    "description": "ADVANCEAUTO",
                    "authorizationDate": "2021-07-02T17:47:06Z",
                    "paymentType": "CARD",
                    "matchedOfferId": "5eb2d4a39ce24e00081488c4",
                    "matchedLocationId": "5eb2d4a39ce24e00081488d5",
                    "cardBIN": "12345",
                    "direction": "DEBIT",
                    "merchant": {
                      "id": "12345678901234567",
                      "name": "ADVANCEAUTO",
                      "addrStreet": "125 Main St",
                      "addrCity": "Philadephia",
                      "addrState": "PA",
                      "addrZipcode": "19147",
                      "addrCountry": "United States"
                    },
                    "cardLastFour": "4321",
                    "authorizationCode": "1234",
                    "retrievalReferenceNumber": "100804333919",
                    "systemTraceAuditNumber": "333828",
                    "acquirerReferenceNumber": "1234567890123456789012345678",
                    "transactionId": "2467de37-cbdc-416d-a359-75de87bfffb0",
                    "cardProductId": "1234567890123456789012345678",
                    "orderId": "23q49807iklasdf238904",
                    "receiptMedium": "ELECTRONIC"
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<TransactionsRequestBody>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_3()
    {
        var json = """
            {
              "data": [
                {
                  "id": "unknown_payment_txn_12345",
                  "type": "matchedTransaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "amount": 2500,
                    "subtotal": 2000,
                    "description": "ONLINE STORE PURCHASE",
                    "authorizationDate": "2021-07-02T17:47:06Z",
                    "paymentType": "UNKNOWN",
                    "matchedOfferId": "5eb2d4a39ce24e00081488c4",
                    "direction": "DEBIT",
                    "merchant": {
                      "id": "98765432109876543",
                      "name": "ONLINE STORE",
                      "addrStreet": "456 Web St",
                      "addrCity": "Online City",
                      "addrState": "CA",
                      "addrZipcode": "90210",
                      "addrCountry": "United States"
                    },
                    "cardLastFour": "7890",
                    "authorizationCode": "5678",
                    "retrievalReferenceNumber": "200804333919",
                    "systemTraceAuditNumber": "444939",
                    "acquirerReferenceNumber": "9876543210987654321098765432",
                    "transactionId": "unknown-txn-4567-efgh-ijkl-mnop-qrstuvwxyz01",
                    "orderId": "online_order_789012",
                    "receiptMedium": "ELECTRONIC"
                  }
                }
              ]
            }
            """;
        var expectedObject = new TransactionsRequestBody
        {
            Data = new List<Transactions>()
            {
                new Transactions(
                    new Transactions.MatchedTransaction(
                        new MatchedTransactionsRequest
                        {
                            Id = "unknown_payment_txn_12345",
                            Attributes = new MatchedTransactionsAttributes
                            {
                                UserId = "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                                Amount = 2500,
                                Subtotal = 2000,
                                Description = "ONLINE STORE PURCHASE",
                                AuthorizationDate = DateTime.Parse(
                                    "2021-07-02T17:47:06.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                PaymentType = PaymentType.Unknown,
                                MatchedOfferId = "5eb2d4a39ce24e00081488c4",
                                Direction = DirectionType.Debit,
                                Merchant = new Merchant
                                {
                                    Id = "98765432109876543",
                                    Name = "ONLINE STORE",
                                    AddrStreet = "456 Web St",
                                    AddrCity = "Online City",
                                    AddrState = States.Ca,
                                    AddrZipcode = "90210",
                                    AddrCountry = "United States",
                                },
                                CardLastFour = "7890",
                                AuthorizationCode = "5678",
                                RetrievalReferenceNumber = "200804333919",
                                SystemTraceAuditNumber = "444939",
                                AcquirerReferenceNumber = "9876543210987654321098765432",
                                TransactionId = "unknown-txn-4567-efgh-ijkl-mnop-qrstuvwxyz01",
                                OrderId = "online_order_789012",
                                ReceiptMedium = ReceiptMediumType.Electronic,
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransactionsRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_3()
    {
        var inputJson = """
            {
              "data": [
                {
                  "id": "unknown_payment_txn_12345",
                  "type": "matchedTransaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "amount": 2500,
                    "subtotal": 2000,
                    "description": "ONLINE STORE PURCHASE",
                    "authorizationDate": "2021-07-02T17:47:06Z",
                    "paymentType": "UNKNOWN",
                    "matchedOfferId": "5eb2d4a39ce24e00081488c4",
                    "direction": "DEBIT",
                    "merchant": {
                      "id": "98765432109876543",
                      "name": "ONLINE STORE",
                      "addrStreet": "456 Web St",
                      "addrCity": "Online City",
                      "addrState": "CA",
                      "addrZipcode": "90210",
                      "addrCountry": "United States"
                    },
                    "cardLastFour": "7890",
                    "authorizationCode": "5678",
                    "retrievalReferenceNumber": "200804333919",
                    "systemTraceAuditNumber": "444939",
                    "acquirerReferenceNumber": "9876543210987654321098765432",
                    "transactionId": "unknown-txn-4567-efgh-ijkl-mnop-qrstuvwxyz01",
                    "orderId": "online_order_789012",
                    "receiptMedium": "ELECTRONIC"
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<TransactionsRequestBody>(inputJson);
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_4()
    {
        var json = """
            {
              "data": [
                {
                  "id": "core_txn_98765432109876543210",
                  "type": "coreTransaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "transactionId": "CORE-TXN-2024-001234",
                    "amount": 4599,
                    "currency": "USD",
                    "description": "WALMART SUPERCENTER",
                    "direction": "DEBIT",
                    "status": "SETTLED",
                    "settledDate": "2024-10-15T14:30:00Z",
                    "authorizationDate": "2024-10-15T14:25:00Z",
                    "financialInstitutionId": "fin-inst-001",
                    "cardLastFours": [
                      "4321"
                    ]
                  }
                }
              ]
            }
            """;
        var expectedObject = new TransactionsRequestBody
        {
            Data = new List<Transactions>()
            {
                new Transactions(
                    new Transactions.CoreTransaction(
                        new CoreTransactionRequest
                        {
                            Id = "core_txn_98765432109876543210",
                            Attributes = new CoreTransactionAttributes
                            {
                                UserId = "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                                TransactionId = "CORE-TXN-2024-001234",
                                Amount = 4599,
                                Currency = "USD",
                                Description = "WALMART SUPERCENTER",
                                Direction = DirectionType.Debit,
                                Status = "SETTLED",
                                SettledDate = DateTime.Parse(
                                    "2024-10-15T14:30:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                AuthorizationDate = DateTime.Parse(
                                    "2024-10-15T14:25:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                FinancialInstitutionId = "fin-inst-001",
                                CardLastFours = new List<string>() { "4321" },
                            },
                        }
                    )
                ),
            },
        };
        var deserializedObject = JsonUtils.Deserialize<TransactionsRequestBody>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_4()
    {
        var inputJson = """
            {
              "data": [
                {
                  "id": "core_txn_98765432109876543210",
                  "type": "coreTransaction",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "transactionId": "CORE-TXN-2024-001234",
                    "amount": 4599,
                    "currency": "USD",
                    "description": "WALMART SUPERCENTER",
                    "direction": "DEBIT",
                    "status": "SETTLED",
                    "settledDate": "2024-10-15T14:30:00Z",
                    "authorizationDate": "2024-10-15T14:25:00Z",
                    "financialInstitutionId": "fin-inst-001",
                    "cardLastFours": [
                      "4321"
                    ]
                  }
                }
              ]
            }
            """;
        JsonAssert.Roundtrips<TransactionsRequestBody>(inputJson);
    }
}
