using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(CardNetwork.CardNetworkSerializer))]
[Serializable]
public readonly record struct CardNetwork : IStringEnum
{
    public static readonly CardNetwork Visa = new(Values.Visa);

    public static readonly CardNetwork Mastercard = new(Values.Mastercard);

    public static readonly CardNetwork Americanexpress = new(Values.Americanexpress);

    public static readonly CardNetwork Discover = new(Values.Discover);

    public CardNetwork(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static CardNetwork FromCustom(string value)
    {
        return new CardNetwork(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(CardNetwork value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CardNetwork value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CardNetwork value) => value.Value;

    public static explicit operator CardNetwork(string value) => new(value);

    internal class CardNetworkSerializer : JsonConverter<CardNetwork>
    {
        public override CardNetwork Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CardNetwork(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CardNetwork value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CardNetwork ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CardNetwork(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CardNetwork value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Visa = "VISA";

        public const string Mastercard = "MASTERCARD";

        public const string Americanexpress = "AMERICANEXPRESS";

        public const string Discover = "DISCOVER";
    }
}
