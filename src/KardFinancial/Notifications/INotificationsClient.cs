using KardFinancial.Notifications;

namespace KardFinancial;

public partial interface INotificationsClient
{
    public ISubscriptionsClient Subscriptions { get; }
}
