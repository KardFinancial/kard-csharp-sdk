using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[JsonConverter(typeof(OfferFeatures.OfferFeaturesSerializer))]
[Serializable]
public readonly record struct OfferFeatures : IStringEnum
{
    public static readonly OfferFeatures Interactive = new(Values.Interactive);

    public OfferFeatures(string value)
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
    public static OfferFeatures FromCustom(string value)
    {
        return new OfferFeatures(value);
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

    public static bool operator ==(OfferFeatures value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OfferFeatures value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OfferFeatures value) => value.Value;

    public static explicit operator OfferFeatures(string value) => new(value);

    internal class OfferFeaturesSerializer : JsonConverter<OfferFeatures>
    {
        public override OfferFeatures Read(
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
            return new OfferFeatures(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OfferFeatures value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OfferFeatures ReadAsPropertyName(
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
            return new OfferFeatures(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OfferFeatures value,
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
        public const string Interactive = "INTERACTIVE";
    }
}
