using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record TransactionsAttributes : IJsonOnDeserialized
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
    /// Transaction amount in cents
    /// </summary>
    [JsonPropertyName("amount")]
    public required int Amount { get; set; }

    /// <summary>
    /// The base amount in cents excluding additional charges (such as tips, taxes, and other fees).
    /// </summary>
    [JsonPropertyName("subtotal")]
    public int? Subtotal { get; set; }

    /// <summary>
    /// Transaction status
    /// </summary>
    [JsonPropertyName("status")]
    public required TransactionStatus Status { get; set; }

    /// <summary>
    /// Currency of transaction
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    /// <summary>
    /// Description of transaction - usually includes merchant and other key details on transaction
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Description2 of transaction — usually includes other merchant identifying information
    /// </summary>
    [JsonPropertyName("description2")]
    public string? Description2 { get; set; }

    /// <summary>
    /// Merchant Category Code (usually a 4-digit numerical number). <b>Note, this field is REQUIRED for SOME national offers. We HIGHLY RECOMMEND sending this field as it will be required in the near future.</b>
    /// </summary>
    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// Name of processor associated with transaction
    /// </summary>
    [JsonPropertyName("coreProviderId")]
    public string? CoreProviderId { get; set; }

    /// <summary>
    /// Timestamp for <b>REVERSED, RETURNED, DECLINED</b> transaction events; <b>REQUIRED</b> for transactions with <b>REVERSED, RETURNED, DECLINED</b> status. Date string should be in ISO 8601 format i.e.`'YYYY-MM-DDThh:mm:ss.sTZD'` where TZD = time zone designator (Z or +hh:mm or -hh:mm) i.e. `1994-11-05T08:15:30-05:00` OR `1994-11-05T08:15:30Z`
    /// </summary>
    [JsonPropertyName("transactionDate")]
    public DateTime? TransactionDate { get; set; }

    /// <summary>
    /// Timestamp for <b>APPROVED</b> transaction event; <b>REQUIRED</b> for transactions with <b>APPROVED</b> status, and <b>HIGHLY RECOMMENDED</b> to include for transactions with a <b>SETTLED</b> status. Date string should be in ISO 8601 format i.e.`'YYYY-MM-DDThh:mm:ss.sTZD'` where TZD = time zone designator (Z or +hh:mm or -hh:mm) i.e. `1994-11-05T08:15:30-05:00 OR 1994-11-05T08:15:30Z`
    /// </summary>
    [JsonPropertyName("authorizationDate")]
    public DateTime? AuthorizationDate { get; set; }

    /// <summary>
    /// Timestamp for <b>SETTLED</b> transaction event, <b>REQUIRED</b> for transactions with <b>SETTLED</b> status. Date string should be in ISO 8601 format i.e.`'YYYY-MM-DDThh:mm:ss.sTZD'` where TZD = time zone designator (Z or +hh:mm or -hh:mm) i.e. `1994-11-05T08:15:30-05:00` OR `1994-11-05T08:15:30Z`
    /// </summary>
    [JsonPropertyName("settledDate")]
    public DateTime? SettledDate { get; set; }

    /// <summary>
    /// Merchant details
    /// </summary>
    [JsonPropertyName("merchant")]
    public Merchant? Merchant { get; set; }

    /// <summary>
    /// Whether card was present at time of transaction
    /// </summary>
    [JsonPropertyName("cardPresence")]
    public string? CardPresence { get; set; }

    /// <summary>
    /// PAN entry mode
    /// </summary>
    [JsonPropertyName("panEntryMode")]
    public string? PanEntryMode { get; set; }

    /// <summary>
    /// Bank identification number (BIN). Must be a valid BIN of 6 digits. If over 6 digits, please send first 6.
    /// </summary>
    [JsonPropertyName("cardBIN")]
    public required string CardBin { get; set; }

    /// <summary>
    /// Card last four digits.
    /// </summary>
    [JsonPropertyName("cardLastFour")]
    public required string CardLastFour { get; set; }

    /// <summary>
    /// Transaction approval code
    /// </summary>
    [JsonPropertyName("authorizationCode")]
    public string? AuthorizationCode { get; set; }

    /// <summary>
    /// Retrieval Reference Number
    /// </summary>
    [JsonPropertyName("retrievalReferenceNumber")]
    public string? RetrievalReferenceNumber { get; set; }

    /// <summary>
    /// System Trace Audit Number
    /// </summary>
    [JsonPropertyName("systemTraceAuditNumber")]
    public string? SystemTraceAuditNumber { get; set; }

    /// <summary>
    /// Acquirer Reference Number
    /// </summary>
    [JsonPropertyName("acquirerReferenceNumber")]
    public string? AcquirerReferenceNumber { get; set; }

    /// <summary>
    /// The direction in which the funds flow - DEBIT or CREDIT
    /// </summary>
    [JsonPropertyName("direction")]
    public required DirectionType Direction { get; set; }

    /// <summary>
    /// The type of payment involved in the transaction.
    /// </summary>
    [JsonPropertyName("paymentType")]
    public required TransactionPaymentType PaymentType { get; set; }

    /// <summary>
    /// The card network associated with the transaction
    /// </summary>
    [JsonPropertyName("cardNetwork")]
    public CardNetwork? CardNetwork { get; set; }

    /// <summary>
    /// The transaction ID
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

    /// <summary>
    /// The card product ID associated with the transaction
    /// </summary>
    [JsonPropertyName("cardProductId")]
    public string? CardProductId { get; set; }

    /// <summary>
    /// The zip code of the user who made the transaction
    /// </summary>
    [JsonPropertyName("userZipCode")]
    public string? UserZipCode { get; set; }

    /// <summary>
    /// Network specific merchant IDs (MIDs) associated with the transaction
    /// </summary>
    [JsonPropertyName("processorMids")]
    public ProcessorMid? ProcessorMids { get; set; }

    /// <summary>
    /// An account identifier associated to transaction
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

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
