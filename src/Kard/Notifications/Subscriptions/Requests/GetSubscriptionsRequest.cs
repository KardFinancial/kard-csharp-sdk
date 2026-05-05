using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Notifications;

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
