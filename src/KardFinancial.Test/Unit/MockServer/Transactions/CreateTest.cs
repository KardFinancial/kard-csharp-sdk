using global::System.Globalization;
using KardFinancial;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Transactions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "data": [
                {
                  "type": "transaction",
                  "id": "309rjfoincor3icno3rind093cdow3jciwjdwcm",
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
                    "authorizationDate": "2021-07-02T17:47:06.000Z",
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

        const string mockResponse = """
            {
              "data": {
                "type": "job",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "status": "queued",
                  "message": "Incoming Transactions event successfully queued for processing"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/transactions")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Transactions.CreateAsync(
            "organization-123",
            new TransactionsRequestBody
            {
                Data = new List<KardFinancial.Transactions>()
                {
                    new KardFinancial.Transactions(
                        new KardFinancial.Transactions.Transaction(
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "data": [
                {
                  "type": "coreTransaction",
                  "id": "core_txn_98765432109876543210",
                  "attributes": {
                    "userId": "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                    "transactionId": "CORE-TXN-2024-001234",
                    "amount": 4599,
                    "currency": "USD",
                    "description": "WALMART SUPERCENTER",
                    "direction": "DEBIT",
                    "status": "SETTLED",
                    "settledDate": "2024-10-15T14:30:00.000Z",
                    "authorizationDate": "2024-10-15T14:25:00.000Z",
                    "financialInstitutionId": "fin-inst-001",
                    "cardLastFours": [
                      "4321"
                    ]
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "data": {
                "type": "job",
                "id": "c94a93a7-beb9-4e58-960c-2c812f849398",
                "attributes": {
                  "status": "queued",
                  "message": "Incoming Transactions event successfully queued for processing"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/transactions")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Transactions.CreateAsync(
            "organization-123",
            new TransactionsRequestBody
            {
                Data = new List<KardFinancial.Transactions>()
                {
                    new KardFinancial.Transactions(
                        new KardFinancial.Transactions.CoreTransaction(
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
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
