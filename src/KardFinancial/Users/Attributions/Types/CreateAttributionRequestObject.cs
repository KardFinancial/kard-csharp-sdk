using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Users;

[Serializable]
public record CreateAttributionRequestObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Discriminated union representing the request body for submitting attribution events.
    /// Use `type` to distinguish between the two:
    /// - `offerAttribution`: Events related to viewing or interacting with an offer.
    /// - `notificationAttribution`: Events related to viewing or interacting with a notification.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<CreateAttributionRequestUnion> Data { get; set; } =
        new List<CreateAttributionRequestUnion>();

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
