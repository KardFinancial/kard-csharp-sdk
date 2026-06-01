using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for a push-notification placement
/// </summary>
[Serializable]
public record PushNotificationPlacementAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the placement
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// ID of the organization this placement belongs to
    /// </summary>
    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    /// <summary>
    /// Delivery cadence for the notification
    /// </summary>
    [JsonPropertyName("cadence")]
    public required Cadence Cadence { get; set; }

    /// <summary>
    /// ID of the content strategy linked to this placement, if any. Retained alongside `relationships.contentStrategy` for backward compatibility.
    /// </summary>
    [JsonPropertyName("contentStrategyId")]
    public string? ContentStrategyId { get; set; }

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
