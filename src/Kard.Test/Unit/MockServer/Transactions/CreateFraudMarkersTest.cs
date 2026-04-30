using Kard;
using Kard.Test.Unit.MockServer;
using Kard.Test.Utils;
using NUnit.Framework;

namespace Kard.Test.Unit.MockServer.Transactions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateFraudMarkersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": [
                {
                  "id": "myTxnId12345",
                  "type": "fraudulentTransaction",
                  "attributes": {
                    "userId": "userId123"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "data": [
                {
                  "type": "fraudulentTransaction",
                  "id": "myTxnId123",
                  "attributes": {
                    "userId": "user123"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/fraud")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Transactions.CreateFraudMarkersAsync(
            "organization-123",
            new FraudulentTransactionRequestBody
            {
                Data = new List<FraudulentTransactionData>()
                {
                    new FraudulentTransactionData
                    {
                        Id = "myTxnId12345",
                        Type = "fraudulentTransaction",
                        Attributes = new FraudulentTransactionAttributes { UserId = "userId123" },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
