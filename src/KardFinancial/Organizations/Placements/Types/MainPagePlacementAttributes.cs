using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for a main-page placement
/// </summary>
[Serializable]
public record MainPagePlacementAttributes : IJsonOnDeserialized
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
    /// ID of the organization this placement belongs to
    /// </summary>
    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    /// <summary>
    /// Number of available slots
    /// </summary>
    [JsonPropertyName("availableSlots")]
    public required int AvailableSlots { get; set; }

    /// <summary>
    /// When the placement was created (ISO 8601 UTC)
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the placement was last modified (ISO 8601 UTC)
    /// </summary>
    [JsonPropertyName("lastModified")]
    public required DateTime LastModified { get; set; }

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
