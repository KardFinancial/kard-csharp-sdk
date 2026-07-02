using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

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

    /// <summary>
    /// Per-segment fill state: one entry per segment node, index-aligned with the nodes (length equals the progress bar total). Reached nodes report 1 of 1 and not-yet-reached nodes 0 of 1; for a punch-card offer the in-progress node reports qualifying-purchase progress toward the next reward (Q mod N of N).
    /// </summary>
    [JsonPropertyName("progress")]
    public IEnumerable<ProgressBarSegmentProgress> Progress { get; set; } =
        new List<ProgressBarSegmentProgress>();

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
