using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record CoreTransactionRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the transaction event. This <b>must</b> be unique for each distinct event sent to the API.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("attributes")]
    public required CoreTransactionAttributes Attributes { get; set; }

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
