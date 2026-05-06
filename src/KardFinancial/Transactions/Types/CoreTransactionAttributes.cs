using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record CoreTransactionAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the user as defined on the issuers system
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    /// <summary>
    /// The transaction ID from the core banking system
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

    /// <summary>
    /// Transaction amount in cents
    /// </summary>
    [JsonPropertyName("amount")]
    public required int Amount { get; set; }

    /// <summary>
    /// Currency of transaction in ISO 4217 alpha-3 format
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    /// <summary>
    /// Description of transaction - usually includes merchant and other key details on transaction
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The direction in which the funds flow - DEBIT or CREDIT
    /// </summary>
    [JsonPropertyName("direction")]
    public required DirectionType Direction { get; set; }

    /// <summary>
    /// Transaction status (always SETTLED for core transactions)
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "SETTLED";

    /// <summary>
    /// Timestamp when transaction was settled. Date string should be in ISO 8601 format i.e.'YYYY-MM-DDThh:mm:ss.sTZD' where TZD = time zone designator (Z or +hh:mm or -hh:mm) i.e. 1994-11-05T08:15:30-05:00 OR 1994-11-05T08:15:30Z
    /// </summary>
    [JsonPropertyName("settledDate")]
    public required DateTime SettledDate { get; set; }

    /// <summary>
    /// Timestamp for transaction authorization. Date string should be in ISO 8601 format i.e.'YYYY-MM-DDThh:mm:ss.sTZD' where TZD = time zone designator (Z or +hh:mm or -hh:mm) i.e. 1994-11-05T08:15:30-05:00 OR 1994-11-05T08:15:30Z
    /// </summary>
    [JsonPropertyName("authorizationDate")]
    public required DateTime AuthorizationDate { get; set; }

    /// <summary>
    /// Deprecated. Use `financialInstitutionId` instead. Name of the financial institution.
    /// </summary>
    [JsonPropertyName("financialInstitutionName")]
    public string? FinancialInstitutionName { get; set; }

    /// <summary>
    /// Unique identifier of the financial institution
    /// </summary>
    [JsonPropertyName("financialInstitutionId")]
    public string? FinancialInstitutionId { get; set; }

    /// <summary>
    /// Last four digits of the card(s) that may have been used for the transaction. When the issuer cannot determine which specific card was used, multiple values are provided as candidates.
    /// </summary>
    [JsonPropertyName("cardLastFours")]
    public IEnumerable<string>? CardLastFours { get; set; }

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
