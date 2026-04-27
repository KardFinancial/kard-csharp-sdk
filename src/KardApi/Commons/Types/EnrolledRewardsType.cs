using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(EnrolledRewardsType.EnrolledRewardsTypeSerializer))]
[Serializable]
public readonly record struct EnrolledRewardsType : IStringEnum
{
    public static readonly EnrolledRewardsType Cardlinked = new(Values.Cardlinked);

    public EnrolledRewardsType(string value)
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
    public static EnrolledRewardsType FromCustom(string value)
    {
        return new EnrolledRewardsType(value);
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

    public static bool operator ==(EnrolledRewardsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EnrolledRewardsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EnrolledRewardsType value) => value.Value;

    public static explicit operator EnrolledRewardsType(string value) => new(value);

    internal class EnrolledRewardsTypeSerializer : JsonConverter<EnrolledRewardsType>
    {
        public override EnrolledRewardsType Read(
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
            return new EnrolledRewardsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EnrolledRewardsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EnrolledRewardsType ReadAsPropertyName(
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
            return new EnrolledRewardsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EnrolledRewardsType value,
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
        public const string Cardlinked = "CARDLINKED";
    }
}
