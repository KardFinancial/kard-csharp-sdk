using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[Serializable]
public record ListPlacementsRequest
{
    /// <summary>
    /// Filter by placement type (placementMainPage or placementPushNotification)
    /// </summary>
    [JsonIgnore]
    public PlacementTypeFilter? FilterType { get; set; }

    /// <summary>
    /// Filter by exact placement name (unique within an organization per type)
    /// </summary>
    [JsonIgnore]
    public string? FilterName { get; set; }

    /// <summary>
    /// Filter by the ID of the content strategy linked to the placement
    /// </summary>
    [JsonIgnore]
    public string? FilterContentStrategyId { get; set; }

    /// <summary>
    /// CSV list of related resources to embed in the `included` array (allowed value is `contentStrategy`).
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <summary>
    /// Cursor value for the next page of results
    /// </summary>
    [JsonIgnore]
    public string? PageAfter { get; set; }

    /// <summary>
    /// Maximum number of records to return [1 - 200] (default = 200)
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
