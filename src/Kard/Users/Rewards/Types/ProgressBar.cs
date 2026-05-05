using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Users;

/// <summary>
/// Progress bar component for tracking offer redemption progress
/// </summary>
[Serializable]
public record ProgressBar : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Total number of redemptions allowed
    /// </summary>
    [JsonPropertyName("total")]
    public required int Total { get; set; }

    /// <summary>
    /// Number of redemptions the user has completed
    /// </summary>
    [JsonPropertyName("currentProgress")]
    public required int CurrentProgress { get; set; }

    /// <summary>
    /// Formatted label for the progress bar
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Whether the progress bar should be displayed as segmented
    /// </summary>
    [JsonPropertyName("segmented")]
    public required bool Segmented { get; set; }

    /// <summary>
    /// Segment configuration for the progress bar in different layouts
    /// </summary>
    [JsonPropertyName("segments")]
    public ProgressBarSegments? Segments { get; set; }

    /// <summary>
    /// Labels to render around the progress bar in different layouts
    /// </summary>
    [JsonPropertyName("labels")]
    public required ProgressBarLabels Labels { get; set; }

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
