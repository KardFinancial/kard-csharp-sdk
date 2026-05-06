using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(DirectionType.DirectionTypeSerializer))]
[Serializable]
public readonly record struct DirectionType : IStringEnum
{
    public static readonly DirectionType Debit = new(Values.Debit);

    public static readonly DirectionType Credit = new(Values.Credit);

    public DirectionType(string value)
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
    public static DirectionType FromCustom(string value)
    {
        return new DirectionType(value);
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

    public static bool operator ==(DirectionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DirectionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DirectionType value) => value.Value;

    public static explicit operator DirectionType(string value) => new(value);

    internal class DirectionTypeSerializer : JsonConverter<DirectionType>
    {
        public override DirectionType Read(
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
            return new DirectionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DirectionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DirectionType ReadAsPropertyName(
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
            return new DirectionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DirectionType value,
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
        public const string Debit = "DEBIT";

        public const string Credit = "CREDIT";
    }
}
