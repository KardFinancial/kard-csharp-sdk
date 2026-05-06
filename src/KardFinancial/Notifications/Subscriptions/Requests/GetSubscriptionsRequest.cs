using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Notifications;

[Serializable]
public record GetSubscriptionsRequest
{
    [JsonIgnore]
    public NotificationType? FilterEventName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
