using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Notifications;

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
