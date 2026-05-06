using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(CommissionType.CommissionTypeSerializer))]
[Serializable]
public readonly record struct CommissionType : IStringEnum
{
    public static readonly CommissionType Flat = new(Values.Flat);

    public static readonly CommissionType Percent = new(Values.Percent);

    public CommissionType(string value)
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
    public static CommissionType FromCustom(string value)
    {
        return new CommissionType(value);
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

    public static bool operator ==(CommissionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommissionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommissionType value) => value.Value;

    public static explicit operator CommissionType(string value) => new(value);

    internal class CommissionTypeSerializer : JsonConverter<CommissionType>
    {
        public override CommissionType Read(
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
            return new CommissionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommissionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommissionType ReadAsPropertyName(
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
            return new CommissionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommissionType value,
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
        public const string Flat = "FLAT";

        public const string Percent = "PERCENT";
    }
}
