using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record ErrorObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Status code returned from the request
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// Name of error
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// Description of the specific occurance of the error
    /// </summary>
    [JsonPropertyName("detail")]
    public required string Detail { get; set; }

    /// <summary>
    /// An object containing a reference to the primary source of the error
    /// </summary>
    [JsonPropertyName("source")]
    public ErrorSource? Source { get; set; }

    /// <summary>
    /// The id of the resource which caused the error. Always returned for multi-status errors.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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
