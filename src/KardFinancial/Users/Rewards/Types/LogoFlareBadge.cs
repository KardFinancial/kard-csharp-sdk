using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

/// <summary>
/// Badge configuration for logo flare
/// </summary>
[Serializable]
public record LogoFlareBadge : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Icon identifier for the badge
    /// </summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; set; }

    /// <summary>
    /// Position of the badge on the logo
    /// </summary>
    [JsonPropertyName("position")]
    public required LogoFlareBadgePosition Position { get; set; }

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
