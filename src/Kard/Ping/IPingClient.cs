namespace Kard;

public partial interface IPingClient
{
    /// <summary>
    /// Call this endpoint to verify network connectivity and service availability.
    /// </summary>
    WithRawResponseTask<PingResponseObject> PingAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
