using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Organizations;

[JsonConverter(typeof(CadenceFrequency.CadenceFrequencySerializer))]
[Serializable]
public readonly record struct CadenceFrequency : IStringEnum
{
    public static readonly CadenceFrequency Daily = new(Values.Daily);

    public static readonly CadenceFrequency Weekly = new(Values.Weekly);

    public static readonly CadenceFrequency Monthly = new(Values.Monthly);

    public CadenceFrequency(string value)
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
    public static CadenceFrequency FromCustom(string value)
    {
        return new CadenceFrequency(value);
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

    public static bool operator ==(CadenceFrequency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CadenceFrequency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CadenceFrequency value) => value.Value;

    public static explicit operator CadenceFrequency(string value) => new(value);

    internal class CadenceFrequencySerializer : JsonConverter<CadenceFrequency>
    {
        public override CadenceFrequency Read(
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
            return new CadenceFrequency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CadenceFrequency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CadenceFrequency ReadAsPropertyName(
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
            return new CadenceFrequency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CadenceFrequency value,
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
        public const string Daily = "DAILY";

        public const string Weekly = "WEEKLY";

        public const string Monthly = "MONTHLY";
    }
}
