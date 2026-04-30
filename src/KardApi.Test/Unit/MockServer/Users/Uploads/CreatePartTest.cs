using global::System.Globalization;
using KardApi;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Users.Uploads;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePartTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": [
                {
                  "type": "historicalTransaction",
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
                    "transactionId": "2467de37-cbdc-416d-a359-75de87bfffb0"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "data": [
                {
                  "type": "historicalTransaction",
                  "id": "txnId123",
                  "attributes": {}
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/issuers/organization-123/users/user-123/uploads/upload-123/parts"
                    )
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Uploads.CreatePartAsync(
            "organization-123",
            "user-123",
            "upload-123",
            new CreateUploadPartRequestObject
            {
                Data = new List<CreateUploadPartDataUnion>()
                {
                    new CreateUploadPartDataUnion(
                        new CreateUploadPartDataUnion.HistoricalTransaction(
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
