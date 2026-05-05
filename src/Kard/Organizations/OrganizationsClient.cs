using global::System.Text.Json;
using Kard.Core;
using Kard.Organizations;

namespace Kard;

public partial class OrganizationsClient : IOrganizationsClient
{
    private readonly RawClient _client;

    internal OrganizationsClient(RawClient client)
    {
        _client = client;
        Children = new ChildrenClient(_client);
        Placements = new PlacementsClient(_client);
    }

    public IChildrenClient Children { get; }

    public IPlacementsClient Placements { get; }

    private async Task<WithRawResponse<ExternalOrganizationResponse>> GetAsyncCore(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Kard.Core.HeadersBuilder.Builder()
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
                    Path = "v2/issuer",
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
                var responseData = JsonUtils.Deserialize<ExternalOrganizationResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ExternalOrganizationResponse>()
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
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 404:
                        throw new DoesNotExistError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
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
    /// Retrieve organization details for the authenticated issuer
    /// </summary>
    /// <example><code>
    /// await client.Organizations.GetAsync();
    /// </code></example>
    public WithRawResponseTask<ExternalOrganizationResponse> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ExternalOrganizationResponse>(
            GetAsyncCore(options, cancellationToken)
        );
    }
}
