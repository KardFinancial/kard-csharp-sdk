using KardApi.Notifications;

namespace KardApi;

public partial interface INotificationsClient
{
    public ISubscriptionsClient Subscriptions { get; }
}
