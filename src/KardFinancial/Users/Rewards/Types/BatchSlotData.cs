using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

/// <summary>
/// One slot in a batch-activation placement, with freshness fields and the offers that resolve under the slot's content strategy.
/// </summary>
[Serializable]
public record BatchSlotData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stable identifier for the slot within the placement
    /// </summary>
    [JsonPropertyName("slotId")]
    public required string SlotId { get; set; }

    /// <summary>
    /// Customer-defined alias for the slot, unique within the placement
    /// </summary>
    [JsonPropertyName("alias")]
    public required string Alias { get; set; }

    /// <summary>
    /// Whether the slot is still considered "fresh" for the user. Set to false only when the slot's `expiresAt` is in the past AND the slot resolves to a non-empty offer set; an empty offer set keeps the slot active so partner UIs do not promote "tap to refresh" with nothing to show.
    /// </summary>
    [JsonPropertyName("isActive")]
    public required bool IsActive { get; set; }

    /// <summary>
    /// Timestamp of the most recent placementSlotAttribution ACTIVATE event for this (user, placement, slot). Absent for cold slots that have never been activated.
    /// </summary>
    [JsonPropertyName("lastActivatedAt")]
    public DateTime? LastActivatedAt { get; set; }

    /// <summary>
    /// Computed as `lastActivatedAt + placement.refreshInterval`. Absent for cold slots that have never been activated.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// The set of offers eligible for the user under this slot's content strategy.
    /// </summary>
    [JsonPropertyName("offers")]
    public IEnumerable<OfferDataUnion> Offers { get; set; } = new List<OfferDataUnion>();

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
