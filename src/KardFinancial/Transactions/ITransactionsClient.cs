namespace KardFinancial;

public partial interface ITransactionsClient
{
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
    WithRawResponseTask<TransactionsResponse> CreateAsync(
        string organizationId,
        TransactionsRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Call this endpoint to flag a submitted transaction as fraudulent. This will prevent it from being rewarded.<br/>
    ///
    /// <b>Required scopes:</b>  `transaction:write`<br/>
    /// <b>Note:</b> `Maximum of 500 fraudulent transactions can be created per request`.
    /// </summary>
    WithRawResponseTask<FraudulentTransactionObject> CreateFraudMarkersAsync(
        string organizationId,
        FraudulentTransactionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Call this endpoint to request that a particular transaction be audited further by the Kard system, in the event of a missing cashback claim, incorrect cashback amount claim or other mis-match claims.<br/>
    /// <b>Required scopes:</b> `audit:write`
    /// </summary>
    WithRawResponseTask<CreateAuditResponseBody> CreateAuditsAsync(
        string organizationId,
        string userId,
        CreateAuditRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates up to 10 presigned PUT URLs for uploading JSONL transaction files (up to 5GB each) directly
    /// to storage. Each URL is valid for 15 minutes. Use the returned URL to upload the file via an HTTP PUT request with the
    /// binary file content as the body. If a URL expires before the upload completes, you must request a new one.
    /// Files can be uploaded as plain JSONL or as a gzip-compressed file.
    /// Supports both `incomingTransactionsFile` for daily transaction ingestion and `historicalTransactionsFile` for historical transaction ingestion. See the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide for details on the historical flow.
    /// <b>Required scopes:</b> `files:write`
    /// </summary>
    WithRawResponseTask<CreateFileUploadUrlResponse> CreateBulkTransactionsUploadUrlAsync(
        string organizationId,
        CreateFileUploadRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve rewarded transaction history for a specific user. By default this returns only SETTLED transactions within the last 12 months.
    /// <br/>
    /// <b>Required scopes:</b> `transaction:read`
    /// <br/>
    /// <b>Query Limit:</b> Maximum of 12 months of transaction data can be queried.
    /// </summary>
    WithRawResponseTask<GetEarnedRewardsResponse> GetEarnedRewardsAsync(
        string organizationId,
        string userId,
        GetEarnedRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
