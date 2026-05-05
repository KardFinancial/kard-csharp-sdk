using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Organizations;

/// <summary>
/// Attributes for a push-notification placement
/// </summary>
[Serializable]
public record PushNotificationPlacementAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the placement
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// ID of the organization this placement belongs to
    /// </summary>
    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    /// <summary>
    /// Delivery cadence for the notification
    /// </summary>
    [JsonPropertyName("cadence")]
    public required Cadence Cadence { get; set; }

    /// <summary>
    /// When the placement was created (ISO 8601 UTC)
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the placement was last modified (ISO 8601 UTC)
    /// </summary>
    [JsonPropertyName("lastModified")]
    public required DateTime LastModified { get; set; }

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
