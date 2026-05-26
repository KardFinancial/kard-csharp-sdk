using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

[Serializable]
public record ActivatePlacementSlotResponseAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the placement
    /// </summary>
    [JsonPropertyName("placementId")]
    public required string PlacementId { get; set; }

    /// <summary>
    /// Stable identifier for the slot within the placement
    /// </summary>
    [JsonPropertyName("slotId")]
    public required string SlotId { get; set; }

    [JsonPropertyName("eventCode")]
    public required string EventCode { get; set; }

    [JsonPropertyName("medium")]
    public required string Medium { get; set; }

    [JsonPropertyName("eventDate")]
    public required DateTime EventDate { get; set; }

    /// <summary>
    /// All offer IDs that resolved under the slot's content strategy and had
    /// per-offer `offerAttribution` ACTIVATE events written. The partner can use
    /// this to render the batch immediately without an extra round-trip.
    /// </summary>
    [JsonPropertyName("offerIds")]
    public IEnumerable<string> OfferIds { get; set; } = new List<string>();

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
