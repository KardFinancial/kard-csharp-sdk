namespace Kard;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class MultiStatus(CreateUsersMultiStatusResponse body)
    : KardApiException("MultiStatus", 207, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new CreateUsersMultiStatusResponse Body => body;
}
