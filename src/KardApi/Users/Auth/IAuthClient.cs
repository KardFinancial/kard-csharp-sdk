using KardApi;

namespace KardApi.Users;

public partial interface IAuthClient
{
    /// <summary>
    /// Retrieves an OAuth token for webview authentication.
    /// </summary>
    WithRawResponseTask<WebViewTokenResponse> GetWebViewTokenAsync(
        string organizationId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
