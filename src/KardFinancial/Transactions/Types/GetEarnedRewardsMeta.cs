using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record GetEarnedRewardsMeta : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Lifetime rewards earned by the user across matched transactions in cents. By default all matched transactions are included regardless of payment status; pass `filter[paidInFullOnly]=true` to restrict the total to transactions paid in full to the issuer (`paidToIssuer` is `PAID_IN_FULL`).
    /// </summary>
    [JsonPropertyName("lifetimeRewardsInCents")]
    public required int LifetimeRewardsInCents { get; set; }

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
