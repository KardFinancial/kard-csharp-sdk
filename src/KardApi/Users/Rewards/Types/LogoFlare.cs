using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

/// <summary>
/// Logo flare configuration for offer display
/// </summary>
[Serializable]
public record LogoFlare : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Border color style for the logo flare
    /// </summary>
    [JsonPropertyName("borderColor")]
    public required LogoFlareBorderColor BorderColor { get; set; }

    /// <summary>
    /// Optional badge to display on the logo
    /// </summary>
    [JsonPropertyName("badge")]
    public LogoFlareBadge? Badge { get; set; }

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
