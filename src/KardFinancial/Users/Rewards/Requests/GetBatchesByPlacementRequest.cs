using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[Serializable]
public record GetBatchesByPlacementRequest
{
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
