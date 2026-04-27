using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

[Serializable]
public record GetOffersByPlacementRequest
{
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
