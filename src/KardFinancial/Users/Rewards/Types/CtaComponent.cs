using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

/// <summary>
/// Call-to-action button component for offers
/// </summary>
[Serializable]
public record CtaComponent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Text to display on the button
    /// </summary>
    [JsonPropertyName("buttonText")]
    public required string ButtonText { get; set; }

    /// <summary>
    /// Style of the button
    /// </summary>
    [JsonPropertyName("buttonStyle")]
    public required ButtonStyle ButtonStyle { get; set; }

    /// <summary>
    /// Action to perform when the button is clicked
    /// </summary>
    [JsonPropertyName("action")]
    public CtaAction? Action { get; set; }

    /// <summary>
    /// Icon identifier to display on the button
    /// </summary>
    [JsonPropertyName("startIcon")]
    public string? StartIcon { get; set; }

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
