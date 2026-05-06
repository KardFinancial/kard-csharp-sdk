using global::System.Text.Json;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

public partial class AuthClient : IAuthClient
{
    private readonly RawClient _client;

    internal AuthClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<WebViewTokenResponse>> GetWebViewTokenAsyncCore(
        string organizationId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new KardFinancial.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v2/auth/issuers/{0}/users/{1}/token",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId)
                    ),
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
                var responseData = JsonUtils.Deserialize<WebViewTokenResponse>(responseBody)!;
                return new WithRawResponse<WebViewTokenResponse>()
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
                throw new KardApiException(
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
                    case 500:
                        throw new InternalServerError(
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves an OAuth token for webview authentication.
    /// </summary>
    /// <example><code>
    /// await client.Users.Auth.GetWebViewTokenAsync("organization-123", "user-123");
    /// </code></example>
    public WithRawResponseTask<WebViewTokenResponse> GetWebViewTokenAsync(
        string organizationId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WebViewTokenResponse>(
            GetWebViewTokenAsyncCore(organizationId, userId, options, cancellationToken)
        );
    }
}
