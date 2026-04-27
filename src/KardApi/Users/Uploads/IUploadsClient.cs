using KardApi;

namespace KardApi.Users;

public partial interface IUploadsClient
{
    /// <summary>
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
