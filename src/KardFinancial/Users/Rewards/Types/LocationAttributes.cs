using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

[Serializable]
public record LocationAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("address")]
    public required EligibilityLocationAddress Address { get; set; }

    [JsonPropertyName("coordinates")]
    public required Coordinates Coordinates { get; set; }

    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    [JsonPropertyName("operationHours")]
    public required OperationHours OperationHours { get; set; }

    /// <summary>
    /// List of ids associated with the location from third party partners. Only applicable for LOCAL locations.
    /// </summary>
    [JsonPropertyName("partnerIds")]
    public IEnumerable<LocationPartnerId> PartnerIds { get; set; } = new List<LocationPartnerId>();

    /// <summary>
    /// The kind of food or venue this location offers, for example "Pizza Restaurant".
    /// </summary>
    [JsonPropertyName("cuisine")]
    public CuisineOption? Cuisine { get; set; }

    /// <summary>
    /// Customer rating for this location.
    /// </summary>
    [JsonPropertyName("rating")]
    public LocationRating? Rating { get; set; }

    /// <summary>
    /// Typical price range for this location, rendered as dollar signs from "$" (least expensive) to "$$$$" (most expensive).
    /// </summary>
    [JsonPropertyName("priceLevel")]
    public string? PriceLevel { get; set; }

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
