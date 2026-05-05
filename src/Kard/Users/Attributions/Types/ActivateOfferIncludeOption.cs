using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Users;

[JsonConverter(typeof(ActivateOfferIncludeOption.ActivateOfferIncludeOptionSerializer))]
[Serializable]
public readonly record struct ActivateOfferIncludeOption : IStringEnum
{
    public static readonly ActivateOfferIncludeOption Offer = new(Values.Offer);

    public ActivateOfferIncludeOption(string value)
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
    public static ActivateOfferIncludeOption FromCustom(string value)
    {
        return new ActivateOfferIncludeOption(value);
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

    public static bool operator ==(ActivateOfferIncludeOption value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActivateOfferIncludeOption value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActivateOfferIncludeOption value) => value.Value;

    public static explicit operator ActivateOfferIncludeOption(string value) => new(value);

    internal class ActivateOfferIncludeOptionSerializer : JsonConverter<ActivateOfferIncludeOption>
    {
        public override ActivateOfferIncludeOption Read(
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
            return new ActivateOfferIncludeOption(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ActivateOfferIncludeOption value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ActivateOfferIncludeOption ReadAsPropertyName(
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
            return new ActivateOfferIncludeOption(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ActivateOfferIncludeOption value,
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
        public const string Offer = "offer";
    }
}
