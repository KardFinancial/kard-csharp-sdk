using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

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
