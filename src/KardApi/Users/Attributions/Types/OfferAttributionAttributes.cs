using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

[Serializable]
public record OfferAttributionAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The offer ID
    /// </summary>
    [JsonPropertyName("entityId")]
    public required string EntityId { get; set; }

    [JsonPropertyName("eventCode")]
    public required EventCode EventCode { get; set; }

    [JsonPropertyName("medium")]
    public required OfferMedium Medium { get; set; }

    /// <summary>
    /// The timestamp of the attribution event.
    /// Must be in ISO 8601 format (e.g., "2025-01-01T00:00:00Z").
    /// </summary>
    [JsonPropertyName("eventDate")]
    public required DateTime EventDate { get; set; }

    /// <summary>
    /// Placement context for the attribution event
    /// </summary>
    [JsonPropertyName("state")]
    public AttributionState? State { get; set; }

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
