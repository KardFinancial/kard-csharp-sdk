using global::System.Text.Json;
using KardFinancial.Core;

namespace KardFinancial;

public partial class TransactionsClient : ITransactionsClient
{
    private readonly RawClient _client;

    internal TransactionsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<TransactionsResponse>> CreateAsyncCore(
        string organizationId,
        TransactionsRequestBody request,
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
                        "/v2/issuers/{0}/transactions",
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
                var responseData = JsonUtils.Deserialize<TransactionsResponse>(responseBody)!;
                return new WithRawResponse<TransactionsResponse>()
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
                    case 207:
                        throw new CreateIncomingTransactionsMultiStatus(
                            JsonUtils.Deserialize<TransactionsMultiResponse>(responseBody)
                        );
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
            throw new KardApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<FraudulentTransactionObject>> CreateFraudMarkersAsyncCore(
        string organizationId,
        FraudulentTransactionRequestBody request,
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
                        "/v2/issuers/{0}/fraud",
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
                var responseData = JsonUtils.Deserialize<FraudulentTransactionObject>(
                    responseBody
                )!;
                return new WithRawResponse<FraudulentTransactionObject>()
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
                    case 207:
                        throw new FraudMultiStatus(
                            JsonUtils.Deserialize<FraudulentTransactionResponse>(responseBody)
                        );
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

    private async Task<WithRawResponse<CreateAuditResponseBody>> CreateAuditsAsyncCore(
        string organizationId,
        string userId,
        CreateAuditRequestBody request,
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
                        "/v2/issuers/{0}/users/{1}/audits",
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
                var responseData = JsonUtils.Deserialize<CreateAuditResponseBody>(responseBody)!;
                return new WithRawResponse<CreateAuditResponseBody>()
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
                    case 207:
                        throw new CreateAuditMultiStatus(
                            JsonUtils.Deserialize<CreateAuditMultiStatusResponse>(responseBody)
                        );
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
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<ErrorResponse>(responseBody));
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
        WithRawResponse<CreateFileUploadUrlResponse>
    > CreateBulkTransactionsUploadUrlAsyncCore(
        string organizationId,
        CreateFileUploadRequestBody request,
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
                        "/v2/issuers/{0}/transactions/uploads",
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
                var responseData = JsonUtils.Deserialize<CreateFileUploadUrlResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CreateFileUploadUrlResponse>()
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
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
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

    private async Task<WithRawResponse<GetEarnedRewardsResponse>> GetEarnedRewardsAsyncCore(
        string organizationId,
        string userId,
        GetEarnedRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new KardFinancial.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("page[after]", request.PageAfter)
            .Add("page[before]", request.PageBefore)
            .Add("page[size]", request.PageSize)
            .Add("filter[status]", request.FilterStatus)
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/earned-rewards",
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
                var responseData = JsonUtils.Deserialize<GetEarnedRewardsResponse>(responseBody)!;
                return new WithRawResponse<GetEarnedRewardsResponse>()
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
                    case 400:
                        throw new InvalidRequest(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 401:
                        throw new UnauthorizedError(
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

    /// <summary>
    /// Call this endpoint to send all transactions made by all your enrolled users in your rewards program. The request body will depend on the transaction type.<br/>
    /// Please use the correct type when calling the endpoint:
    /// - `transaction`: These incoming transactions will be processed and matched by the Kard system. Learn more about the [Transaction CLO Matching](https://github.com/kard-financial/kard-postman#c-transaction-clo-matching) flow here.
    /// - `matchedTransaction`: For pre-matched transactions that need validation on match by the Kard system.
    /// - `coreTransaction`: For transactions from core banking systems with limited card-level data.<br/>
    ///
    /// <b>Required scopes:</b> `transaction:write`<br/>
    /// <b>Note:</b> `Maximum of 500 transactions can be created per request`.
    /// </summary>
    /// <example><code>
    /// await client.Transactions.CreateAsync(
    ///     "organization-123",
    ///     new TransactionsRequestBody
    ///     {
    ///         Data = new List&lt;Transactions&gt;()
    ///         {
    ///             new Transactions(
    ///                 new Transactions.Transaction(
    ///                     new TransactionsRequest
    ///                     {
    ///                         Id = "309rjfoincor3icno3rind093cdow3jciwjdwcm",
    ///                         Attributes = new TransactionsAttributes
    ///                         {
    ///                             UserId = "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
    ///                             Status = TransactionStatus.Approved,
    ///                             Amount = 1000,
    ///                             Subtotal = 800,
    ///                             Currency = "USD",
    ///                             Direction = DirectionType.Debit,
    ///                             PaymentType = TransactionPaymentType.Card,
    ///                             Description = "ADVANCEAUTO",
    ///                             Description2 = "ADVANCEAUTO",
    ///                             Mcc = "1234",
    ///                             CardBin = "123456",
    ///                             CardLastFour = "4321",
    ///                             AuthorizationDate = new DateTime(2021, 07, 02, 17, 47, 06, 000),
    ///                             Merchant = new Merchant
    ///                             {
    ///                                 Id = "12345678901234567",
    ///                                 Name = "ADVANCEAUTO",
    ///                                 AddrStreet = "125 Main St",
    ///                                 AddrCity = "Philadelphia",
    ///                                 AddrState = States.Pa,
    ///                                 AddrZipcode = "19147",
    ///                                 AddrCountry = "United States",
    ///                                 Latitude = "37.9419429",
    ///                                 Longitude = "-73.1446869",
    ///                                 StoreId = "12345",
    ///                             },
    ///                             AuthorizationCode = "123456",
    ///                             RetrievalReferenceNumber = "100804333919",
    ///                             AcquirerReferenceNumber = "1234567890123456789012345678",
    ///                             SystemTraceAuditNumber = "333828",
    ///                             TransactionId = "2467de37-cbdc-416d-a359-75de87bfffb0",
    ///                             CardProductId = "1234567890123456789012345678",
    ///                             ProcessorMids = new ProcessorMid(
    ///                                 new ProcessorMid.Visa(
    ///                                     new VisaMid
    ///                                     {
    ///                                         Mids = new VisaMidDetails
    ///                                         {
    ///                                             Vmid = "12345678901",
    ///                                             Vsid = "12345678",
    ///                                         },
    ///                                     }
    ///                                 )
    ///                             ),
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<TransactionsResponse> CreateAsync(
        string organizationId,
        TransactionsRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TransactionsResponse>(
            CreateAsyncCore(organizationId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Call this endpoint to flag a submitted transaction as fraudulent. This will prevent it from being rewarded.<br/>
    ///
    /// <b>Required scopes:</b>  `transaction:write`<br/>
    /// <b>Note:</b> `Maximum of 500 fraudulent transactions can be created per request`.
    /// </summary>
    /// <example><code>
    /// await client.Transactions.CreateFraudMarkersAsync(
    ///     "organization-123",
    ///     new FraudulentTransactionRequestBody
    ///     {
    ///         Data = new List&lt;FraudulentTransactionData&gt;()
    ///         {
    ///             new FraudulentTransactionData
    ///             {
    ///                 Id = "myTxnId12345",
    ///                 Type = "fraudulentTransaction",
    ///                 Attributes = new FraudulentTransactionAttributes { UserId = "userId123" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<FraudulentTransactionObject> CreateFraudMarkersAsync(
        string organizationId,
        FraudulentTransactionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<FraudulentTransactionObject>(
            CreateFraudMarkersAsyncCore(organizationId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Call this endpoint to request that a particular transaction be audited further by the Kard system, in the event of a missing cashback claim, incorrect cashback amount claim or other mis-match claims.<br/>
    /// <b>Required scopes:</b> `audit:write`
    /// </summary>
    /// <example><code>
    /// await client.Transactions.CreateAuditsAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     new CreateAuditRequestBody
    ///     {
    ///         Data = new List&lt;CreateAuditRequestDataUnion&gt;()
    ///         {
    ///             new CreateAuditRequestDataUnion(
    ///                 new CreateAuditRequestDataUnion.Audit(
    ///                     new AuditRequestData
    ///                     {
    ///                         Attributes = new AuditAttributes
    ///                         {
    ///                             AuditCode = 8001,
    ///                             MerchantName = "Caribbean Goodness",
    ///                             AuditDescription = "duplicate transaction",
    ///                             TransactionId = "issuerTransaction123",
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateAuditResponseBody> CreateAuditsAsync(
        string organizationId,
        string userId,
        CreateAuditRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateAuditResponseBody>(
            CreateAuditsAsyncCore(organizationId, userId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Generates up to 10 presigned PUT URLs for uploading JSONL transaction files (up to 5GB each) directly
    /// to storage. Each URL is valid for 15 minutes. Use the returned URL to upload the file via an HTTP PUT request with the
    /// binary file content as the body. If a URL expires before the upload completes, you must request a new one.
    /// Files can be uploaded as plain JSONL or as a gzip-compressed file.
    /// Supports both `incomingTransactionsFile` for daily transaction ingestion and `historicalTransactionsFile` for historical transaction ingestion. See the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide for details on the historical flow.
    /// <b>Required scopes:</b> `files:write`
    /// </summary>
    /// <example><code>
    /// await client.Transactions.CreateBulkTransactionsUploadUrlAsync(
    ///     "organization-123",
    ///     new CreateFileUploadRequestBody
    ///     {
    ///         Data = new List&lt;CreateFileUploadData&gt;()
    ///         {
    ///             new CreateFileUploadData
    ///             {
    ///                 Type = FileUploadType.IncomingTransactionsFile,
    ///                 Attributes = new CreateFileUploadAttributes
    ///                 {
    ///                     Filename = "transaction_12345.jsonl",
    ///                 },
    ///             },
    ///             new CreateFileUploadData
    ///             {
    ///                 Type = FileUploadType.IncomingTransactionsFile,
    ///                 Attributes = new CreateFileUploadAttributes
    ///                 {
    ///                     Filename = "transaction_67890.jsonl",
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateFileUploadUrlResponse> CreateBulkTransactionsUploadUrlAsync(
        string organizationId,
        CreateFileUploadRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateFileUploadUrlResponse>(
            CreateBulkTransactionsUploadUrlAsyncCore(
                organizationId,
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Retrieve rewarded transaction history for a specific user. By default this returns only SETTLED transactions within the last 12 months.
    /// <br/>
    /// <b>Required scopes:</b> `transaction:read`
    /// <br/>
    /// <b>Query Limit:</b> Maximum of 12 months of transaction data can be queried.
    /// </summary>
    /// <example><code>
    /// await client.Transactions.GetEarnedRewardsAsync(
    ///     "org-123",
    ///     "user-456",
    ///     new GetEarnedRewardsRequest
    ///     {
    ///         PageSize = 10,
    ///         FilterStatus = RewardedTransactionStatus.Approved,
    ///         Include = "merchant,offer",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetEarnedRewardsResponse> GetEarnedRewardsAsync(
        string organizationId,
        string userId,
        GetEarnedRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetEarnedRewardsResponse>(
            GetEarnedRewardsAsyncCore(organizationId, userId, request, options, cancellationToken)
        );
    }
}
