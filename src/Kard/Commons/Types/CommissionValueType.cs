using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(CommissionValueType.CommissionValueTypeSerializer))]
[Serializable]
public readonly record struct CommissionValueType : IStringEnum
{
    public static readonly CommissionValueType Cents = new(Values.Cents);

    public CommissionValueType(string value)
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
    public static CommissionValueType FromCustom(string value)
    {
        return new CommissionValueType(value);
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

    public static bool operator ==(CommissionValueType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommissionValueType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommissionValueType value) => value.Value;

    public static explicit operator CommissionValueType(string value) => new(value);

    internal class CommissionValueTypeSerializer : JsonConverter<CommissionValueType>
    {
        public override CommissionValueType Read(
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
            return new CommissionValueType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommissionValueType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommissionValueType ReadAsPropertyName(
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
            return new CommissionValueType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommissionValueType value,
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
        public const string Cents = "cents";
    }
}
