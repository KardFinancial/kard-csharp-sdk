namespace Kard;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class CreateAuditMultiStatus(CreateAuditMultiStatusResponse body)
    : KardApiApiException("CreateAuditMultiStatus", 207, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new CreateAuditMultiStatusResponse Body => body;
}
