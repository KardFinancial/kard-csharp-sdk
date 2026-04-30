using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record UpdateUserRequestAttributes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Rewards programs to enroll the user in. If an empty array is supplied, the user will not be enrolled in any programs.
    /// </summary>
    [JsonPropertyName("enrolledRewards")]
    public IEnumerable<EnrolledRewardsType> EnrolledRewards { get; set; } =
        new List<EnrolledRewardsType>();

    /// <summary>
    /// Zipcode of user
    /// </summary>
    [JsonPropertyName("zipCode")]
    public string? ZipCode { get; set; }

    /// <summary>
    /// Email address of user
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Hashed email address of user (using SHA-256)
    /// </summary>
    [JsonPropertyName("hashedEmail")]
    public string? HashedEmail { get; set; }

    /// <summary>
    /// Phone number of user in E.164 format
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Birth year of user
    /// </summary>
    [JsonPropertyName("birthYear")]
    public string? BirthYear { get; set; }

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
