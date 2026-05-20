using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[Serializable]
public record GetPlacementRequest
{
    /// <summary>
    /// CSV list of related resources to embed in the `included` array (allowed value is `contentStrategy`).
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
