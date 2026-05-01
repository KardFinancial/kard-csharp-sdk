using KardApi;
using KardApi.Test.Unit.MockServer;
using KardApi.Test.Utils;
using KardApi.Users;
using NUnit.Framework;

namespace KardApi.Test.Unit.MockServer.Users.Uploads;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "data": {
                "type": "historicalTransactionComplete",
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "attributes": {}
              }
            }
            """;

        const string mockResponse = """
            {
              "data": {
                "type": "historicalTransactionComplete",
                "id": "7e382223-b9a5-4825-91fb-436c8957a2e7",
                "attributes": {}
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/users/user-123/uploads/upload-123")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Uploads.UpdateAsync(
            "organization-123",
            "user-123",
            "upload-123",
            new UpdateUploadRequestObject
            {
                Data = new UpdateUploadRequestDataUnion(
                    new UpdateUploadRequestDataUnion.HistoricalTransactionComplete(
                        new HistoricalTransactionCompleteNoData
                        {
                            Id = "7e382223-b9a5-4825-91fb-436c8957a2e7",
                            Attributes = new EmptyObject(),
                        }
                    )
                ),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
