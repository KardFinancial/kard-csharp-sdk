using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard;
using Kard.Core;

namespace Kard.Organizations;

/// <summary>
/// Paginated list of child organizations
/// </summary>
[Serializable]
public record ChildOrganizationListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of child organization resources
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<ChildOrganizationResponse> Data { get; set; } =
        new List<ChildOrganizationResponse>();

    [JsonPropertyName("links")]
    public Links? Links { get; set; }

    /// <summary>
    /// Pagination metadata
    /// </summary>
    [JsonPropertyName("meta")]
    public OrganizationPaginationMetadata? Meta { get; set; }

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
