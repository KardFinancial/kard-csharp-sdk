using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record FileMetadataAttribute : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the file.
    /// </summary>
    [JsonPropertyName("fileName")]
    public required string FileName { get; set; }

    /// <summary>
    /// ISO 8601 timestamp (ISO8601) when the file was originally sent/created.
    /// </summary>
    [JsonPropertyName("sentAt")]
    public required string SentAt { get; set; }

    /// <summary>
    /// ISO 8601 timestamp (ISO8601) when the file was last modified.
    /// </summary>
    [JsonPropertyName("lastModified")]
    public required string LastModified { get; set; }

    /// <summary>
    /// Temporary URL that provides direct access to download the file for 30 minutes.
    /// </summary>
    [JsonPropertyName("downloadUrl")]
    public required string DownloadUrl { get; set; }

    /// <summary>
    /// Start of the reporting period, inclusive (RFC 3339, UTC). Present only when a period was informed at upload.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public string? PeriodStart { get; set; }

    /// <summary>
    /// End of the reporting period, inclusive (RFC 3339, UTC). Present only when a period was informed at upload.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public string? PeriodEnd { get; set; }

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
