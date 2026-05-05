using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Users;

/// <summary>
/// Left and right label configuration for a specific layout
/// </summary>
[Serializable]
public record ProgressBarLabelPair : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Text content for the left label
    /// </summary>
    [JsonPropertyName("left")]
    public string? Left { get; set; }

    /// <summary>
    /// Text content for the right label
    /// </summary>
    [JsonPropertyName("right")]
    public string? Right { get; set; }

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
