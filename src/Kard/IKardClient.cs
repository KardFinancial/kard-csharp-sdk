namespace Kard;

public partial interface IKardClient
{
    public IAuthClient Auth { get; }
    public IFilesClient Files { get; }
    public INotificationsClient Notifications { get; }
    public IOrganizationsClient Organizations { get; }
    public IPingClient Ping { get; }
    public ITransactionsClient Transactions { get; }
    public IUsersClient Users { get; }
}
