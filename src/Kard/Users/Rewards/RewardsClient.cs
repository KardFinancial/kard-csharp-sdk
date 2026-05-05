using global::System.Text.Json;
using Kard;
using Kard.Core;

namespace Kard.Users;

public partial class RewardsClient : IRewardsClient
{
    private readonly RawClient _client;

    internal RewardsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<OffersResponseObject>> OffersAsyncCore(
        string organizationId,
        string userId,
        GetOffersByUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Kard.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("page[size]", request.PageSize)
            .Add("page[after]", request.PageAfter)
            .Add("page[before]", request.PageBefore)
            .Add("filter[search]", request.FilterSearch)
            .Add("filter[purchaseChannel]", request.FilterPurchaseChannel)
            .Add("filter[category]", request.FilterCategory)
            .Add("filter[isTargeted]", request.FilterIsTargeted)
            .Add("sort", request.Sort)
            .Add("include", request.Include)
            .Add("supportedComponents", request.SupportedComponents)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/offers",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId)
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
                var responseData = JsonUtils.Deserialize<OffersResponseObject>(responseBody)!;
                return new WithRawResponse<OffersResponseObject>()
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
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 404:
                        throw new DoesNotExistError(
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

    private async Task<WithRawResponse<OffersResponseObject>> PlacementOffersAsyncCore(
        string organizationId,
        string userId,
        string placementId,
        GetOffersByPlacementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Kard.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("filter[search]", request.FilterSearch)
            .Add("filter[purchaseChannel]", request.FilterPurchaseChannel)
            .Add("filter[category]", request.FilterCategory)
            .Add("filter[isTargeted]", request.FilterIsTargeted)
            .Add("include", request.Include)
            .Add("supportedComponents", request.SupportedComponents)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/placements/{2}/offers",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId),
                        ValueConvert.ToPathParameterString(placementId)
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
                var responseData = JsonUtils.Deserialize<OffersResponseObject>(responseBody)!;
                return new WithRawResponse<OffersResponseObject>()
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
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 404:
                        throw new DoesNotExistError(
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

    private async Task<WithRawResponse<LocationsResponseObject>> LocationsAsyncCore(
        string organizationId,
        string userId,
        GetLocationsByUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Kard.Core.QueryStringBuilder.Builder(capacity: 14)
            .Add("page[size]", request.PageSize)
            .Add("page[after]", request.PageAfter)
            .Add("page[before]", request.PageBefore)
            .Add("filter[name]", request.FilterName)
            .Add("filter[city]", request.FilterCity)
            .Add("filter[zipCode]", request.FilterZipCode)
            .Add("filter[state]", request.FilterState)
            .Add("filter[category]", request.FilterCategory)
            .Add("filter[longitude]", request.FilterLongitude)
            .Add("filter[latitude]", request.FilterLatitude)
            .Add("filter[radius]", request.FilterRadius)
            .Add("sort", request.Sort)
            .Add("include", request.Include)
            .Add("supportedComponents", request.SupportedComponents)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/locations",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId)
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
                var responseData = JsonUtils.Deserialize<LocationsResponseObject>(responseBody)!;
                return new WithRawResponse<LocationsResponseObject>()
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
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 404:
                        throw new DoesNotExistError(
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
    /// Retrieve national brand offers that a specified user is eligible for. Call this endpoint to build out your
    /// [targeted offers UX experience](/2024-10-01/api/getting-started#b-discover-a-lapsed-customer-clo). Local offers details
    /// can be found by calling the [Get Eligible Locations](/2024-10-01/api/rewards/locations).<br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    /// <example><code>
    /// await client.Users.Rewards.OffersAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     new GetOffersByUserRequest
    ///     {
    ///         PageSize = 1,
    ///         FilterIsTargeted = true,
    ///         Sort = [OfferSortOptions.StartDateDesc],
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<OffersResponseObject> OffersAsync(
        string organizationId,
        string userId,
        GetOffersByUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<OffersResponseObject>(
            OffersAsyncCore(organizationId, userId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve offers for a placement slot. Returns offers sorted by highest cash back,
    /// limited by the placement's available slots.<br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    /// <example><code>
    /// await client.Users.Rewards.PlacementOffersAsync(
    ///     "organizationId",
    ///     "userId",
    ///     "placementId",
    ///     new GetOffersByPlacementRequest()
    /// );
    /// </code></example>
    public WithRawResponseTask<OffersResponseObject> PlacementOffersAsync(
        string organizationId,
        string userId,
        string placementId,
        GetOffersByPlacementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<OffersResponseObject>(
            PlacementOffersAsyncCore(
                organizationId,
                userId,
                placementId,
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Retrieve national and local geographic locations that a specified user has eligible in-store offers at. Use this endpoint to build
    /// out your [map-specific UX experiences](/2024-10-01/api/getting-started#c-discover-clos-near-you-map-view). Please note
    /// that Longitude and Latitude fields are prioritized over State, City and Zipcode and are the recommended search
    /// pattern.<br/>
    /// <br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    /// <example><code>
    /// await client.Users.Rewards.LocationsAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     new GetLocationsByUserRequest
    ///     {
    ///         PageSize = 1,
    ///         FilterLatitude = 39.9419429,
    ///         FilterLongitude = -75.1446869,
    ///         FilterRadius = 10,
    ///         Include = ["offers,categories"],
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<LocationsResponseObject> LocationsAsync(
        string organizationId,
        string userId,
        GetLocationsByUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<LocationsResponseObject>(
            LocationsAsyncCore(organizationId, userId, request, options, cancellationToken)
        );
    }
}
