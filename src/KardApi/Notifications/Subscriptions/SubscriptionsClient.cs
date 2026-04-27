using global::System.Text.Json;
using KardApi;
using KardApi.Core;

namespace KardApi.Notifications;

public partial class SubscriptionsClient : ISubscriptionsClient
{
    private readonly RawClient _client;

    internal SubscriptionsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<SubscriptionsResponseObject>> GetAsyncCore(
        string organizationId,
        GetSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new KardApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("filter[eventName]", request.FilterEventName)
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
                        "/v2/issuers/{0}/subscriptions",
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
                var responseData = JsonUtils.Deserialize<SubscriptionsResponseObject>(
                    responseBody
                )!;
                return new WithRawResponse<SubscriptionsResponseObject>()
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
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(
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

    private async Task<WithRawResponse<CreateSubscriptionsResponseObject>> CreateAsyncCore(
        string organizationId,
        SubscriptionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v2/issuers/{0}/subscriptions",
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
                var responseData = JsonUtils.Deserialize<CreateSubscriptionsResponseObject>(
                    responseBody
                )!;
                return new WithRawResponse<CreateSubscriptionsResponseObject>()
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
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<ErrorResponse>(responseBody));
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

    private async Task<WithRawResponse<UpdateSubscriptionsResponseObject>> UpdateAsyncCore(
        string organizationId,
        string subscriptionId,
        UpdateSubscriptionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
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
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "/v2/issuers/{0}/subscriptions/{1}",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(subscriptionId)
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
                var responseData = JsonUtils.Deserialize<UpdateSubscriptionsResponseObject>(
                    responseBody
                )!;
                return new WithRawResponse<UpdateSubscriptionsResponseObject>()
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
    /// Call this endpoint to fetch the subscriptions of the provided issuer.<br/>
    /// <b>Required scopes:</b> `notifications:read`
    /// </summary>
    /// <example><code>
    /// await client.Notifications.Subscriptions.GetAsync(
    ///     "organization-123",
    ///     new GetSubscriptionsRequest()
    /// );
    /// </code></example>
    public WithRawResponseTask<SubscriptionsResponseObject> GetAsync(
        string organizationId,
        GetSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubscriptionsResponseObject>(
            GetAsyncCore(organizationId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Call this endpoint to subscribe to notification events.<br/>
    /// <b>Required scopes:</b> `notifications:write`
    /// </summary>
    /// <example><code>
    /// await client.Notifications.Subscriptions.CreateAsync(
    ///     "organization-123",
    ///     new SubscriptionRequestBody
    ///     {
    ///         Data = new List&lt;SubscriptionRequestUnion&gt;()
    ///         {
    ///             new SubscriptionRequestUnion(
    ///                 new SubscriptionRequestUnion.Subscription(
    ///                     new SubscriptionRequest
    ///                     {
    ///                         Attributes = new SubscriptionRequestAttributes
    ///                         {
    ///                             EventName = NotificationType.EarnedRewardApproved,
    ///                             WebhookUrl = "https://webhookUrl.com/post",
    ///                             Enabled = true,
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateSubscriptionsResponseObject> CreateAsync(
        string organizationId,
        SubscriptionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateSubscriptionsResponseObject>(
            CreateAsyncCore(organizationId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Call this endpoint to update existing notification subscriptions.<br/>
    /// <b>Required scopes:</b> `notifications:write`
    /// </summary>
    /// <example><code>
    /// await client.Notifications.Subscriptions.UpdateAsync(
    ///     "organization-123",
    ///     "subscription-123",
    ///     new UpdateSubscriptionRequestBody
    ///     {
    ///         Data = new UpdateSubscriptionRequestUnion(
    ///             new UpdateSubscriptionRequestUnion.Subscription(
    ///                 new UpdateSubscriptionRequest
    ///                 {
    ///                     Attributes = new UpdateSubscriptionRequestAttributes
    ///                     {
    ///                         EventName = NotificationType.EarnedRewardApproved,
    ///                         WebhookUrl = "https://webhookUrl.com/post",
    ///                         Enabled = true,
    ///                     },
    ///                 }
    ///             )
    ///         ),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<UpdateSubscriptionsResponseObject> UpdateAsync(
        string organizationId,
        string subscriptionId,
        UpdateSubscriptionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateSubscriptionsResponseObject>(
            UpdateAsyncCore(organizationId, subscriptionId, request, options, cancellationToken)
        );
    }
}
