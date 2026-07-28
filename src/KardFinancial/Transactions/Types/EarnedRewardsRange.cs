using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(EarnedRewardsRange.EarnedRewardsRangeSerializer))]
[Serializable]
public readonly record struct EarnedRewardsRange : IStringEnum
{
    public static readonly EarnedRewardsRange Last12Months = new(Values.Last12Months);

    public static readonly EarnedRewardsRange Last6Months = new(Values.Last6Months);

    public static readonly EarnedRewardsRange Last3Months = new(Values.Last3Months);

    public static readonly EarnedRewardsRange YearToDate = new(Values.YearToDate);

    public EarnedRewardsRange(string value)
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
    public static EarnedRewardsRange FromCustom(string value)
    {
        return new EarnedRewardsRange(value);
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

    public static bool operator ==(EarnedRewardsRange value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EarnedRewardsRange value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EarnedRewardsRange value) => value.Value;

    public static explicit operator EarnedRewardsRange(string value) => new(value);

    internal class EarnedRewardsRangeSerializer : JsonConverter<EarnedRewardsRange>
    {
        public override EarnedRewardsRange Read(
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
            return new EarnedRewardsRange(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EarnedRewardsRange value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EarnedRewardsRange ReadAsPropertyName(
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
            return new EarnedRewardsRange(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EarnedRewardsRange value,
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
        public const string Last12Months = "12M";

        public const string Last6Months = "6M";

        public const string Last3Months = "3M";

        public const string YearToDate = "YTD";
    }
}
