using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record GetEarnedRewardsRequest
{
    /// <summary>
    /// Cursor for next page (base64-encoded timestamp + transaction ID)
    /// </summary>
    [JsonIgnore]
    public string? PageAfter { get; set; }

    /// <summary>
    /// Cursor for previous page (base64-encoded timestamp + transaction ID)
    /// </summary>
    [JsonIgnore]
    public string? PageBefore { get; set; }

    /// <summary>
    /// Number of results per page
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Filter by transaction status. Supported values are `APPROVED` and `SETTLED`. Defaults to `SETTLED` when omitted. When `APPROVED` is specified, only approved transactions that do not yet have a corresponding settled transaction are returned.
    /// </summary>
    [JsonIgnore]
    public RewardedTransactionStatus? FilterStatus { get; set; }

    /// <summary>
    /// When `true`, only return transactions that have been paid in full to the issuer (`paidToIssuer` is `PAID_IN_FULL`). By default (`false`), any matched transaction is returned regardless of payment status. This also controls whether unpaid transactions contribute to `lifetimeRewardsInCents`. Has no effect on `APPROVED` transactions, which are always returned when requested.
    /// </summary>
    [JsonIgnore]
    public bool? FilterPaidInFullOnly { get; set; }

    /// <summary>
    /// Comma-separated list of related resources to include in the response. Supported values are `merchant` and `offer`.
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
