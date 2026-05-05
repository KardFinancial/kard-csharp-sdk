using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record GetFilesMetadataResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// List of file metadata objects with their pre-signed URLs.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<FileMetadataWithUrl> Data { get; set; } = new List<FileMetadataWithUrl>();

    /// <summary>
    /// Navigation links for paginated results.
    /// </summary>
    [JsonPropertyName("links")]
    public required Links Links { get; set; }

    /// <summary>
    /// Metadata about the pagination status.
    /// </summary>
    [JsonPropertyName("meta")]
    public required PaginationMeta Meta { get; set; }

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
