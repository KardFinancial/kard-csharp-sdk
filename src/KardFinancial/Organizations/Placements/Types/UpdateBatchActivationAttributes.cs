using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Attributes for updating a batch-activation placement. All fields are required.
/// </summary>
[Serializable]
public record UpdateBatchActivationAttributes : IJsonOnDeserialized
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
    /// Slots that make up the activation cohort. Slots present in the prior state but absent from this list are removed.
    /// </summary>
    [JsonPropertyName("slots")]
    public IEnumerable<UpdateBatchActivationSlot> Slots { get; set; } =
        new List<UpdateBatchActivationSlot>();

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
