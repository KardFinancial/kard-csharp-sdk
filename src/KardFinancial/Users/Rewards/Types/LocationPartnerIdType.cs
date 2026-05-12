using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(LocationPartnerIdType.LocationPartnerIdTypeSerializer))]
[Serializable]
public readonly record struct LocationPartnerIdType : IStringEnum
{
    public static readonly LocationPartnerIdType Google = new(Values.Google);

    public LocationPartnerIdType(string value)
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
    public static LocationPartnerIdType FromCustom(string value)
    {
        return new LocationPartnerIdType(value);
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

    public static bool operator ==(LocationPartnerIdType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LocationPartnerIdType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LocationPartnerIdType value) => value.Value;

    public static explicit operator LocationPartnerIdType(string value) => new(value);

    internal class LocationPartnerIdTypeSerializer : JsonConverter<LocationPartnerIdType>
    {
        public override LocationPartnerIdType Read(
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
            return new LocationPartnerIdType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LocationPartnerIdType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LocationPartnerIdType ReadAsPropertyName(
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
            return new LocationPartnerIdType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LocationPartnerIdType value,
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
        public const string Google = "google";
    }
}
