using global::System.Text.Json;
using KardFinancial.Core;

namespace KardFinancial;

public partial class AuthClient : IAuthClient
{
    private readonly RawClient _client;

    internal AuthClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<TokenResponse>> GetTokenAsyncCore(
        GetTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new KardFinancial.Core.HeadersBuilder.Builder()
            .Add("X-Kard-Target-Issuer", request.XKardTargetIssuer)
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
                    Path = "/v2/auth/token",
                    Body = request,
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
                var responseData = JsonUtils.Deserialize<TokenResponse>(responseBody)!;
                return new WithRawResponse<TokenResponse>()
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <example><code>
    /// await client.Auth.GetTokenAsync(
    ///     new GetTokenRequest { ClientId = "client_id", ClientSecret = "client_secret" }
    /// );
    /// </code></example>
    public WithRawResponseTask<TokenResponse> GetTokenAsync(
        GetTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TokenResponse>(
            GetTokenAsyncCore(request, options, cancellationToken)
        );
    }
}
