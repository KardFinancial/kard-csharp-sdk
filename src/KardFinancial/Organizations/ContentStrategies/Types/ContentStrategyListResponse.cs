using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Paginated list of content strategies
/// </summary>
[Serializable]
public record ContentStrategyListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of content strategy resources
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<ContentStrategyResponse> Data { get; set; } =
        new List<ContentStrategyResponse>();

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
