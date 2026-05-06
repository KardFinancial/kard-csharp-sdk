using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record FileMetadataWithUrl : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of the generated file.
    /// </summary>
    [JsonPropertyName("type")]
    public required FileType Type { get; set; }

    /// <summary>
    /// Attributes of the filetype
    /// </summary>
    [JsonPropertyName("attributes")]
    public required FileMetadataAttribute Attributes { get; set; }

    /// <summary>
    /// The File ID in Kard’s system
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

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
