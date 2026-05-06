using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(EnrolledReward.EnrolledRewardSerializer))]
[Serializable]
public readonly record struct EnrolledReward : IStringEnum
{
    public static readonly EnrolledReward Cardlinked = new(Values.Cardlinked);

    public static readonly EnrolledReward Affiliate = new(Values.Affiliate);

    public EnrolledReward(string value)
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
    public static EnrolledReward FromCustom(string value)
    {
        return new EnrolledReward(value);
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

    public static bool operator ==(EnrolledReward value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EnrolledReward value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EnrolledReward value) => value.Value;

    public static explicit operator EnrolledReward(string value) => new(value);

    internal class EnrolledRewardSerializer : JsonConverter<EnrolledReward>
    {
        public override EnrolledReward Read(
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
            return new EnrolledReward(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EnrolledReward value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EnrolledReward ReadAsPropertyName(
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
            return new EnrolledReward(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EnrolledReward value,
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

        public const string Affiliate = "AFFILIATE";
    }
}
