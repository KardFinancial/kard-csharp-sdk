using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

[Serializable]
public record GetLocationsByUserRequest
{
    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? PageAfter { get; set; }

    [JsonIgnore]
    public string? PageBefore { get; set; }

    [JsonIgnore]
    public string? FilterName { get; set; }

    [JsonIgnore]
    public string? FilterCity { get; set; }

    [JsonIgnore]
    public string? FilterZipCode { get; set; }

    [JsonIgnore]
    public State? FilterState { get; set; }

    [JsonIgnore]
    public CategoryOption? FilterCategory { get; set; }

    [JsonIgnore]
    public double? FilterLongitude { get; set; }

    [JsonIgnore]
    public double? FilterLatitude { get; set; }

    [JsonIgnore]
    public int? FilterRadius { get; set; }

    /// <summary>
    /// If provided, response will be sorted by the specified fields
    /// </summary>
    [JsonIgnore]
    public IEnumerable<LocationSortOptions> Sort { get; set; } = new List<LocationSortOptions>();

    /// <summary>
    /// CSV list of included resources in the response (e.g "offers,categories"). Allowed values are `offers` and `categories`.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Include { get; set; } = new List<string>();

    /// <summary>
    /// UI component types to include in included offers.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ComponentType> SupportedComponents { get; set; } = new List<ComponentType>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
