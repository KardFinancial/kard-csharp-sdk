namespace Kard;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class CreateIncomingTransactionsMultiStatus(TransactionsMultiResponse body)
    : KardApiException("CreateIncomingTransactionsMultiStatus", 207, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new TransactionsMultiResponse Body => body;
}
