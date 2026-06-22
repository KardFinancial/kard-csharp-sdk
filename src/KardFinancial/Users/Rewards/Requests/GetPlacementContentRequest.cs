using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[Serializable]
public record GetPlacementContentRequest
{
    /// <summary>
    /// CSV list of included resources in the response (e.g "categories"). Allowed value is `categories`. Only applies to standard placements (those returning `standardOffer` resources).
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
