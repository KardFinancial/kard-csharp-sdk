using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record ValidTransactionAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("commissionEarned")]
    public required ValidTransactionCommissionEarned CommissionEarned { get; set; }

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
