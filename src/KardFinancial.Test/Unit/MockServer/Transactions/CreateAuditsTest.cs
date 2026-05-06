using KardFinancial;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Transactions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateAuditsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": [
                {
                  "type": "audit",
                  "attributes": {
                    "auditCode": 8001,
                    "merchantName": "Caribbean Goodness",
                    "auditDescription": "duplicate transaction",
                    "transactionId": "issuerTransaction123"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "data": [
                {
                  "type": "audit",
                  "id": "d80a6f28-1b24-4d65-9e42-e1cf3379bc98",
                  "attributes": {
                    "transactionId": "issuerTransaction123"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users/user-123/audits")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Transactions.CreateAuditsAsync(
            "organization-123",
            "user-123",
            new CreateAuditRequestBody
            {
                Data = new List<CreateAuditRequestDataUnion>()
                {
                    new CreateAuditRequestDataUnion(
                        new CreateAuditRequestDataUnion.Audit(
                            new AuditRequestData
                            {
                                Attributes = new AuditAttributes
                                {
                                    AuditCode = 8001,
                                    MerchantName = "Caribbean Goodness",
                                    AuditDescription = "duplicate transaction",
                                    TransactionId = "issuerTransaction123",
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
