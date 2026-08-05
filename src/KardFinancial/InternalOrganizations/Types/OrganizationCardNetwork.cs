using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(OrganizationCardNetwork.OrganizationCardNetworkSerializer))]
[Serializable]
public readonly record struct OrganizationCardNetwork : IStringEnum
{
    public static readonly OrganizationCardNetwork Visa = new(Values.Visa);

    public static readonly OrganizationCardNetwork Mastercard = new(Values.Mastercard);

    public static readonly OrganizationCardNetwork AmericanExpress = new(Values.AmericanExpress);

    public static readonly OrganizationCardNetwork Discover = new(Values.Discover);

    public OrganizationCardNetwork(string value)
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
    public static OrganizationCardNetwork FromCustom(string value)
    {
        return new OrganizationCardNetwork(value);
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

    public static bool operator ==(OrganizationCardNetwork value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationCardNetwork value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationCardNetwork value) => value.Value;

    public static explicit operator OrganizationCardNetwork(string value) => new(value);

    internal class OrganizationCardNetworkSerializer : JsonConverter<OrganizationCardNetwork>
    {
        public override OrganizationCardNetwork Read(
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
            return new OrganizationCardNetwork(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationCardNetwork value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationCardNetwork ReadAsPropertyName(
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
            return new OrganizationCardNetwork(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationCardNetwork value,
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
        public const string Visa = "VISA";

        public const string Mastercard = "MASTERCARD";

        public const string AmericanExpress = "AMERICAN_EXPRESS";

        public const string Discover = "DISCOVER";
    }
}
