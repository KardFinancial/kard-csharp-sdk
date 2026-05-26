using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

/// <summary>
/// Attributes for a slot-level activation event on a batch-activation placement.
/// A slot activation also writes per-offer `offerAttribution` ACTIVATE events for
/// every offer resolved by the slot's content strategy (see `ActivatePlacementSlot`).
/// </summary>
[Serializable]
public record PlacementSlotAttributionAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The slot ID (matches `state.slotId`)
    /// </summary>
    [JsonPropertyName("entityId")]
    public required string EntityId { get; set; }

    [JsonPropertyName("eventCode")]
    public required EventCode EventCode { get; set; }

    [JsonPropertyName("medium")]
    public required PlacementSlotMedium Medium { get; set; }

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
