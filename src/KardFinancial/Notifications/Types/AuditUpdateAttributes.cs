using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record AuditUpdateAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The status of the audit
    /// </summary>
    [JsonPropertyName("status")]
    public required AuditStatus Status { get; set; }

    /// <summary>
    /// Audit Code - Enum. Code to define audit.
    ///   <list type="bullet">
    ///     <item><description>`3005` : Customer is claiming cashback is incorrect - INCORRECT CASHBACK CLAIM</description></item>
    ///     <item><description>`3006` : Transaction is missing the cashback award - MISSING CASHBACK AWARD</description></item>
    ///     <item><description>`8001` : Other - check audit description</description></item>
    ///   </list>
    /// </summary>
    [JsonPropertyName("auditCode")]
    public required int AuditCode { get; set; }

    /// <summary>
    /// The merchant name related to the transaction audit
    /// </summary>
    [JsonPropertyName("merchantName")]
    public required string MerchantName { get; set; }

    /// <summary>
    /// The description of the audit
    /// </summary>
    [JsonPropertyName("auditDescription")]
    public required string AuditDescription { get; set; }

    /// <summary>
    /// The transaction ID associated with audit
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

    /// <summary>
    /// Resolution Code - Enum. field is available when audit is status CLOSED.
    /// <list type="bullet">
    ///   <item><description>`5001` : Transaction will be deleted</description></item>
    ///   <item><description>`5002` : Settlement amount will be adjusted</description></item>
    ///   <item><description>`5003` : Return amount will be adjusted</description></item>
    ///   <item><description>`5004` : Reward dispute resolved</description></item>
    ///   <item><description>`5005` : Transaction will be marked for writeoff</description></item>
    ///   <item><description>`5006` : Transaction will be marked as rejected</description></item>
    ///   <item><description>`5007` : Transaction will be resent through webhook</description></item>
    ///   <item><description>`5008` : Transaction will be resent through daily file</description></item>
    ///   <item><description>`5009` : No change needed</description></item>
    ///   <item><description>`9001` : Ineligible item in purchase</description></item>
    ///   <item><description>`9002` : Return was made</description></item>
    ///   <item><description>`9003` : User ineligible for offer (usually because of participation through another program)</description></item>
    ///   <item><description>`9004` : Redemption limit hit (if offer has a set number of redemptions and it isn't handled programmatically)</description></item>
    ///   <item><description>`9005` : Transaction not captured</description></item>
    /// </list>
    /// </summary>
    [JsonPropertyName("resolutionCode")]
    public int? ResolutionCode { get; set; }

    /// <summary>
    /// The resolution description; field is available when audit is status CLOSED
    /// </summary>
    [JsonPropertyName("resolutionDescription")]
    public string? ResolutionDescription { get; set; }

    /// <summary>
    /// The resolution timestamp of when the audit was marked as status CLOSED in ISO format; available when audit is closed.
    /// </summary>
    [JsonPropertyName("resolutionTimeStamp")]
    public DateTime? ResolutionTimeStamp { get; set; }

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
