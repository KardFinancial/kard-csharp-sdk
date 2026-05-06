using KardFinancial;

namespace KardFinancial.Users;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UploadPartMultiStatus(CreateUploadPartMultiStatusResponse body)
    : KardApiException("UploadPartMultiStatus", 207, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new CreateUploadPartMultiStatusResponse Body => body;
}
