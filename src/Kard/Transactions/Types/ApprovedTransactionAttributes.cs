using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record ApprovedTransactionAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Status of the approved transaction
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "APPROVED";

    /// <summary>
    /// The transaction identifier
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

    /// <summary>
    /// Transaction amount in cents
    /// </summary>
    [JsonPropertyName("transactionAmountInCents")]
    public required int TransactionAmountInCents { get; set; }

    /// <summary>
    /// Timestamp of the transaction in ISO 8601 format
    /// </summary>
    [JsonPropertyName("transactionTimestamp")]
    public required DateTime TransactionTimestamp { get; set; }

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
