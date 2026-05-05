using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;
using OneOf;

namespace Kard.Users;

[Serializable]
public record BoostOfferResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("data")]
    public required BoostOfferResponseData Data { get; set; }

    [JsonPropertyName("included")]
    public IEnumerable<OneOf<OfferDataUnion, CategoryIncluded>>? Included { get; set; }

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
