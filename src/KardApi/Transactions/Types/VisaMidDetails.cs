using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[Serializable]
public record VisaMidDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Visa Merchant ID (VMID) associated with the transaction
    /// </summary>
    [JsonPropertyName("vmid")]
    public required string Vmid { get; set; }

    /// <summary>
    /// Visa Store ID (VSID) associated with the transaction
    /// </summary>
    [JsonPropertyName("vsid")]
    public required string Vsid { get; set; }

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
