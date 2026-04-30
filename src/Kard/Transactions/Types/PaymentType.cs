using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(PaymentType.PaymentTypeSerializer))]
[Serializable]
public readonly record struct PaymentType : IStringEnum
{
    public static readonly PaymentType Card = new(Values.Card);

    public static readonly PaymentType Cash = new(Values.Cash);

    public static readonly PaymentType Unknown = new(Values.Unknown);

    public PaymentType(string value)
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
    public static PaymentType FromCustom(string value)
    {
        return new PaymentType(value);
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

    public static bool operator ==(PaymentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PaymentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PaymentType value) => value.Value;

    public static explicit operator PaymentType(string value) => new(value);

    internal class PaymentTypeSerializer : JsonConverter<PaymentType>
    {
        public override PaymentType Read(
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
            return new PaymentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PaymentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PaymentType ReadAsPropertyName(
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
            return new PaymentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PaymentType value,
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
        public const string Card = "CARD";

        public const string Cash = "CASH";

        public const string Unknown = "UNKNOWN";
    }
}
