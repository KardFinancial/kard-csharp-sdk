using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Notifications;

[Serializable]
public record UpdateSubscriptionRequestAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the event for the subscription
    /// </summary>
    [JsonPropertyName("eventName")]
    public NotificationType? EventName { get; set; }

    /// <summary>
    /// The URL where notifications will be delivered
    /// </summary>
    [JsonPropertyName("webhookUrl")]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// Indicates whether the subscription is active
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
