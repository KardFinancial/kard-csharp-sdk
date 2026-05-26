using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// A slot in a batch-activation placement at creation time
/// </summary>
[Serializable]
public record CreateBatchActivationSlot : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the content strategy that fills this slot
    /// </summary>
    [JsonPropertyName("contentStrategyId")]
    public required string ContentStrategyId { get; set; }

    /// <summary>
    /// Customer-defined alias for the slot, unique within the placement
    /// </summary>
    [JsonPropertyName("alias")]
    public required string Alias { get; set; }

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
