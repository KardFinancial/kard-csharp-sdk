using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

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

    /// <summary>
    /// Case-insensitive substring match on the location's city. Never defines the search area; applied as an additional constraint alongside a radius search when `filter[latitude]`/`filter[longitude]`/`filter[radius]` are also provided.
    /// </summary>
    [JsonIgnore]
    public string? FilterCity { get; set; }

    /// <summary>
    /// Exact-match filter on the location's zip code. Never defines the search area; applied as an additional constraint alongside a radius search when `filter[latitude]`/`filter[longitude]`/`filter[radius]` are also provided.
    /// </summary>
    [JsonIgnore]
    public string? FilterZipCode { get; set; }

    /// <summary>
    /// Exact-match filter on the location's state. Never defines the search area; applied as an additional constraint alongside a radius search when `filter[latitude]`/`filter[longitude]`/`filter[radius]` are also provided.
    /// </summary>
    [JsonIgnore]
    public State? FilterState { get; set; }

    [JsonIgnore]
    public CategoryOption? FilterCategory { get; set; }

    /// <summary>
    /// Longitude of the point to search around. Must be provided together with `filter[latitude]`; combine with `filter[radius]` to run a radius search.
    /// </summary>
    [JsonIgnore]
    public double? FilterLongitude { get; set; }

    /// <summary>
    /// Latitude of the point to search around. Must be provided together with `filter[longitude]`; combine with `filter[radius]` to run a radius search.
    /// </summary>
    [JsonIgnore]
    public double? FilterLatitude { get; set; }

    /// <summary>
    /// Radius in miles to search around the point given by `filter[latitude]`/`filter[longitude]` (default 10, minimum 1). Has no effect unless both latitude and longitude are also provided — it is ignored when only `filter[zipCode]`, `filter[city]`, or `filter[state]` is used, without lat/long.
    /// </summary>
    [JsonIgnore]
    public int? FilterRadius { get; set; }

    /// <summary>
    /// If provided, response will be sorted by the specified fields. Defaults to newest first, equivalent to descending `createdDate`; when `filter[latitude]`/`filter[longitude]` are provided, locations are ordered by ascending distance from that point first, then newest first.
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
