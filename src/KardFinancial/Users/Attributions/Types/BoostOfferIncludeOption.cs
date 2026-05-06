using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(BoostOfferIncludeOption.BoostOfferIncludeOptionSerializer))]
[Serializable]
public readonly record struct BoostOfferIncludeOption : IStringEnum
{
    public static readonly BoostOfferIncludeOption Offer = new(Values.Offer);

    public BoostOfferIncludeOption(string value)
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
    public static BoostOfferIncludeOption FromCustom(string value)
    {
        return new BoostOfferIncludeOption(value);
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

    public static bool operator ==(BoostOfferIncludeOption value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BoostOfferIncludeOption value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BoostOfferIncludeOption value) => value.Value;

    public static explicit operator BoostOfferIncludeOption(string value) => new(value);

    internal class BoostOfferIncludeOptionSerializer : JsonConverter<BoostOfferIncludeOption>
    {
        public override BoostOfferIncludeOption Read(
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
            return new BoostOfferIncludeOption(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BoostOfferIncludeOption value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BoostOfferIncludeOption ReadAsPropertyName(
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
            return new BoostOfferIncludeOption(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BoostOfferIncludeOption value,
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
