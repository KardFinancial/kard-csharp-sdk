using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

/// <summary>
/// Limited set of organization attributes exposed to external consumers
/// </summary>
[Serializable]
public record ExternalOrganizationAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the organization (uppercase, no spaces)
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Rewards programs the organization is enrolled in
    /// </summary>
    [JsonPropertyName("enrolledRewards")]
    public IEnumerable<EnrolledReward> EnrolledRewards { get; set; } = new List<EnrolledReward>();

    /// <summary>
    /// Card networks supported by the organization
    /// </summary>
    [JsonPropertyName("cardNetworks")]
    public IEnumerable<CardNetwork> CardNetworks { get; set; } = new List<CardNetwork>();

    /// <summary>
    /// Bank Identification Numbers for the organization
    /// </summary>
    [JsonPropertyName("bins")]
    public IEnumerable<string> Bins { get; set; } = new List<string>();

    /// <summary>
    /// Affiliate commission split percentage
    /// </summary>
    [JsonPropertyName("affiliateCommissionSplit")]
    public required double AffiliateCommissionSplit { get; set; }

    /// <summary>
    /// Cardlinked commission split percentage
    /// </summary>
    [JsonPropertyName("cardlinkedCommissionSplit")]
    public required double CardlinkedCommissionSplit { get; set; }

    /// <summary>
    /// Cardlinked user commission split percentage
    /// </summary>
    [JsonPropertyName("cardlinkedUserCommissionSplit")]
    public required double CardlinkedUserCommissionSplit { get; set; }

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
