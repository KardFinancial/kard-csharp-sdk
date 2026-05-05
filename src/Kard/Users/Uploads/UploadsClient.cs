using global::System.Text.Json;
using Kard;
using Kard.Core;

namespace Kard.Users;

public partial class UploadsClient : IUploadsClient
{
    private readonly RawClient _client;

    internal UploadsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateUploadResponseObject>> CreateAsyncCore(
        string organizationId,
        string userId,
        CreateUploadRequestObject request,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/uploads",
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
                var responseData = JsonUtils.Deserialize<CreateUploadResponseObject>(responseBody)!;
                return new WithRawResponse<CreateUploadResponseObject>()
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

    private async Task<WithRawResponse<CreateUploadPartResponseObject>> CreatePartAsyncCore(
        string organizationId,
        string userId,
        string uploadId,
        CreateUploadPartRequestObject request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/uploads/{2}/parts",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId),
                        ValueConvert.ToPathParameterString(uploadId)
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
                var responseData = JsonUtils.Deserialize<CreateUploadPartResponseObject>(
                    responseBody
                )!;
                return new WithRawResponse<CreateUploadPartResponseObject>()
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
                    case 207:
                        throw new UploadPartMultiStatus(
                            JsonUtils.Deserialize<CreateUploadPartMultiStatusResponse>(responseBody)
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

    private async Task<WithRawResponse<UpdateUploadResponseObject>> UpdateAsyncCore(
        string organizationId,
        string userId,
        string uploadId,
        UpdateUploadRequestObject request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "/v2/issuers/{0}/users/{1}/uploads/{2}",
                        ValueConvert.ToPathParameterString(organizationId),
                        ValueConvert.ToPathParameterString(userId),
                        ValueConvert.ToPathParameterString(uploadId)
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
                var responseData = JsonUtils.Deserialize<UpdateUploadResponseObject>(responseBody)!;
                return new WithRawResponse<UpdateUploadResponseObject>()
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

    /// <summary>
    /// <b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.
    ///
    /// Call this endpoint to create an upload session and retrieve an upload ID. Using the upload ID in the [Add Upload
    /// Part](/api/uploads/create-upload-part) endpoint, historical transactions can be sent in batches for further processing.
    /// <b>Required scopes:</b> `transaction:write`
    /// </summary>
    /// <example><code>
    /// await client.Users.Uploads.CreateAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     new CreateUploadRequestObject
    ///     {
    ///         Data = new CreateUploadRequestDataUnion(
    ///             new CreateUploadRequestDataUnion.HistoricalTransactionStart(
    ///                 new StartHistoricalUploadNoData { Attributes = new EmptyObject() }
    ///             )
    ///         ),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateUploadResponseObject> CreateAsync(
        string organizationId,
        string userId,
        CreateUploadRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateUploadResponseObject>(
            CreateAsyncCore(organizationId, userId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// <b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.
    ///
    /// Call this endpoint using the upload ID provided in the [Create Upload](/api/uploads/create-upload) endpoint to add parts to your upload. Currently, this endpoint supports adding historical transactions.
    /// <b>Required scopes:</b> `transaction:write`
    /// <b>Note:</b> `Maximum of 500 transactions can be uploaded per request`.
    /// </summary>
    /// <example><code>
    /// await client.Users.Uploads.CreatePartAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     "upload-123",
    ///     new CreateUploadPartRequestObject
    ///     {
    ///         Data = new List&lt;CreateUploadPartDataUnion&gt;()
    ///         {
    ///             new CreateUploadPartDataUnion(
    ///                 new CreateUploadPartDataUnion.HistoricalTransaction(
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
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateUploadPartResponseObject> CreatePartAsync(
        string organizationId,
        string userId,
        string uploadId,
        CreateUploadPartRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateUploadPartResponseObject>(
            CreatePartAsyncCore(
                organizationId,
                userId,
                uploadId,
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// <b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.
    ///
    /// Call this endpoint to update your upload session. Currently, you can signal completing a historical transactions upload.
    /// <b>Required scopes:</b> `transaction:write`
    /// </summary>
    /// <example><code>
    /// await client.Users.Uploads.UpdateAsync(
    ///     "organization-123",
    ///     "user-123",
    ///     "upload-123",
    ///     new UpdateUploadRequestObject
    ///     {
    ///         Data = new UpdateUploadRequestDataUnion(
    ///             new UpdateUploadRequestDataUnion.HistoricalTransactionComplete(
    ///                 new HistoricalTransactionCompleteNoData
    ///                 {
    ///                     Id = "7e382223-b9a5-4825-91fb-436c8957a2e7",
    ///                     Attributes = new EmptyObject(),
    ///                 }
    ///             )
    ///         ),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<UpdateUploadResponseObject> UpdateAsync(
        string organizationId,
        string userId,
        string uploadId,
        UpdateUploadRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateUploadResponseObject>(
            UpdateAsyncCore(organizationId, userId, uploadId, request, options, cancellationToken)
        );
    }
}
