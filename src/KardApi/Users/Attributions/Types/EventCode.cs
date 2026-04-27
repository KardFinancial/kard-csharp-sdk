using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(EventCode.EventCodeSerializer))]
[Serializable]
public readonly record struct EventCode : IStringEnum
{
    public static readonly EventCode Impression = new(Values.Impression);

    public static readonly EventCode View = new(Values.View);

    public static readonly EventCode Activate = new(Values.Activate);

    public static readonly EventCode Boost = new(Values.Boost);

    public EventCode(string value)
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
    public static EventCode FromCustom(string value)
    {
        return new EventCode(value);
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

    public static bool operator ==(EventCode value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(EventCode value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(EventCode value) => value.Value;

    public static explicit operator EventCode(string value) => new(value);

    internal class EventCodeSerializer : JsonConverter<EventCode>
    {
        public override EventCode Read(
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
            return new EventCode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventCode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventCode ReadAsPropertyName(
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
            return new EventCode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventCode value,
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
        public const string Impression = "IMPRESSION";

        public const string View = "VIEW";

        public const string Activate = "ACTIVATE";

        public const string Boost = "BOOST";
    }
}
