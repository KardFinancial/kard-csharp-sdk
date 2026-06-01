using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Single placement document, optionally with embedded related resources
/// </summary>
[Serializable]
public record PlacementResource : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Placement resource
    /// </summary>
    [JsonPropertyName("data")]
    public required PlacementFormatUnion Data { get; set; }

    /// <summary>
    /// Related resources requested via the `include` query parameter. Each entry is keyed by its `type` discriminant (`contentStrategy`, `batchActivationSlot`, `placementMainPage`, `placementPushNotification`).
    /// </summary>
    [JsonPropertyName("included")]
    public IEnumerable<IncludedResource>? Included { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
