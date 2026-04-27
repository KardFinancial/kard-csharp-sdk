using global::System.Text.Json;
using KardApi.Core;

namespace KardApi;

public partial class FilesClient : IFilesClient
{
    private readonly RawClient _client;

    internal FilesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<GetFilesMetadataResponse>> GetMetadataAsyncCore(
        string organizationId,
        GetFilesMetadataRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new KardApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("filter[dateFrom]", request.FilterDateFrom)
            .Add("filter[dateTo]", request.FilterDateTo)
            .Add("filter[fileType]", request.FilterFileType)
            .Add("page[size]", request.PageSize)
            .Add("page[after]", request.PageAfter)
            .Add("page[before]", request.PageBefore)
            .Add("sort", request.Sort)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new KardApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/issuers/{0}/files/metadata",
                        ValueConvert.ToPathParameterString(organizationId)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetFilesMetadataResponse>(responseBody)!;
                return new WithRawResponse<GetFilesMetadataResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new KardApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new KardApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves metadata for files associated with a specific issuer/organization.
    /// This endpoint supports pagination and sorting options to efficiently navigate
    /// through potentially large sets of file metadata.
    /// <b>Required scopes:</b> `files.read`
    /// </summary>
    /// <example><code>
    /// await client.Files.GetMetadataAsync(
    ///     "organization-123",
    ///     new GetFilesMetadataRequest
    ///     {
    ///         PageSize = 5,
    ///         FilterDateFrom = "2025-02-20T21:56:23Z",
    ///         FilterDateTo = "2025-03-20T21:56:23Z",
    ///         FilterFileType = FileType.EarnedRewardApprovedDailyReconciliationFile,
    ///         Sort = [FilesMetadataSortOptions.SentDateDesc],
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetFilesMetadataResponse> GetMetadataAsync(
        string organizationId,
        GetFilesMetadataRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetFilesMetadataResponse>(
            GetMetadataAsyncCore(organizationId, request, options, cancellationToken)
        );
    }
}
