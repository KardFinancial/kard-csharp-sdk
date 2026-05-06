using KardFinancial.Core;
using KardFinancial.Notifications;

namespace KardFinancial;

public partial class NotificationsClient : INotificationsClient
{
    private readonly RawClient _client;

    internal NotificationsClient(RawClient client)
    {
        _client = client;
        Subscriptions = new SubscriptionsClient(_client);
    }

    public ISubscriptionsClient Subscriptions { get; }
}
