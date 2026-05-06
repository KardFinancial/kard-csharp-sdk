using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Cadence schedule for push notification placements
/// </summary>
[Serializable]
public record Cadence : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Delivery frequency
    /// </summary>
    [JsonPropertyName("frequency")]
    public required CadenceFrequency Frequency { get; set; }

    /// <summary>
    /// Optional time of day in HH:mm format (24-hour, UTC)
    /// </summary>
    [JsonPropertyName("timeOfDay")]
    public string? TimeOfDay { get; set; }

    /// <summary>
    /// Day of the week to deliver (used when frequency is WEEKLY, defaults to MON)
    /// </summary>
    [JsonPropertyName("dayOfWeek")]
    public DayOfWeek? DayOfWeek { get; set; }

    /// <summary>
    /// Day of the month to deliver, 1-31 (used when frequency is MONTHLY, defaults to 1)
    /// </summary>
    [JsonPropertyName("dayOfMonth")]
    public int? DayOfMonth { get; set; }

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
