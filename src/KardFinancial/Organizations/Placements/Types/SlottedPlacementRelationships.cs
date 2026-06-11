using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Relationship block for a batch-activation or group placement.
/// </summary>
[Serializable]
public record SlottedPlacementRelationships : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Resource identifiers for the slots that make up the placement. Each entry corresponds to a `batchActivationSlot` resource that appears in `included` when the request asks for `slots` (or any deeper path that implies it).
    /// </summary>
    [JsonPropertyName("slots")]
    public required ToManyRelationship Slots { get; set; }

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
