using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for a content strategy
/// </summary>
[Serializable]
public record ContentStrategyAttributes : IJsonOnDeserialized
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
    /// ID of the organization this content strategy belongs to
    /// </summary>
    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

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

    /// <summary>
    /// When the content strategy was created (ISO 8601 UTC)
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the content strategy was last modified (ISO 8601 UTC)
    /// </summary>
    [JsonPropertyName("lastModified")]
    public required DateTime LastModified { get; set; }

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
