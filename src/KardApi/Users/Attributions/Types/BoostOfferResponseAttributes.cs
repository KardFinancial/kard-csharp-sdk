using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi;
using KardApi.Core;

namespace KardApi.Users;

[Serializable]
public record BoostOfferResponseAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entityId")]
    public required string EntityId { get; set; }

    [JsonPropertyName("eventCode")]
    public required string EventCode { get; set; }

    [JsonPropertyName("medium")]
    public required string Medium { get; set; }

    [JsonPropertyName("eventDate")]
    public required DateTime EventDate { get; set; }

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
