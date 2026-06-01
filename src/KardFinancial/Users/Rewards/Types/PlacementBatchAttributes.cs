using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

/// <summary>
/// Attributes of a placement batch slot.
/// </summary>
[Serializable]
public record PlacementBatchAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Display name for the slot. Falls back to the slot's customer-defined alias, or — when the alias is absent — the name of the placement referenced by the slot.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Short, human-readable description of how long the slot stays activated after a user taps activate. Derived from the parent placement's `refreshInterval` (e.g. `"Activated for 24 hours"`).
    /// </summary>
    [JsonPropertyName("shortDescription")]
    public required string ShortDescription { get; set; }

    /// <summary>
    /// Longer, human-readable description of the slot's activation behavior: clarifies that the offers displayed under this slot are the ones that will be activated for the user when they tap activate, and for how long they will remain active.
    /// </summary>
    [JsonPropertyName("longDescription")]
    public required string LongDescription { get; set; }

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
    /// Slot-level UI components. Carries a `cta` (POST to the slot's activate endpoint) when the slot has no active (non-expired) activation, or a `logoFlare` decoration when it does — mutually exclusive on a single slot.
    /// </summary>
    [JsonPropertyName("components")]
    public OfferComponents? Components { get; set; }

    /// <summary>
    /// Slot-level visual assets. Currently a single `IMG_VIEW` SVG showing the slot's initials, themed via the `--icon-fill` CSS custom property.
    /// </summary>
    [JsonPropertyName("assets")]
    public IEnumerable<Asset>? Assets { get; set; }

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
