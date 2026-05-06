using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record MatchedTransactionsAttributes : IJsonOnDeserialized
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
    /// Description of transaction - usually includes merchant and other key details on transaction
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Timestamp for transaction event. Date string should be in ISO 8601 format i.e.`'YYYY-MM-DDThh:mm:ss.sTZD'` where TZD = time zone designator (Z or +hh:mm or -hh:mm) i.e. `1994-11-05T08:15:30-05:00 OR 1994-11-05T08:15:30Z`
    /// </summary>
    [JsonPropertyName("authorizationDate")]
    public required DateTime AuthorizationDate { get; set; }

    /// <summary>
    /// The ID of the Kard offer to which the transaction was matched. If this field is omitted, the transaction will be considered unmatched to any Kard offer. This field **must** be omitted when the `paymentType` is `UNKNOWN` and neither an orderId nor a `cardLastFour` is supplied.
    /// </summary>
    [JsonPropertyName("matchedOfferId")]
    public string? MatchedOfferId { get; set; }

    /// <summary>
    /// The unique Kard location ID where the transaction took place. This field **must** be omitted  when `paymentType` is `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("matchedLocationId")]
    public string? MatchedLocationId { get; set; }

    /// <summary>
    /// Merchant details
    /// </summary>
    [JsonPropertyName("merchant")]
    public Merchant? Merchant { get; set; }

    /// <summary>
    /// The type of payment involved in the transaction.
    /// </summary>
    [JsonPropertyName("paymentType")]
    public required PaymentType PaymentType { get; set; }

    /// <summary>
    /// Bank identification number (BIN). Must be a valid BIN of 6 digits. If over 6 digits, please send first 6. This field **must** be omitted when `paymentType` is `CASH` or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("cardBIN")]
    public string? CardBin { get; set; }

    /// <summary>
    /// Card last four digits. This field is **required** when `paymentType` is `CARD` and `matchedOfferId` is provided. It **must** be omitted when `paymentType` is `CASH`.
    /// </summary>
    [JsonPropertyName("cardLastFour")]
    public string? CardLastFour { get; set; }

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
    /// The card network associated with the transaction. This field **must** be omitted when `paymentType` is `CASH` or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("cardNetwork")]
    public CardNetwork? CardNetwork { get; set; }

    /// <summary>
    /// The transaction ID
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

    /// <summary>
    /// The card product ID associated with the transaction. This field **must** be omitted when `paymentType` is `CASH` or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("cardProductId")]
    public string? CardProductId { get; set; }

    /// <summary>
    /// The unique identifier for an online order linked to this transaction.
    /// </summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Indicates the format of the receipt from which the transaction is derived.
    /// </summary>
    [JsonPropertyName("receiptMedium")]
    public ReceiptMediumType? ReceiptMedium { get; set; }

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
