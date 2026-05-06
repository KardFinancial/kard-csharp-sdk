using KardFinancial;

namespace KardFinancial.Notifications;

public partial interface ISubscriptionsClient
{
    /// <summary>
    /// Call this endpoint to fetch the subscriptions of the provided issuer.<br/>
    /// <b>Required scopes:</b> `notifications:read`
    /// </summary>
    WithRawResponseTask<SubscriptionsResponseObject> GetAsync(
        string organizationId,
        GetSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Call this endpoint to subscribe to notification events.<br/>
    /// <b>Required scopes:</b> `notifications:write`
    /// </summary>
    WithRawResponseTask<CreateSubscriptionsResponseObject> CreateAsync(
        string organizationId,
        SubscriptionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Call this endpoint to update existing notification subscriptions.<br/>
    /// <b>Required scopes:</b> `notifications:write`
    /// </summary>
    WithRawResponseTask<UpdateSubscriptionsResponseObject> UpdateAsync(
        string organizationId,
        string subscriptionId,
        UpdateSubscriptionRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
