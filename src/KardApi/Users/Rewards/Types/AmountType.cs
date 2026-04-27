using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(AmountType.AmountTypeSerializer))]
[Serializable]
public readonly record struct AmountType : IStringEnum
{
    public static readonly AmountType Cents = new(Values.Cents);

    public AmountType(string value)
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
    public static AmountType FromCustom(string value)
    {
        return new AmountType(value);
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

    public static bool operator ==(AmountType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(AmountType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AmountType value) => value.Value;

    public static explicit operator AmountType(string value) => new(value);

    internal class AmountTypeSerializer : JsonConverter<AmountType>
    {
        public override AmountType Read(
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
            return new AmountType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AmountType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AmountType ReadAsPropertyName(
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
            return new AmountType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AmountType value,
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
        public const string Cents = "CENTS";
    }
}
