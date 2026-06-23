using global::System.Text.Json;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

public partial class AttributionsClient : IAttributionsClient
{
    private readonly RawClient _client;

    internal AttributionsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateAttributionResponse>> CreateAsyncCore(
        string organizationId,
        string userId,
        CreateAttributionRequestObject request,
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
                        "/v2/issuers/{0}/users/{1}/attributions",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId)
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
                var responseData = JsonUtils.Deserialize<CreateAttributionResponse>(responseBody)!;
                return new WithRawResponse<CreateAttributionResponse>()
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
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
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

    private async Task<WithRawResponse<ActivateOfferResponse>> ActivateAsyncCore(
        string organizationId,
        string userId,
        string offerId,
        ActivateOfferRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new KardFinancial.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("supportedComponents", request.SupportedComponents)
            .Add("include", request.Include)
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/offers/{2}/activate",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId),
                        ValueConvert.ToPathParameterString(offerId)
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
                var responseData = JsonUtils.Deserialize<ActivateOfferResponse>(responseBody)!;
                return new WithRawResponse<ActivateOfferResponse>()
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
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
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

    private async Task<WithRawResponse<BoostOfferResponse>> BoostAsyncCore(
        string organizationId,
        string userId,
        string offerId,
        BoostOfferRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new KardFinancial.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("supportedComponents", request.SupportedComponents)
            .Add("include", request.Include)
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/offers/{2}/boost",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId),
                        ValueConvert.ToPathParameterString(offerId)
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
                var responseData = JsonUtils.Deserialize<BoostOfferResponse>(responseBody)!;
                return new WithRawResponse<BoostOfferResponse>()
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
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
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

    private async Task<
        WithRawResponse<ActivatePlacementSlotResponse>
    > ActivatePlacementSlotAsyncCore(
        string organizationId,
        string userId,
        string placementId,
        string slotId,
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
                        "/v2/issuers/{0}/users/{1}/placements/{2}/slot/{3}/activate",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId),
                        ValueConvert.ToPathParameterString(placementId),
                        ValueConvert.ToPathParameterString(slotId)
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
                var responseData = JsonUtils.Deserialize<ActivatePlacementSlotResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ActivatePlacementSlotResponse>()
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
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
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
    /// Call this endpoint to send attribution events made by a single enrolled user for processing. A maximum of 100 events can be included in a single request.
    ///
    /// <b>Required scopes:</b> `attributions:write`
    /// </summary>
    /// <example><code>
    /// await client.Users.Attributions.CreateAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     new CreateAttributionRequestObject
    ///     {
    ///         Data = new List&lt;CreateAttributionRequestUnion&gt;()
    ///         {
    ///             new CreateAttributionRequestUnion(
    ///                 new CreateAttributionRequestUnion.OfferAttribution(
    ///                     new OfferAttributionRequest
    ///                     {
    ///                         Attributes = new OfferAttributionAttributes
    ///                         {
    ///                             EntityId = "60e4ba1da31c5a22a144c075",
    ///                             EventCode = EventCode.View,
    ///                             Medium = OfferMedium.Search,
    ///                             EventDate = new DateTime(2025, 01, 01, 00, 00, 00, 000),
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///             new CreateAttributionRequestUnion(
    ///                 new CreateAttributionRequestUnion.OfferAttribution(
    ///                     new OfferAttributionRequest
    ///                     {
    ///                         Attributes = new OfferAttributionAttributes
    ///                         {
    ///                             EntityId = "60e4ba1da31c5a22a144c077",
    ///                             EventCode = EventCode.Impression,
    ///                             Medium = OfferMedium.Email,
    ///                             EventDate = new DateTime(2025, 01, 01, 00, 00, 00, 000),
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///             new CreateAttributionRequestUnion(
    ///                 new CreateAttributionRequestUnion.NotificationAttribution(
    ///                     new NotificationAttributionRequest
    ///                     {
    ///                         Attributes = new NotificationAttributionAttributes
    ///                         {
    ///                             EntityId = "60e4ba1da31c5a22a144c076",
    ///                             EventCode = EventCode.Impression,
    ///                             Medium = NotificationMedium.Push,
    ///                             EventDate = new DateTime(2025, 01, 01, 00, 00, 00, 000),
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateAttributionResponse> CreateAsync(
        string organizationId,
        string userId,
        CreateAttributionRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateAttributionResponse>(
            CreateAsyncCore(organizationId, userId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Record when a user activates an offer. Creates an attribution event with eventCode=ACTIVATE and medium=CTA.
    /// Optionally include the offer data by passing `include=offer`.
    /// </summary>
    /// <example><code>
    /// await client.Users.Attributions.ActivateAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     "offer-456",
    ///     new ActivateOfferRequest()
    /// );
    /// </code></example>
    public WithRawResponseTask<ActivateOfferResponse> ActivateAsync(
        string organizationId,
        string userId,
        string offerId,
        ActivateOfferRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ActivateOfferResponse>(
            ActivateAsyncCore(organizationId, userId, offerId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Record when a user boosts an offer. Creates an attribution event with eventCode=BOOST and medium=CTA.
    /// Optionally include the offer data by passing `include=offer`.
    /// </summary>
    /// <example><code>
    /// await client.Users.Attributions.BoostAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     "offer-456",
    ///     new BoostOfferRequest()
    /// );
    /// </code></example>
    public WithRawResponseTask<BoostOfferResponse> BoostAsync(
        string organizationId,
        string userId,
        string offerId,
        BoostOfferRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BoostOfferResponse>(
            BoostAsyncCore(organizationId, userId, offerId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Record when a user activates a batch-activation placement slot. Writes a slot-level
    /// `placementSlotAttribution` ACTIVATE event and fans out a per-offer
    /// `offerAttribution` ACTIVATE event for every offer resolved by the slot's content
    /// strategy. The slot-level event id and the resolved `offerIds` are returned so the
    /// partner can render the batch immediately without an extra round-trip to re-fetch
    /// the placement content.
    ///
    /// <b>Required scopes:</b> `attributions:write`
    /// </summary>
    /// <example><code>
    /// await client.Users.Attributions.ActivatePlacementSlotAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     "018f8d6b-1abc-7def-9012-345678901234",
    ///     "slot-a"
    /// );
    /// </code></example>
    public WithRawResponseTask<ActivatePlacementSlotResponse> ActivatePlacementSlotAsync(
        string organizationId,
        string userId,
        string placementId,
        string slotId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ActivatePlacementSlotResponse>(
            ActivatePlacementSlotAsyncCore(
                organizationId,
                userId,
                placementId,
                slotId,
                options,
                cancellationToken
            )
        );
    }
}
