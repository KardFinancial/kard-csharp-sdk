using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for updating a content strategy. All fields are required.
/// </summary>
[Serializable]
public record UpdateContentStrategyAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the content strategy (unique within an organization)
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Filters applied when selecting offers for the strategy
    /// </summary>
    [JsonPropertyName("filters")]
    public IEnumerable<ContentStrategyFilter> Filters { get; set; } =
        new List<ContentStrategyFilter>();

    /// <summary>
    /// Merchant categories to include
    /// </summary>
    [JsonPropertyName("categories")]
    public IEnumerable<CategoryOption> Categories { get; set; } = new List<CategoryOption>();

    /// <summary>
    /// Merchant categories to exclude
    /// </summary>
    [JsonPropertyName("categoryExclusions")]
    public IEnumerable<CategoryOption> CategoryExclusions { get; set; } =
        new List<CategoryOption>();

    /// <summary>
    /// Merchant IDs to exclude
    /// </summary>
    [JsonPropertyName("merchantExclusions")]
    public IEnumerable<string> MerchantExclusions { get; set; } = new List<string>();

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
