namespace KardFinancial;

public partial interface IFilesClient
{
    /// <summary>
    /// Retrieves metadata for files associated with a specific issuer/organization.
    /// This endpoint supports pagination and sorting options to efficiently navigate
    /// through potentially large sets of file metadata.
    /// <b>Required scopes:</b> `files.read`
    /// </summary>
    WithRawResponseTask<GetFilesMetadataResponse> GetMetadataAsync(
        string organizationId,
        GetFilesMetadataRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
