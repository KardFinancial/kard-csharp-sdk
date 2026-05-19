using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[JsonConverter(typeof(ContentStrategyFilter.ContentStrategyFilterSerializer))]
[Serializable]
public readonly record struct ContentStrategyFilter : IStringEnum
{
    public static readonly ContentStrategyFilter NewlyLive = new(Values.NewlyLive);

    public static readonly ContentStrategyFilter ExpiringSoon = new(Values.ExpiringSoon);

    public static readonly ContentStrategyFilter HighestCashback = new(Values.HighestCashback);

    public static readonly ContentStrategyFilter Personalized = new(Values.Personalized);

    public ContentStrategyFilter(string value)
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
    public static ContentStrategyFilter FromCustom(string value)
    {
        return new ContentStrategyFilter(value);
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

    public static bool operator ==(ContentStrategyFilter value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContentStrategyFilter value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContentStrategyFilter value) => value.Value;

    public static explicit operator ContentStrategyFilter(string value) => new(value);

    internal class ContentStrategyFilterSerializer : JsonConverter<ContentStrategyFilter>
    {
        public override ContentStrategyFilter Read(
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
            return new ContentStrategyFilter(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContentStrategyFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContentStrategyFilter ReadAsPropertyName(
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
            return new ContentStrategyFilter(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContentStrategyFilter value,
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
