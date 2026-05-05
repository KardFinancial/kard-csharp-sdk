using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Users;

[JsonConverter(typeof(NotificationMedium.NotificationMediumSerializer))]
[Serializable]
public readonly record struct NotificationMedium : IStringEnum
{
    public static readonly NotificationMedium Push = new(Values.Push);

    public NotificationMedium(string value)
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
    public static NotificationMedium FromCustom(string value)
    {
        return new NotificationMedium(value);
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

    public static bool operator ==(NotificationMedium value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationMedium value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationMedium value) => value.Value;

    public static explicit operator NotificationMedium(string value) => new(value);

    internal class NotificationMediumSerializer : JsonConverter<NotificationMedium>
    {
        public override NotificationMedium Read(
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
            return new NotificationMedium(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationMedium value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NotificationMedium ReadAsPropertyName(
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
            return new NotificationMedium(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotificationMedium value,
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
        public const string Push = "PUSH";
    }
}
