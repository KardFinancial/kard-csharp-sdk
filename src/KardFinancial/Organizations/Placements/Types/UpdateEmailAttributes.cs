using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for updating an email placement. All fields are required.
/// </summary>
[Serializable]
public record UpdateEmailAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the placement
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Number of available slots (minimum 1)
    /// </summary>
    [JsonPropertyName("availableSlots")]
    public required int AvailableSlots { get; set; }

    /// <summary>
    /// Delivery cadence for the email
    /// </summary>
    [JsonPropertyName("cadence")]
    public required Cadence Cadence { get; set; }

    /// <summary>
    /// ID of the content strategy to link this placement to. Omit to clear any existing link (PUT requires the full attribute set, so a missing value unlinks the placement).
    /// </summary>
    [JsonPropertyName("contentStrategyId")]
    public string? ContentStrategyId { get; set; }

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
