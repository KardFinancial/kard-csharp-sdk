using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

/// <summary>
/// Segment configuration for a specific layout
/// </summary>
[Serializable]
public record ProgressBarSegment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// SVG icon to use for each segment
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    /// <summary>
    /// Position of the segment within the layout
    /// </summary>
    [JsonPropertyName("position")]
    public required ProgressBarSegmentPosition Position { get; set; }

    /// <summary>
    /// Separator style to render between segment nodes
    /// </summary>
    [JsonPropertyName("separator")]
    public ProgressBarSegmentSeparator? Separator { get; set; }

    /// <summary>
    /// Label configuration for each node in the segment
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<ProgressBarSegmentLabel>? Labels { get; set; }

    /// <summary>
    /// Which segment nodes the UI should render as selected based on currentProgress
    /// </summary>
    [JsonPropertyName("selection")]
    public ProgressBarSegmentSelection? Selection { get; set; }

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
