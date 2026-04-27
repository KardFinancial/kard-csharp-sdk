using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(TransactionPaymentType.TransactionPaymentTypeSerializer))]
[Serializable]
public readonly record struct TransactionPaymentType : IStringEnum
{
    public static readonly TransactionPaymentType Card = new(Values.Card);

    public TransactionPaymentType(string value)
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
    public static TransactionPaymentType FromCustom(string value)
    {
        return new TransactionPaymentType(value);
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

    public static bool operator ==(TransactionPaymentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransactionPaymentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransactionPaymentType value) => value.Value;

    public static explicit operator TransactionPaymentType(string value) => new(value);

    internal class TransactionPaymentTypeSerializer : JsonConverter<TransactionPaymentType>
    {
        public override TransactionPaymentType Read(
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
            return new TransactionPaymentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransactionPaymentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransactionPaymentType ReadAsPropertyName(
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
            return new TransactionPaymentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransactionPaymentType value,
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
    }
}
