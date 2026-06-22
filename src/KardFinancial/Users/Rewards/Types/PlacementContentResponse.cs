using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;
using OneOf;

namespace KardFinancial.Users;

/// <summary>
/// Combined placement-content response, shaped as a JSON:API document. The placement is resolved server-side: a standard placement yields `standardOffer` resources (with `links`, optional `included` categories, and `meta`), while a batch-activation or group placement yields `placementBatch` slot resources. Callers distinguish the two by each resource's `type` rather than a separate discriminator, and the payload mirrors Get Offers By Placement / Get Batches By Placement exactly.
/// </summary>
[Serializable]
public record PlacementContentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("data")]
    public IEnumerable<OneOf<OfferDataUnion, PlacementBatchData>> Data { get; set; } =
        new List<OneOf<OfferDataUnion, PlacementBatchData>>();

    [JsonPropertyName("links")]
    public Links? Links { get; set; }

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
