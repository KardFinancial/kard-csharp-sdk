using KardApi.Core;

namespace KardApi;

public partial class KardApiClient : IKardApiClient
{
    private readonly RawClient _client;

    public KardApiClient(
        string? clientId = null,
        string? clientSecret = null,
        ClientOptions? clientOptions = null
    )
    {
        clientId ??= GetFromEnvironmentOrThrow(
            "KARD_CLIENT_ID",
            "Please pass in clientId or set the environment variable KARD_CLIENT_ID."
        );
        clientSecret ??= GetFromEnvironmentOrThrow(
            "KARD_CLIENT_SECRET",
            "Please pass in clientSecret or set the environment variable KARD_CLIENT_SECRET."
        );
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "KardApi" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "kard-financial-sdk/0.0.2" },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var tokenProvider = new OAuthTokenProvider(
            clientId,
            clientSecret,
            new AuthClient(new RawClient(clientOptions))
        );
        clientOptionsWithAuth.Headers["Authorization"] =
            new Func<global::System.Threading.Tasks.ValueTask<string>>(async () =>
                await tokenProvider.GetAccessTokenAsync().ConfigureAwait(false)
            );
        _client = new RawClient(clientOptionsWithAuth);
        Auth = new AuthClient(_client);
        Files = new FilesClient(_client);
        Notifications = new NotificationsClient(_client);
        Organizations = new OrganizationsClient(_client);
        Ping = new PingClient(_client);
        Transactions = new TransactionsClient(_client);
        Users = new UsersClient(_client);
    }

    public IAuthClient Auth { get; }

    public IFilesClient Files { get; }

    public INotificationsClient Notifications { get; }

    public IOrganizationsClient Organizations { get; }

    public IPingClient Ping { get; }

    public ITransactionsClient Transactions { get; }

    public IUsersClient Users { get; }

    private static string GetFromEnvironmentOrThrow(string env, string message)
    {
        return Environment.GetEnvironmentVariable(env) ?? throw new Exception(message);
    }
}
