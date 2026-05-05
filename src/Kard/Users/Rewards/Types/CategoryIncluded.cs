using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Users;

[Serializable]
public record CategoryIncluded : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("attributes")]
    public required CategoryFields Attributes { get; set; }

    /// <summary>
    /// id of the category
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = "category";

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
