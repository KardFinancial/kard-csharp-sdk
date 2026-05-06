namespace KardFinancial;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NetworkBlockedError(NetworkBlockedErrorBody body)
    : KardApiException("NetworkBlockedError", 403, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new NetworkBlockedErrorBody Body => body;
}
