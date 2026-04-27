namespace KardApi.Core;

public interface IIsRetryableContent
{
    public bool IsRetryable { get; }
}
