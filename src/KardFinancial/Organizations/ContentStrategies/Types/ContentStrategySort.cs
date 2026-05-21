using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[JsonConverter(typeof(ContentStrategySort.ContentStrategySortSerializer))]
[Serializable]
public readonly record struct ContentStrategySort : IStringEnum
{
    public static readonly ContentStrategySort NewlyLive = new(Values.NewlyLive);

    public static readonly ContentStrategySort ExpiringSoon = new(Values.ExpiringSoon);

    public static readonly ContentStrategySort HighestCashback = new(Values.HighestCashback);

    public static readonly ContentStrategySort Personalized = new(Values.Personalized);

    public ContentStrategySort(string value)
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
    public static ContentStrategySort FromCustom(string value)
    {
        return new ContentStrategySort(value);
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

    public static bool operator ==(ContentStrategySort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContentStrategySort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContentStrategySort value) => value.Value;

    public static explicit operator ContentStrategySort(string value) => new(value);

    internal class ContentStrategySortSerializer : JsonConverter<ContentStrategySort>
    {
        public override ContentStrategySort Read(
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
            return new ContentStrategySort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContentStrategySort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContentStrategySort ReadAsPropertyName(
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
            return new ContentStrategySort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContentStrategySort value,
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
        public const string NewlyLive = "NEWLY_LIVE";

        public const string ExpiringSoon = "EXPIRING_SOON";

        public const string HighestCashback = "HIGHEST_CASHBACK";

        public const string Personalized = "PERSONALIZED";
    }
}
