using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record ErrorSource : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A JSON pointer to the value in the request document that caused the error
    /// </summary>
    [JsonPropertyName("pointer")]
    public string? Pointer { get; set; }

    /// <summary>
    /// A string indicating which URI query parameter caused the error
    /// </summary>
    [JsonPropertyName("parameter")]
    public string? Parameter { get; set; }

    /// <summary>
    /// A string indicating the name of a single request header which caused the error
    /// </summary>
    [JsonPropertyName("header")]
    public string? Header { get; set; }

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
