using KardFinancial;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Transactions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBulkTransactionsUploadUrlTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "data": [
                {
                  "type": "incomingTransactionsFile",
                  "attributes": {
                    "filename": "transaction_12345.jsonl"
                  }
                },
                {
                  "type": "incomingTransactionsFile",
                  "attributes": {
                    "filename": "transaction_67890.jsonl"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "data": [
                {
                  "type": "incomingTransactionsFile",
                  "id": "2NxKz7TYmqVH8UrjGP1xK3hF2gs",
                  "attributes": {
                    "url": "https://s3.amazonaws.com/bucket/key1?X-Amz-Algorithm=...",
                    "expiresIn": 900
                  }
                },
                {
                  "type": "incomingTransactionsFile",
                  "id": "3PqLa8UZnrWI9VskHQ2yL4iG3ht",
                  "attributes": {
                    "url": "https://s3.amazonaws.com/bucket/key2?X-Amz-Algorithm=...",
                    "expiresIn": 900
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/transactions/uploads")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Transactions.CreateBulkTransactionsUploadUrlAsync(
            "organization-123",
            new CreateFileUploadRequestBody
            {
                Data = new List<CreateFileUploadData>()
                {
                    new CreateFileUploadData
                    {
                        Type = FileUploadType.IncomingTransactionsFile,
                        Attributes = new CreateFileUploadAttributes
                        {
                            Filename = "transaction_12345.jsonl",
                        },
                    },
                    new CreateFileUploadData
                    {
                        Type = FileUploadType.IncomingTransactionsFile,
                        Attributes = new CreateFileUploadAttributes
                        {
                            Filename = "transaction_67890.jsonl",
                        },
                    },
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
                  "type": "historicalTransactionsFile",
                  "attributes": {
                    "filename": "historical_transactions_2024-10-15.jsonl"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "data": [
                {
                  "type": "historicalTransactionsFile",
                  "id": "2Rk3pHqLm9vNwXs1TyBf0Jc4dE",
                  "attributes": {
                    "url": "https://s3.amazonaws.com/bucket/key1?X-Amz-Algorithm=...",
                    "expiresIn": 900
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/transactions/uploads")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Transactions.CreateBulkTransactionsUploadUrlAsync(
            "organization-123",
            new CreateFileUploadRequestBody
            {
                Data = new List<CreateFileUploadData>()
                {
                    new CreateFileUploadData
                    {
                        Type = FileUploadType.HistoricalTransactionsFile,
                        Attributes = new CreateFileUploadAttributes
                        {
                            Filename = "historical_transactions_2024-10-15.jsonl",
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
