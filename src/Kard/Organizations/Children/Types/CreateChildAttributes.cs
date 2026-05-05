using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Organizations;

/// <summary>
/// Attributes for creating a child organization. Only name is required. All other fields are optional and default to the parent organization's values.
/// </summary>
[Serializable]
public record CreateChildAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the child organization (must be uppercase, no spaces)
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

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
