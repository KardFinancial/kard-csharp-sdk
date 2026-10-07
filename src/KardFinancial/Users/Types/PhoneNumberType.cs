using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(PhoneNumberType.PhoneNumberTypeSerializer))]
[Serializable]
public readonly record struct PhoneNumberType : IStringEnum
{
    public static readonly PhoneNumberType Mobile = new(Values.Mobile);

    public static readonly PhoneNumberType Home = new(Values.Home);

    public static readonly PhoneNumberType Work = new(Values.Work);

    public static readonly PhoneNumberType Other = new(Values.Other);

    public PhoneNumberType(string value)
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
    public static PhoneNumberType FromCustom(string value)
    {
        return new PhoneNumberType(value);
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

    public static bool operator ==(PhoneNumberType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PhoneNumberType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PhoneNumberType value) => value.Value;

    public static explicit operator PhoneNumberType(string value) => new(value);

    internal class PhoneNumberTypeSerializer : JsonConverter<PhoneNumberType>
    {
        public override PhoneNumberType Read(
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
            return new PhoneNumberType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneNumberType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PhoneNumberType ReadAsPropertyName(
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
            return new PhoneNumberType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneNumberType value,
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
        public const string Mobile = "MOBILE";

        public const string Home = "HOME";

        public const string Work = "WORK";

        public const string Other = "OTHER";
    }
}
