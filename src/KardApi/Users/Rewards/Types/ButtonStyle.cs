using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(ButtonStyle.ButtonStyleSerializer))]
[Serializable]
public readonly record struct ButtonStyle : IStringEnum
{
    public static readonly ButtonStyle Primary = new(Values.Primary);

    public static readonly ButtonStyle Secondary = new(Values.Secondary);

    public static readonly ButtonStyle Disabled = new(Values.Disabled);

    public ButtonStyle(string value)
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
    public static ButtonStyle FromCustom(string value)
    {
        return new ButtonStyle(value);
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

    public static bool operator ==(ButtonStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ButtonStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ButtonStyle value) => value.Value;

    public static explicit operator ButtonStyle(string value) => new(value);

    internal class ButtonStyleSerializer : JsonConverter<ButtonStyle>
    {
        public override ButtonStyle Read(
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
            return new ButtonStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ButtonStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ButtonStyle ReadAsPropertyName(
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
            return new ButtonStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ButtonStyle value,
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

        public const string Disabled = "DISABLED";
    }
}
