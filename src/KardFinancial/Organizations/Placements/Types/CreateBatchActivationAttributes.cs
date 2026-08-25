using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for creating a batch-activation placement
/// </summary>
[Serializable]
public record CreateBatchActivationAttributes : IJsonOnDeserialized
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
    /// ISO-8601 duration controlling how often the activation cohort refreshes
    /// </summary>
    [JsonPropertyName("refreshInterval")]
    public required string RefreshInterval { get; set; }

    /// <summary>
    /// Slots that make up the activation cohort
    /// </summary>
    [JsonPropertyName("slots")]
    public IEnumerable<CreateBatchActivationSlot> Slots { get; set; } =
        new List<CreateBatchActivationSlot>();

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
