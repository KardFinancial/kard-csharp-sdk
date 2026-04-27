using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Organizations;

/// <summary>
/// Attributes for updating a child organization. All fields are optional; only provided fields are changed.
/// </summary>
[Serializable]
public record UpdateChildAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// New name for the child organization (must be uppercase, no spaces)
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// External identifier for the child organization
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Bank Identification Numbers for the child organization
    /// </summary>
    [JsonPropertyName("bins")]
    public IEnumerable<string>? Bins { get; set; }

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
