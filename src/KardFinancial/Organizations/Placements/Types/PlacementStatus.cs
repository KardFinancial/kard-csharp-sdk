using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[JsonConverter(typeof(PlacementStatus.PlacementStatusSerializer))]
[Serializable]
public readonly record struct PlacementStatus : IStringEnum
{
    public static readonly PlacementStatus Active = new(Values.Active);

    public static readonly PlacementStatus Inactive = new(Values.Inactive);

    public PlacementStatus(string value)
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
    public static PlacementStatus FromCustom(string value)
    {
        return new PlacementStatus(value);
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

    public static bool operator ==(PlacementStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlacementStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlacementStatus value) => value.Value;

    public static explicit operator PlacementStatus(string value) => new(value);

    internal class PlacementStatusSerializer : JsonConverter<PlacementStatus>
    {
        public override PlacementStatus Read(
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
            return new PlacementStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlacementStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlacementStatus ReadAsPropertyName(
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
            return new PlacementStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlacementStatus value,
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
        public const string Active = "ACTIVE";

        public const string Inactive = "INACTIVE";
    }
}
