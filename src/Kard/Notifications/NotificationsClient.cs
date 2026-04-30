using Kard.Core;
using Kard.Notifications;

namespace Kard;

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
