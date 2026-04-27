using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[Serializable]
public record BoostOfferRequest
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
    public IEnumerable<BoostOfferIncludeOption> Include { get; set; } =
        new List<BoostOfferIncludeOption>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
