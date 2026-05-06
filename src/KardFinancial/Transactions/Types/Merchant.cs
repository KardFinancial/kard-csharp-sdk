using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[Serializable]
public record Merchant : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Acquirer Merchant Identification Number (MID) — usually a 15 digit numerical identifier code. <b>Note, this field is REQUIRED for local offers. We HIGHLY RECOMMEND sending this field as it will be required in the near future.</b>
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Merchant name associated with transaction
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Merchant street address associated with transaction.
    /// </summary>
    [JsonPropertyName("addrStreet")]
    public string? AddrStreet { get; set; }

    /// <summary>
    /// Merchant address city associated with transaction.
    /// </summary>
    [JsonPropertyName("addrCity")]
    public string? AddrCity { get; set; }

    /// <summary>
    /// Merchant address state associated with transaction.
    /// </summary>
    [JsonPropertyName("addrState")]
    public States? AddrState { get; set; }

    /// <summary>
    /// Merchant address zip code associated with transaction.
    /// </summary>
    [JsonPropertyName("addrZipcode")]
    public string? AddrZipcode { get; set; }

    /// <summary>
    /// Merchant address country associated with transaction.
    /// </summary>
    [JsonPropertyName("addrCountry")]
    public string? AddrCountry { get; set; }

    /// <summary>
    /// Merchant latitude geocoordinate associated with transaction.
    /// </summary>
    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    /// <summary>
    /// Merchant longitude geocoordinate associated with transaction.
    /// </summary>
    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    /// <summary>
    /// Merchant store ID where transaction originated from
    /// </summary>
    [JsonPropertyName("storeId")]
    public string? StoreId { get; set; }

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
