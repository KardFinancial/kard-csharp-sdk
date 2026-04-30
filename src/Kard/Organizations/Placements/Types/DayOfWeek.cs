using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Organizations;

[JsonConverter(typeof(DayOfWeek.DayOfWeekSerializer))]
[Serializable]
public readonly record struct DayOfWeek : IStringEnum
{
    public static readonly DayOfWeek Mon = new(Values.Mon);

    public static readonly DayOfWeek Tue = new(Values.Tue);

    public static readonly DayOfWeek Wed = new(Values.Wed);

    public static readonly DayOfWeek Thu = new(Values.Thu);

    public static readonly DayOfWeek Fri = new(Values.Fri);

    public static readonly DayOfWeek Sat = new(Values.Sat);

    public static readonly DayOfWeek Sun = new(Values.Sun);

    public DayOfWeek(string value)
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
    public static DayOfWeek FromCustom(string value)
    {
        return new DayOfWeek(value);
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

    public static bool operator ==(DayOfWeek value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(DayOfWeek value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(DayOfWeek value) => value.Value;

    public static explicit operator DayOfWeek(string value) => new(value);

    internal class DayOfWeekSerializer : JsonConverter<DayOfWeek>
    {
        public override DayOfWeek Read(
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
            return new DayOfWeek(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DayOfWeek value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DayOfWeek ReadAsPropertyName(
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
            return new DayOfWeek(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DayOfWeek value,
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
        public const string Mon = "MON";

        public const string Tue = "TUE";

        public const string Wed = "WED";

        public const string Thu = "THU";

        public const string Fri = "FRI";

        public const string Sat = "SAT";

        public const string Sun = "SUN";
    }
}
