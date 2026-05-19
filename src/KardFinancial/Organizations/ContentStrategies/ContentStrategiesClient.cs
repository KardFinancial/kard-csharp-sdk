using global::System.Text.Json;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

public partial class ContentStrategiesClient : IContentStrategiesClient
{
    private readonly RawClient _client;

    internal ContentStrategiesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<ContentStrategyResponse>> CreateAsyncCore(
        string organizationId,
        CreateContentStrategyRequestBody request,
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
                        "v2/issuers/{0}/contentStrategies",
                        ValueConvert.ToPathParameterString(organizationId)
                    ),
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
                var responseData = JsonUtils.Deserialize<ContentStrategyResponse>(responseBody)!;
                return new WithRawResponse<ContentStrategyResponse>()
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
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<ErrorResponse>(responseBody));
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ContentStrategyListResponse>> ListAsyncCore(
        string organizationId,
        ListContentStrategiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new KardFinancial.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("filter[name]", request.FilterName)
            .Add("page[after]", request.PageAfter)
            .Add("page[size]", request.PageSize)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/issuers/{0}/contentStrategies",
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
                var responseData = JsonUtils.Deserialize<ContentStrategyListResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ContentStrategyListResponse>()
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
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ContentStrategyResponse>> GetAsyncCore(
        string organizationId,
        string contentStrategyId,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/issuers/{0}/contentStrategies/{1}",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(contentStrategyId)
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
                var responseData = JsonUtils.Deserialize<ContentStrategyResponse>(responseBody)!;
                return new WithRawResponse<ContentStrategyResponse>()
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ContentStrategyResponse>> UpdateAsyncCore(
        string organizationId,
        string contentStrategyId,
        UpdateContentStrategyRequestBody request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/issuers/{0}/contentStrategies/{1}",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(contentStrategyId)
                    ),
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
                var responseData = JsonUtils.Deserialize<ContentStrategyResponse>(responseBody)!;
                return new WithRawResponse<ContentStrategyResponse>()
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
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<ErrorResponse>(responseBody));
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DeleteResourceResponse>> DeleteAsyncCore(
        string organizationId,
        string contentStrategyId,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/issuers/{0}/contentStrategies/{1}",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(contentStrategyId)
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
                var responseData = JsonUtils.Deserialize<DeleteResourceResponse>(responseBody)!;
                return new WithRawResponse<DeleteResourceResponse>()
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
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<ErrorResponse>(responseBody));
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Create a content strategy for the organization. The strategy name must be unique within the organization.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.ContentStrategies.CreateAsync(
    ///     "org-123",
    ///     new CreateContentStrategyRequestBody
    ///     {
    ///         Data = new CreateContentStrategyRequestData
    ///         {
    ///             Type = "contentStrategy",
    ///             Attributes = new CreateContentStrategyAttributes
    ///             {
    ///                 Name = "Featured Travel",
    ///                 Filters = new List&lt;ContentStrategyFilter&gt;()
    ///                 {
    ///                     ContentStrategyFilter.HighestCashback,
    ///                     ContentStrategyFilter.NewlyLive,
    ///                 },
    ///                 Categories = new List&lt;CategoryOption&gt;() { CategoryOption.Travel },
    ///                 CategoryExclusions = new List&lt;CategoryOption&gt;() { CategoryOption.Gas },
    ///                 MerchantExclusions = new List&lt;string&gt;() { "merchant-abc" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ContentStrategyResponse> CreateAsync(
        string organizationId,
        CreateContentStrategyRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContentStrategyResponse>(
            CreateAsyncCore(organizationId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// List content strategies belonging to the authenticated organization
    /// </summary>
    /// <example><code>
    /// await client.Organizations.ContentStrategies.ListAsync(
    ///     "organizationId",
    ///     new ListContentStrategiesRequest()
    /// );
    /// </code></example>
    public WithRawResponseTask<ContentStrategyListResponse> ListAsync(
        string organizationId,
        ListContentStrategiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContentStrategyListResponse>(
            ListAsyncCore(organizationId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a specific content strategy
    /// </summary>
    /// <example><code>
    /// await client.Organizations.ContentStrategies.GetAsync("organizationId", "contentStrategyId");
    /// </code></example>
    public WithRawResponseTask<ContentStrategyResponse> GetAsync(
        string organizationId,
        string contentStrategyId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContentStrategyResponse>(
            GetAsyncCore(organizationId, contentStrategyId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Replace a content strategy. All fields must be provided; any omitted attribute is treated as cleared.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.ContentStrategies.UpdateAsync(
    ///     "organizationId",
    ///     "contentStrategyId",
    ///     new UpdateContentStrategyRequestBody
    ///     {
    ///         Data = new UpdateContentStrategyRequestData
    ///         {
    ///             Type = "contentStrategy",
    ///             Attributes = new UpdateContentStrategyAttributes
    ///             {
    ///                 Name = "name",
    ///                 Filters = new List&lt;ContentStrategyFilter&gt;()
    ///                 {
    ///                     ContentStrategyFilter.NewlyLive,
    ///                     ContentStrategyFilter.NewlyLive,
    ///                 },
    ///                 Categories = new List&lt;CategoryOption&gt;()
    ///                 {
    ///                     CategoryOption.ArtsEntertainment,
    ///                     CategoryOption.ArtsEntertainment,
    ///                 },
    ///                 CategoryExclusions = new List&lt;CategoryOption&gt;()
    ///                 {
    ///                     CategoryOption.ArtsEntertainment,
    ///                     CategoryOption.ArtsEntertainment,
    ///                 },
    ///                 MerchantExclusions = new List&lt;string&gt;()
    ///                 {
    ///                     "merchantExclusions",
    ///                     "merchantExclusions",
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ContentStrategyResponse> UpdateAsync(
        string organizationId,
        string contentStrategyId,
        UpdateContentStrategyRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContentStrategyResponse>(
            UpdateAsyncCore(organizationId, contentStrategyId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a content strategy. Returns 409 if the strategy is still referenced by another resource.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.ContentStrategies.DeleteAsync("organizationId", "contentStrategyId");
    /// </code></example>
    public WithRawResponseTask<DeleteResourceResponse> DeleteAsync(
        string organizationId,
        string contentStrategyId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeleteResourceResponse>(
            DeleteAsyncCore(organizationId, contentStrategyId, options, cancellationToken)
        );
    }
}
