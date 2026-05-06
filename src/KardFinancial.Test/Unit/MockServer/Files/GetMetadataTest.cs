using KardFinancial;
using KardFinancial.Test.Unit.MockServer;
using KardFinancial.Test.Utils;
using NUnit.Framework;

namespace KardFinancial.Test.Unit.MockServer.Files;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetMetadataTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "type": "earnedRewardApprovedDailyReconciliationFile",
                  "attributes": {
                    "fileName": "test-file-10.jsonl",
                    "sentAt": "2025-03-09T21:56:23Z",
                    "lastModified": "2025-03-19T21:56:23Z",
                    "downloadUrl": "https://default-bucket.s3.us-east-1.amazonaws.com/test-file-10.jsonl?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Checksum-Mode=ENABLED&X-Amz-Credential=test%2F20250320%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20250320T172109Z&X-Amz-Expires=1800&X-Amz-SignedHeaders=host&x-id=GetObject&X-Amz-Signature=c2a7dc6d14d0465b9ba9c24d47574a6bbcfa57856529319f25424c6bb1cf5204"
                  },
                  "id": "67db3d87cb70469be876c852049"
                }
              ],
              "links": {
                "self": "/v2/files/issuers/0004321/metadata?page%5Bafter%5D=MjAyNS0wMy0xMFQyMTo1NjoyMy40OTY4ODda&page%5Bsize%5D=5&sort%5Bsent_at%5D=DESC",
                "prev": "/v2/files/issuers/0004321/metadata?page%5Bbefore%5D=MjAyNS0wMy0wOVQyMTo1NjoyMy40OTY4ODda&page%5Bsize%5D=5&sort%5Bsent_at%5D=DESC",
                "next": "/v2/files/issuers/0004321/metadata?page%5Bafter%5D=MjAyNS0wMy0wNVQyMTo1NjoyMy40OTY4ODda&page%5Bsize%5D=5&sort%5Bsent_at%5D=DESC"
              },
              "meta": {
                "pageSize": 5,
                "hasNextPage": true
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/issuers/organization-123/files/metadata")
                    .WithParam("page%5Bsize%5D", "5")
                    .WithParam("filter%5BdateFrom%5D", "2025-02-20T21:56:23Z")
                    .WithParam("filter%5BdateTo%5D", "2025-03-20T21:56:23Z")
                    .WithParam(
                        "filter%5BfileType%5D",
                        "earnedRewardApprovedDailyReconciliationFile"
                    )
                    .WithParam("sort", "-sentDate")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Files.GetMetadataAsync(
            "organization-123",
            new GetFilesMetadataRequest
            {
                PageSize = 5,
                FilterDateFrom = "2025-02-20T21:56:23Z",
                FilterDateTo = "2025-03-20T21:56:23Z",
                FilterFileType = FileType.EarnedRewardApprovedDailyReconciliationFile,
                Sort = [FilesMetadataSortOptions.SentDateDesc],
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
