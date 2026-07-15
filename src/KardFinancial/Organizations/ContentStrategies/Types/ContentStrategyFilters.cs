using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Filters applied when selecting offers for a content strategy
/// </summary>
[Serializable]
public record ContentStrategyFilters : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Merchant categories to include
    /// </summary>
    [JsonPropertyName("categories")]
    public IEnumerable<string>? Categories { get; set; }

    /// <summary>
    /// Merchant categories to exclude
    /// </summary>
    [JsonPropertyName("categoryExclusions")]
    public IEnumerable<string>? CategoryExclusions { get; set; }

    /// <summary>
    /// Merchant IDs to exclude
    /// </summary>
    [JsonPropertyName("merchantExclusions")]
    public IEnumerable<string>? MerchantExclusions { get; set; }

    /// <summary>
    /// Offer features to filter by
    /// </summary>
    [JsonPropertyName("offerFeatures")]
    public IEnumerable<OfferFeatures>? OfferFeatures { get; set; }

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
