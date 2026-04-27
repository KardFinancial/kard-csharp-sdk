using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

/// <summary>
/// UI component data for rendering offer details
/// </summary>
[Serializable]
public record OfferComponents : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Short description for the offer
    /// </summary>
    [JsonPropertyName("shortDescription")]
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Long description for the offer
    /// </summary>
    [JsonPropertyName("longDescription")]
    public string? LongDescription { get; set; }

    /// <summary>
    /// Formatted reward string
    /// </summary>
    [JsonPropertyName("baseReward")]
    public string? BaseReward { get; set; }

    /// <summary>
    /// Formatted boosted reward string
    /// </summary>
    [JsonPropertyName("boostedReward")]
    public string? BoostedReward { get; set; }

    /// <summary>
    /// Call-to-action button component
    /// </summary>
    [JsonPropertyName("cta")]
    public CtaComponent? Cta { get; set; }

    /// <summary>
    /// Tags for the offer
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// Detail tags for the offer
    /// </summary>
    [JsonPropertyName("detailTags")]
    public IEnumerable<string>? DetailTags { get; set; }

    /// <summary>
    /// Logo flare configuration for the offer
    /// </summary>
    [JsonPropertyName("logoFlare")]
    public LogoFlare? LogoFlare { get; set; }

    /// <summary>
    /// Progress bar component for tracking offer redemptions
    /// </summary>
    [JsonPropertyName("progressBar")]
    public ProgressBar? ProgressBar { get; set; }

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
