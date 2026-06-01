using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Relationship block for a `batchActivationSlot` resource.
/// </summary>
[Serializable]
public record BatchActivationSlotRelationships : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Reference to the placement that fills this slot. The referenced placement provides the slot's content strategy and offer-count cap; request `?include=slots.placement` to embed it in `included`.
    /// </summary>
    [JsonPropertyName("placement")]
    public required ToOneRelationship Placement { get; set; }

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
