using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[JsonConverter(typeof(WeekOfMonth.WeekOfMonthSerializer))]
[Serializable]
public readonly record struct WeekOfMonth : IStringEnum
{
    public static readonly WeekOfMonth First = new(Values.First);

    public static readonly WeekOfMonth Last = new(Values.Last);

    public WeekOfMonth(string value)
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
    public static WeekOfMonth FromCustom(string value)
    {
        return new WeekOfMonth(value);
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

    public static bool operator ==(WeekOfMonth value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WeekOfMonth value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WeekOfMonth value) => value.Value;

    public static explicit operator WeekOfMonth(string value) => new(value);

    internal class WeekOfMonthSerializer : JsonConverter<WeekOfMonth>
    {
        public override WeekOfMonth Read(
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
            return new WeekOfMonth(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WeekOfMonth value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WeekOfMonth ReadAsPropertyName(
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
            return new WeekOfMonth(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WeekOfMonth value,
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
        public const string First = "FIRST";

        public const string Last = "LAST";
    }
}
