using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

/// <summary>
/// Labels to render around the progress bar in different layouts
/// </summary>
[Serializable]
public record ProgressBarLabels : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Label configuration for the details view
    /// </summary>
    [JsonPropertyName("details")]
    public ProgressBarLabelPair? Details { get; set; }

    /// <summary>
    /// Label configuration for the default view
    /// </summary>
    [JsonPropertyName("default")]
    public required ProgressBarLabelPair Default { get; set; }

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
