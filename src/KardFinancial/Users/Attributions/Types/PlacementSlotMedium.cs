using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(PlacementSlotMedium.PlacementSlotMediumSerializer))]
[Serializable]
public readonly record struct PlacementSlotMedium : IStringEnum
{
    public static readonly PlacementSlotMedium Cta = new(Values.Cta);

    public PlacementSlotMedium(string value)
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
    public static PlacementSlotMedium FromCustom(string value)
    {
        return new PlacementSlotMedium(value);
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

    public static bool operator ==(PlacementSlotMedium value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlacementSlotMedium value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlacementSlotMedium value) => value.Value;

    public static explicit operator PlacementSlotMedium(string value) => new(value);

    internal class PlacementSlotMediumSerializer : JsonConverter<PlacementSlotMedium>
    {
        public override PlacementSlotMedium Read(
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
            return new PlacementSlotMedium(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlacementSlotMedium value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlacementSlotMedium ReadAsPropertyName(
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
            return new PlacementSlotMedium(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlacementSlotMedium value,
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
        public const string Cta = "CTA";
    }
}
