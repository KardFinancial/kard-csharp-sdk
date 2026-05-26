using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for a batch-activation placement
/// </summary>
[Serializable]
public record BatchActivationPlacementAttributes : IJsonOnDeserialized
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
    /// ISO-8601 duration that controls how often the activation cohort refreshes (e.g. "P7D" for weekly).
    /// </summary>
    [JsonPropertyName("refreshInterval")]
    public required string RefreshInterval { get; set; }

    /// <summary>
    /// Slots that make up the activation cohort
    /// </summary>
    [JsonPropertyName("slots")]
    public IEnumerable<BatchActivationSlot> Slots { get; set; } = new List<BatchActivationSlot>();

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
