using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Users;

[JsonConverter(typeof(LogoFlareBadgePosition.LogoFlareBadgePositionSerializer))]
[Serializable]
public readonly record struct LogoFlareBadgePosition : IStringEnum
{
    public static readonly LogoFlareBadgePosition TopRight = new(Values.TopRight);

    public static readonly LogoFlareBadgePosition TopLeft = new(Values.TopLeft);

    public static readonly LogoFlareBadgePosition BottomRight = new(Values.BottomRight);

    public static readonly LogoFlareBadgePosition BottomLeft = new(Values.BottomLeft);

    public LogoFlareBadgePosition(string value)
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
    public static LogoFlareBadgePosition FromCustom(string value)
    {
        return new LogoFlareBadgePosition(value);
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

    public static bool operator ==(LogoFlareBadgePosition value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogoFlareBadgePosition value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogoFlareBadgePosition value) => value.Value;

    public static explicit operator LogoFlareBadgePosition(string value) => new(value);

    internal class LogoFlareBadgePositionSerializer : JsonConverter<LogoFlareBadgePosition>
    {
        public override LogoFlareBadgePosition Read(
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
            return new LogoFlareBadgePosition(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogoFlareBadgePosition value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogoFlareBadgePosition ReadAsPropertyName(
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
            return new LogoFlareBadgePosition(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogoFlareBadgePosition value,
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
        public const string TopRight = "TOP_RIGHT";

        public const string TopLeft = "TOP_LEFT";

        public const string BottomRight = "BOTTOM_RIGHT";

        public const string BottomLeft = "BOTTOM_LEFT";
    }
}
