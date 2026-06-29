using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(OfferMedium.OfferMediumSerializer))]
[Serializable]
public readonly record struct OfferMedium : IStringEnum
{
    public static readonly OfferMedium Browse = new(Values.Browse);

    public static readonly OfferMedium Email = new(Values.Email);

    public static readonly OfferMedium Map = new(Values.Map);

    public static readonly OfferMedium Search = new(Values.Search);

    public static readonly OfferMedium Cta = new(Values.Cta);

    public static readonly OfferMedium Push = new(Values.Push);

    public OfferMedium(string value)
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
    public static OfferMedium FromCustom(string value)
    {
        return new OfferMedium(value);
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

    public static bool operator ==(OfferMedium value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OfferMedium value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OfferMedium value) => value.Value;

    public static explicit operator OfferMedium(string value) => new(value);

    internal class OfferMediumSerializer : JsonConverter<OfferMedium>
    {
        public override OfferMedium Read(
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
            return new OfferMedium(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OfferMedium value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OfferMedium ReadAsPropertyName(
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
            return new OfferMedium(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OfferMedium value,
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
        public const string Browse = "BROWSE";

        public const string Email = "EMAIL";

        public const string Map = "MAP";

        public const string Search = "SEARCH";

        public const string Cta = "CTA";

        public const string Push = "PUSH";
    }
}
