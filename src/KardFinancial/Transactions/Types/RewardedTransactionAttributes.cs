using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record RewardedTransactionAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Status of the rewarded transaction
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "SETTLED";

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

    /// <summary>
    /// Payment status to issuer
    /// </summary>
    [JsonPropertyName("paidToIssuer")]
    public required PaymentStatus PaidToIssuer { get; set; }

    [JsonPropertyName("commissionEarned")]
    public required CommissionEarnedDetails CommissionEarned { get; set; }

    /// <summary>
    /// Timestamp representing the month when the transaction has been paid out to issuer
    /// </summary>
    [JsonPropertyName("payoutTimestamp")]
    public DateTime? PayoutTimestamp { get; set; }

    /// <summary>
    /// UI component data for the reward, built from the offer state persisted on the matched transaction (e.g. a progress bar for progressive and punch-card offers). Omitted when the reward carries no persisted state.
    /// </summary>
    [JsonPropertyName("components")]
    public OfferComponents? Components { get; set; }

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
