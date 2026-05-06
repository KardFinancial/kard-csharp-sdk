using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record TransactionsRequestBody : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Discriminated union representing the request body for submitting a transaction.
    /// Use `type` to distinguish between the two:
    /// - `transaction`: For transactions requiring processing and matching by the Kard system.
    /// - `matchedTransaction`: For pre-matched transactions that need validation on match by the Kard system.
    /// - `coreTransaction`: For transactions from core banking systems with limited card-level data.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<Transactions> Data { get; set; } = new List<Transactions>();

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
