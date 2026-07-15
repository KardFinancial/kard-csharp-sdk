using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record EarnedRewardNotificationAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The category of the offer, e.g. "Food & Dining"
    /// </summary>
    [JsonPropertyName("categoryName")]
    public string? CategoryName { get; set; }

    /// <summary>
    /// Type of commission on offer (% or a flat $)
    /// </summary>
    [JsonPropertyName("userReward")]
    public UserReward? UserReward { get; set; }

    /// <summary>
    /// Tracked asset images for the merchant. The asset
    /// URL is signed for attribution tracking and should be loaded as-is by the
    /// client.
    /// </summary>
    [JsonPropertyName("assets")]
    public IEnumerable<MerchantAsset>? Assets { get; set; }

    /// <summary>
    /// The purchase channels the offer applies to
    /// </summary>
    [JsonPropertyName("purchaseChannel")]
    public IEnumerable<PurchaseChannel>? PurchaseChannel { get; set; }

    /// <summary>
    /// The display message associated to the notification
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    /// <summary>
    /// The name of the merchant
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The attribution URL to track user's interactions with the notification
    /// </summary>
    [JsonPropertyName("attributionUrl")]
    public required string AttributionUrl { get; set; }

    /// <summary>
    /// Post experience survey URL, if available. This will be present for rewards associated with local offers.
    /// </summary>
    [JsonPropertyName("surveyUrl")]
    public string? SurveyUrl { get; set; }

    /// <summary>
    /// The ID of the card product
    /// </summary>
    [JsonPropertyName("cardProductId")]
    public string? CardProductId { get; set; }

    /// <summary>
    /// The timestamp of the originating transaction in ISO format
    /// </summary>
    [JsonPropertyName("transactionTimestamp")]
    public DateTime? TransactionTimestamp { get; set; }

    /// <summary>
    /// The transaction ID
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }

    /// <summary>
    /// The amount of the originating transaction in cents
    /// </summary>
    [JsonPropertyName("transactionAmountInCents")]
    public required int TransactionAmountInCents { get; set; }

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
