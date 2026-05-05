using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record CreateFileUploadAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the file to upload, including extension (e.g. "transaction_12345.jsonl")
    /// </summary>
    [JsonPropertyName("filename")]
    public required string Filename { get; set; }

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
