using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record AuditAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Audit Code - Enum. Please submit the code that is most relevant to your audit request.
    ///             <list type="bullet">
    ///               <item><description>`3005` : Customer is claiming cashback is incorrect - INCORRECT CASHBACK CLAIM</description></item>
    ///               <item><description>`3006` : Transaction is missing the cashback award - MISSING CASHBACK AWARD</description></item>
    ///               <item><description>`8001` : Other - check audit description</description></item>
    ///             </list>
    /// </summary>
    [JsonPropertyName("auditCode")]
    public required int AuditCode { get; set; }

    /// <summary>
    /// Merchant name related to the transaction audit
    /// </summary>
    [JsonPropertyName("merchantName")]
    public required string MerchantName { get; set; }

    /// <summary>
    /// Audit Description. Please provide more details around the audit
    /// </summary>
    [JsonPropertyName("auditDescription")]
    public required string AuditDescription { get; set; }

    /// <summary>
    /// Transaction ID from issuer to audit
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

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
