using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(OfferSortOptions.OfferSortOptionsSerializer))]
[Serializable]
public readonly record struct OfferSortOptions : IStringEnum
{
    public static readonly OfferSortOptions StartDateAsc = new(Values.StartDateAsc);

    public static readonly OfferSortOptions StartDateDesc = new(Values.StartDateDesc);

    public static readonly OfferSortOptions ExpirationDateAsc = new(Values.ExpirationDateAsc);

    public static readonly OfferSortOptions ExpirationDateDesc = new(Values.ExpirationDateDesc);

    public static readonly OfferSortOptions NameAsc = new(Values.NameAsc);

    public static readonly OfferSortOptions NameDesc = new(Values.NameDesc);

    public OfferSortOptions(string value)
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
    public static OfferSortOptions FromCustom(string value)
    {
        return new OfferSortOptions(value);
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

    public static bool operator ==(OfferSortOptions value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OfferSortOptions value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OfferSortOptions value) => value.Value;

    public static explicit operator OfferSortOptions(string value) => new(value);

    internal class OfferSortOptionsSerializer : JsonConverter<OfferSortOptions>
    {
        public override OfferSortOptions Read(
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
            return new OfferSortOptions(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OfferSortOptions value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OfferSortOptions ReadAsPropertyName(
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
            return new OfferSortOptions(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OfferSortOptions value,
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
        public const string StartDateAsc = "startDate";

        public const string StartDateDesc = "-startDate";

        public const string ExpirationDateAsc = "expirationDate";

        public const string ExpirationDateDesc = "-expirationDate";

        public const string NameAsc = "name";

        public const string NameDesc = "-name";
    }
}
