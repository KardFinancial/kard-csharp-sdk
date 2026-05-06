using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

[Serializable]
public record GetOffersByUserRequest
{
    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? PageAfter { get; set; }

    [JsonIgnore]
    public string? PageBefore { get; set; }

    /// <summary>
    /// Case-insensitive search string to filter offers by merchant name
    /// </summary>
    [JsonIgnore]
    public string? FilterSearch { get; set; }

    [JsonIgnore]
    public IEnumerable<PurchaseChannel>? FilterPurchaseChannel { get; set; }

    [JsonIgnore]
    public CategoryOption? FilterCategory { get; set; }

    [JsonIgnore]
    public bool? FilterIsTargeted { get; set; }

    /// <summary>
    /// If provided, response will be sorted by the specified fields
    /// </summary>
    [JsonIgnore]
    public IEnumerable<OfferSortOptions> Sort { get; set; } = new List<OfferSortOptions>();

    /// <summary>
    /// CSV list of included resources in the response (e.g "categories"). Allowed value is `categories`.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Include { get; set; } = new List<string>();

    /// <summary>
    /// UI component types to include in the response.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ComponentType> SupportedComponents { get; set; } = new List<ComponentType>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
