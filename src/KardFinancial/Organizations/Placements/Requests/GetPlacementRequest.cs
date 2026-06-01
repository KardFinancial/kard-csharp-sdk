using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[Serializable]
public record GetPlacementRequest
{
    /// <summary>
    /// CSV list of related resources to embed in the `included` array. Supported paths: `contentStrategy` (the direct content strategy of a non-batch placement), `slots` (the slot resources of a batch-activation placement), `slots.placement` (and the placement each slot references), and `slots.placement.contentStrategy` (and the content strategy of each referenced placement). Dotted paths implicitly include all intermediate resources.
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
