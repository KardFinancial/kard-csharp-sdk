using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

/// <summary>
/// Segment configuration for the progress bar in different layouts
/// </summary>
[Serializable]
public record ProgressBarSegments : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Segment configuration for the details view
    /// </summary>
    [JsonPropertyName("details")]
    public ProgressBarSegment? Details { get; set; }

    /// <summary>
    /// Segment configuration for the default view
    /// </summary>
    [JsonPropertyName("default")]
    public required ProgressBarSegment Default { get; set; }

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
