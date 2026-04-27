using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[Serializable]
public record GetEarnedRewardsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("data")]
    public IEnumerable<RewardedTransactionUnion> Data { get; set; } =
        new List<RewardedTransactionUnion>();

    [JsonPropertyName("links")]
    public required Links Links { get; set; }

    /// <summary>
    /// Additional metadata for the earned rewards response.
    /// </summary>
    [JsonPropertyName("meta")]
    public required GetEarnedRewardsMeta Meta { get; set; }

    /// <summary>
    /// Additional resources referenced in the response
    /// </summary>
    [JsonPropertyName("included")]
    public IEnumerable<TransactionIncludedResource>? Included { get; set; }

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
