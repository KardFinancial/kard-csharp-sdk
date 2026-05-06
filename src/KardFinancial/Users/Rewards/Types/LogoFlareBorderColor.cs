using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(LogoFlareBorderColor.LogoFlareBorderColorSerializer))]
[Serializable]
public readonly record struct LogoFlareBorderColor : IStringEnum
{
    public static readonly LogoFlareBorderColor Primary = new(Values.Primary);

    public static readonly LogoFlareBorderColor Secondary = new(Values.Secondary);

    public LogoFlareBorderColor(string value)
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
    public static LogoFlareBorderColor FromCustom(string value)
    {
        return new LogoFlareBorderColor(value);
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

    public static bool operator ==(LogoFlareBorderColor value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogoFlareBorderColor value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogoFlareBorderColor value) => value.Value;

    public static explicit operator LogoFlareBorderColor(string value) => new(value);

    internal class LogoFlareBorderColorSerializer : JsonConverter<LogoFlareBorderColor>
    {
        public override LogoFlareBorderColor Read(
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
            return new LogoFlareBorderColor(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogoFlareBorderColor value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogoFlareBorderColor ReadAsPropertyName(
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
            return new LogoFlareBorderColor(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogoFlareBorderColor value,
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
        public const string Primary = "PRIMARY";

        public const string Secondary = "SECONDARY";
    }
}
