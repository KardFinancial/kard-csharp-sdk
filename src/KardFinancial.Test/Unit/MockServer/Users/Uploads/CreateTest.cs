using KardFinancial;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using KardFinancial.Users;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Users.Uploads;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": {
                "type": "historicalTransactionStart",
                "attributes": {}
              }
            }
            """;

        const string mockResponse = """
            {
              "data": {
                "type": "historicalTransactionStart",
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "attributes": {}
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users/user-123/uploads")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Uploads.CreateAsync(
            "organization-123",
            "user-123",
            new CreateUploadRequestObject
            {
                Data = new CreateUploadRequestDataUnion(
                    new CreateUploadRequestDataUnion.HistoricalTransactionStart(
                        new StartHistoricalUploadNoData { Attributes = new EmptyObject() }
                    )
                ),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
