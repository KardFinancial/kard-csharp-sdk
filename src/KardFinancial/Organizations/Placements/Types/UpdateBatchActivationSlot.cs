using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// A slot in a batch-activation placement at update time
/// </summary>
[Serializable]
public record UpdateBatchActivationSlot : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Existing slot identifier. Echo the value from a prior GET to keep the slot stable; omit to mint a fresh slot. If the placementId changes, the slotId is regenerated regardless of what was echoed.
    /// </summary>
    [JsonPropertyName("slotId")]
    public string? SlotId { get; set; }

    /// <summary>
    /// ID of another placement that fills this slot. The referenced placement provides both the content strategy and the limit on the number of offers available to the slot.
    /// </summary>
    [JsonPropertyName("placementId")]
    public required string PlacementId { get; set; }

    /// <summary>
    /// Customer-defined alias for the slot, unique within the placement
    /// </summary>
    [JsonPropertyName("alias")]
    public required string Alias { get; set; }

    /// <summary>
    /// Optional short description of the slot, limited to 50 characters
    /// </summary>
    [JsonPropertyName("shortDescription")]
    public string? ShortDescription { get; set; }

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
