using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Batch-activation placement resource data
/// </summary>
[Serializable]
public record BatchActivationPlacementData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the placement (UUID v7)
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("attributes")]
    public required BatchActivationPlacementAttributes Attributes { get; set; }

    /// <summary>
    /// JSON:API relationships for the placement. Always present on a batch-activation placement; the `slots` to-many relationship lists the slot resource identifiers.
    /// </summary>
    [JsonPropertyName("relationships")]
    public required BatchActivationPlacementRelationships Relationships { get; set; }

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
