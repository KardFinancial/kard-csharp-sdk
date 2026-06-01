using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Relationship block for non-batch placements. Mirrors the `contentStrategyId` attribute so JSON:API clients can walk the graph.
/// </summary>
[Serializable]
public record PlacementRelationships : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Relationship to the content strategy that powers this placement. Present whenever the placement has been linked to a content strategy (`data.id` will be set). Omitted entirely when no content strategy is linked.
    /// </summary>
    [JsonPropertyName("contentStrategy")]
    public ToOneRelationship? ContentStrategy { get; set; }

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
