using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Users;

[Serializable]
public record LocationRelationships : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("offers")]
    public required RelationshipMultiple Offers { get; set; }

    [JsonPropertyName("category")]
    public required RelationshipMultiple Category { get; set; }

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
