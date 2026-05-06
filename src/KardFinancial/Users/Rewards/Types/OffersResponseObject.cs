using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;
using OneOf;

namespace KardFinancial.Users;

[Serializable]
public record OffersResponseObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("data")]
    public IEnumerable<OfferDataUnion> Data { get; set; } = new List<OfferDataUnion>();

    [JsonPropertyName("links")]
    public required Links Links { get; set; }

    [JsonPropertyName("included")]
    public IEnumerable<OneOf<CategoryIncluded>>? Included { get; set; }

    [JsonPropertyName("meta")]
    public OffersMeta? Meta { get; set; }

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
