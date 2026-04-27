using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

[Serializable]
public record AttributionState : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The position of the offer in the list shown to the user (1-indexed)
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    /// <summary>
    /// The active filters when the user saw the offer
    /// </summary>
    [JsonPropertyName("filters")]
    public IEnumerable<AttributionFilter>? Filters { get; set; }

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
