using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Users;

[Serializable]
public record ActivateOfferRequest
{
    /// <summary>
    /// UI component types to include in the offer response (when include=offer).
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ComponentType> SupportedComponents { get; set; } = new List<ComponentType>();

    /// <summary>
    /// Related resources to include in the response. Allowed value is `offer`.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ActivateOfferIncludeOption> Include { get; set; } =
        new List<ActivateOfferIncludeOption>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
