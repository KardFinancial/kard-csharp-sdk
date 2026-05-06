using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

[Serializable]
public record StandardOfferFields : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Terms and conditions on offer
    /// </summary>
    [JsonPropertyName("terms")]
    public required string Terms { get; set; }

    /// <summary>
    /// Maximum times cardholder can redeem offer, if applicable
    /// </summary>
    [JsonPropertyName("maxRedemptions")]
    public int? MaxRedemptions { get; set; }

    /// <summary>
    /// Name of offer
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("purchaseChannel")]
    public IEnumerable<PurchaseChannel> PurchaseChannel { get; set; } = new List<PurchaseChannel>();

    [JsonPropertyName("userReward")]
    public required Commission UserReward { get; set; }

    /// <summary>
    /// Assets associated with offer
    /// </summary>
    [JsonPropertyName("assets")]
    public IEnumerable<Asset> Assets { get; set; } = new List<Asset>();

    /// <summary>
    /// Beginning date of offer (UTC)
    /// </summary>
    [JsonPropertyName("startDate")]
    public required DateTime StartDate { get; set; }

    /// <summary>
    /// Expiration date of offer if applicable (UTC)
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public required DateTime ExpirationDate { get; set; }

    /// <summary>
    /// True returns only targeted offers, false returns only non-targeted offers
    /// </summary>
    [JsonPropertyName("isTargeted")]
    public required bool IsTargeted { get; set; }

    /// <summary>
    /// Minimum Transaction Amount required to redeem offer, if available on offer
    /// </summary>
    [JsonPropertyName("minTransactionAmount")]
    public Amount? MinTransactionAmount { get; set; }

    /// <summary>
    /// Maximum Transaction Amount allowed to redeem offer, if available on offer
    /// </summary>
    [JsonPropertyName("maxTransactionAmount")]
    public Amount? MaxTransactionAmount { get; set; }

    /// <summary>
    /// Minimum Reward Amount, if available on offer
    /// </summary>
    [JsonPropertyName("minRewardAmount")]
    public Amount? MinRewardAmount { get; set; }

    /// <summary>
    /// Maximum Reward Amount, if available on offer
    /// </summary>
    [JsonPropertyName("maxRewardAmount")]
    public Amount? MaxRewardAmount { get; set; }

    /// <summary>
    /// URL to the website of the offer provider
    /// </summary>
    [JsonPropertyName("websiteUrl")]
    public string? WebsiteUrl { get; set; }

    /// <summary>
    /// Description of the offer
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// UI component data for the offer, returned when supportedComponents query parameter is provided
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
