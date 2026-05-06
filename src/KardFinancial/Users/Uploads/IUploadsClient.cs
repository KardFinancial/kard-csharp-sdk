using KardFinancial;

namespace KardFinancial.Users;

public partial interface IUploadsClient
{
    /// <summary>
    /// <b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.
    ///
    /// Call this endpoint to create an upload session and retrieve an upload ID. Using the upload ID in the [Add Upload
    /// Part](/api/uploads/create-upload-part) endpoint, historical transactions can be sent in batches for further processing.
    /// <b>Required scopes:</b> `transaction:write`
    /// </summary>
    WithRawResponseTask<CreateUploadResponseObject> CreateAsync(
        string organizationId,
        string userId,
        CreateUploadRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// <b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.
    ///
    /// Call this endpoint using the upload ID provided in the [Create Upload](/api/uploads/create-upload) endpoint to add parts to your upload. Currently, this endpoint supports adding historical transactions.
    /// <b>Required scopes:</b> `transaction:write`
    /// <b>Note:</b> `Maximum of 500 transactions can be uploaded per request`.
    /// </summary>
    WithRawResponseTask<CreateUploadPartResponseObject> CreatePartAsync(
        string organizationId,
        string userId,
        string uploadId,
        CreateUploadPartRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// <b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.
    ///
    /// Call this endpoint to update your upload session. Currently, you can signal completing a historical transactions upload.
    /// <b>Required scopes:</b> `transaction:write`
    /// </summary>
    WithRawResponseTask<UpdateUploadResponseObject> UpdateAsync(
        string organizationId,
        string userId,
        string uploadId,
        UpdateUploadRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
