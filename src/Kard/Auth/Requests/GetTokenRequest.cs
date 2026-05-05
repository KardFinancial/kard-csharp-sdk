using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[Serializable]
public record GetTokenRequest
{
    /// <summary>
    /// (Beta) Target issuer ID for partners managing multiple issuers on the Kard platform. When set, the auth token will be scoped to this specific issuer. Required if you manage more than one issuer; omit if you operate a single issuer integration.
    /// </summary>
    [JsonIgnore]
    public string? XKardTargetIssuer { get; set; }

    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [JsonPropertyName("client_secret")]
    public required string ClientSecret { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
