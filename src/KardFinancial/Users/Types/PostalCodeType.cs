using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(PostalCodeType.PostalCodeTypeSerializer))]
[Serializable]
public readonly record struct PostalCodeType : IStringEnum
{
    public static readonly PostalCodeType Physical = new(Values.Physical);

    public static readonly PostalCodeType Billing = new(Values.Billing);

    public static readonly PostalCodeType Other = new(Values.Other);

    public PostalCodeType(string value)
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
    public static PostalCodeType FromCustom(string value)
    {
        return new PostalCodeType(value);
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

    public static bool operator ==(PostalCodeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PostalCodeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PostalCodeType value) => value.Value;

    public static explicit operator PostalCodeType(string value) => new(value);

    internal class PostalCodeTypeSerializer : JsonConverter<PostalCodeType>
    {
        public override PostalCodeType Read(
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
            return new PostalCodeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PostalCodeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PostalCodeType ReadAsPropertyName(
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
            return new PostalCodeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PostalCodeType value,
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
        public const string Physical = "PHYSICAL";

        public const string Billing = "BILLING";

        public const string Other = "OTHER";
    }
}
