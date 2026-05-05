using Kard.Notifications;

namespace Kard;

public partial interface INotificationsClient
{
    public ISubscriptionsClient Subscriptions { get; }
}
