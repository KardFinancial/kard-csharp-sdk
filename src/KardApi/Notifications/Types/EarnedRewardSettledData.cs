using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[Serializable]
public record EarnedRewardSettledData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The internal ID of the notification
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("attributes")]
    public required EarnedRewardSettledAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public required EarnedRewardRelationships Relationships { get; set; }

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
