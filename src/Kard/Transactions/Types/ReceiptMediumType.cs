using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(ReceiptMediumType.ReceiptMediumTypeSerializer))]
[Serializable]
public readonly record struct ReceiptMediumType : IStringEnum
{
    public static readonly ReceiptMediumType Electronic = new(Values.Electronic);

    public static readonly ReceiptMediumType Physical = new(Values.Physical);

    public ReceiptMediumType(string value)
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
    public static ReceiptMediumType FromCustom(string value)
    {
        return new ReceiptMediumType(value);
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

    public static bool operator ==(ReceiptMediumType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceiptMediumType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceiptMediumType value) => value.Value;

    public static explicit operator ReceiptMediumType(string value) => new(value);

    internal class ReceiptMediumTypeSerializer : JsonConverter<ReceiptMediumType>
    {
        public override ReceiptMediumType Read(
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
            return new ReceiptMediumType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiptMediumType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceiptMediumType ReadAsPropertyName(
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
            return new ReceiptMediumType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiptMediumType value,
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
        public const string Electronic = "ELECTRONIC";

        public const string Physical = "PHYSICAL";
    }
}
