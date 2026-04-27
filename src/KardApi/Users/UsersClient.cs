using global::System.Text.Json;
using KardApi.Core;
using KardApi.Users;

namespace KardApi;

public partial class UsersClient : IUsersClient
{
    private readonly RawClient _client;

    internal UsersClient(RawClient client)
    {
        _client = client;
        Attributions = new AttributionsClient(_client);
        Auth = new KardApi.Users.AuthClient(_client);
        Rewards = new RewardsClient(_client);
        Uploads = new UploadsClient(_client);
    }

    public IAttributionsClient Attributions { get; }

    public Users.IAuthClient Auth { get; }

    public IRewardsClient Rewards { get; }

    public IUploadsClient Uploads { get; }

    private async Task<WithRawResponse<CreateUsersObject>> CreateAsyncCore(
        string organizationId,
        CreateUsersObject request,
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
                        "v2/issuers/{0}/users",
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
                var responseData = JsonUtils.Deserialize<CreateUsersObject>(responseBody)!;
                return new WithRawResponse<CreateUsersObject>()
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
                    case 207:
                        throw new MultiStatus(
                            JsonUtils.Deserialize<CreateUsersMultiStatusResponse>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
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

    private async Task<WithRawResponse<UserResponseObject>> UpdateAsyncCore(
        string organizationId,
        string userId,
        UpdateUserObject request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/issuers/{0}/users/{1}",
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
                var responseData = JsonUtils.Deserialize<UserResponseObject>(responseBody)!;
                return new WithRawResponse<UserResponseObject>()
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
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
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

    private async Task<WithRawResponse<DeleteUserResponseObject>> DeleteAsyncCore(
        string organizationId,
        string userId,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/issuers/{0}/users/{1}",
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
                var responseData = JsonUtils.Deserialize<DeleteUserResponseObject>(responseBody)!;
                return new WithRawResponse<DeleteUserResponseObject>()
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
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
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

    private async Task<WithRawResponse<UserResponseObject>> GetAsyncCore(
        string organizationId,
        string userId,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/issuers/{0}/users/{1}",
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
                var responseData = JsonUtils.Deserialize<UserResponseObject>(responseBody)!;
                return new WithRawResponse<UserResponseObject>()
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
    /// Call this endpoint to enroll a specified user into your rewards program.<br/>
    ///
    /// <b>Required scopes:</b>  `user:write`<br/>
    /// <b>Note:</b> `Maximum of 100 users can be created per request`.
    /// </summary>
    /// <example><code>
    /// await client.Users.CreateAsync(
    ///     "organization-123",
    ///     new CreateUsersObject
    ///     {
    ///         Data = new List&lt;UserRequestDataUnion&gt;()
    ///         {
    ///             new UserRequestDataUnion(
    ///                 new UserRequestDataUnion.User(
    ///                     new UserRequestData
    ///                     {
    ///                         Id = "1234567890",
    ///                         Attributes = new UserRequestAttributes
    ///                         {
    ///                             ZipCode = "11238",
    ///                             EnrolledRewards = new List&lt;EnrolledRewardsType&gt;()
    ///                             {
    ///                                 EnrolledRewardsType.Cardlinked,
    ///                             },
    ///                             Email = "user@example.com",
    ///                             HashedEmail =
    ///                                 "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3e2d8a5b76e45a1d4c4e2e3a1",
    ///                             PhoneNumber = "+14155552671",
    ///                             BirthYear = "1990",
    ///                             HistoricalTransactionsSent = true,
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateUsersObject> CreateAsync(
        string organizationId,
        CreateUsersObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateUsersObject>(
            CreateAsyncCore(organizationId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Call this endpoint to update the details on a specified user.<br/>
    ///
    /// <b>Required scopes:</b> `user:update`
    /// </summary>
    /// <example><code>
    /// await client.Users.UpdateAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     new UpdateUserObject
    ///     {
    ///         Data = new UpdateUserRequestDataUnion(
    ///             new UpdateUserRequestDataUnion.User(
    ///                 new UpdateUserRequestData
    ///                 {
    ///                     Id = "1234567890",
    ///                     Attributes = new UpdateUserRequestAttributes
    ///                     {
    ///                         ZipCode = "11238",
    ///                         EnrolledRewards = new List&lt;EnrolledRewardsType&gt;()
    ///                         {
    ///                             EnrolledRewardsType.Cardlinked,
    ///                         },
    ///                         Email = "user@example.com",
    ///                         HashedEmail =
    ///                             "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3e2d8a5b76e45a1d4c4e2e3a1",
    ///                         PhoneNumber = "+14155552671",
    ///                         BirthYear = "1990",
    ///                     },
    ///                 }
    ///             )
    ///         ),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<UserResponseObject> UpdateAsync(
        string organizationId,
        string userId,
        UpdateUserObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UserResponseObject>(
            UpdateAsyncCore(organizationId, userId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Call this endpoint to delete a specified enrolled user from the rewards program and Kard's system. Users can be re-enrolled into rewards by calling the [Create User](/2024-10-01/api/users/create) endpoint using the same `id` from before.<br/>
    ///
    /// <b>Required scopes:</b> `user:delete`
    /// </summary>
    /// <example><code>
    /// await client.Users.DeleteAsync("organization-123", "user-123");
    /// </code></example>
    public WithRawResponseTask<DeleteUserResponseObject> DeleteAsync(
        string organizationId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeleteUserResponseObject>(
            DeleteAsyncCore(organizationId, userId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Call this endpoint to fetch the details on a specified user.<br/>
    /// <br/>
    /// <b>Required scopes:</b>  `user:read`
    /// </summary>
    /// <example><code>
    /// await client.Users.GetAsync("organization-123", "user-123");
    /// </code></example>
    public WithRawResponseTask<UserResponseObject> GetAsync(
        string organizationId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UserResponseObject>(
            GetAsyncCore(organizationId, userId, options, cancellationToken)
        );
    }
}
