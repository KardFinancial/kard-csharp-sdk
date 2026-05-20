using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Paginated list of placements
/// </summary>
[Serializable]
public record PlacementListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of placement resources
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<PlacementFormatUnion> Data { get; set; } = new List<PlacementFormatUnion>();

    /// <summary>
    /// Related resources requested via the `include` query parameter. Only populated when `include=contentStrategy` is supplied and at least one placement in `data` is linked to a content strategy.
    /// </summary>
    [JsonPropertyName("included")]
    public IEnumerable<ContentStrategyResponse>? Included { get; set; }

    [JsonPropertyName("links")]
    public Links? Links { get; set; }

    /// <summary>
    /// Pagination metadata
    /// </summary>
    [JsonPropertyName("meta")]
    public OrganizationPaginationMetadata? Meta { get; set; }

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
