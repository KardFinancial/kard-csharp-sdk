using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(ProgressBarSegmentSeparator.ProgressBarSegmentSeparatorSerializer))]
[Serializable]
public readonly record struct ProgressBarSegmentSeparator : IStringEnum
{
    public static readonly ProgressBarSegmentSeparator Line = new(Values.Line);

    public ProgressBarSegmentSeparator(string value)
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
    public static ProgressBarSegmentSeparator FromCustom(string value)
    {
        return new ProgressBarSegmentSeparator(value);
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

    public static bool operator ==(ProgressBarSegmentSeparator value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProgressBarSegmentSeparator value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProgressBarSegmentSeparator value) => value.Value;

    public static explicit operator ProgressBarSegmentSeparator(string value) => new(value);

    internal class ProgressBarSegmentSeparatorSerializer
        : JsonConverter<ProgressBarSegmentSeparator>
    {
        public override ProgressBarSegmentSeparator Read(
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
            return new ProgressBarSegmentSeparator(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProgressBarSegmentSeparator value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProgressBarSegmentSeparator ReadAsPropertyName(
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
            return new ProgressBarSegmentSeparator(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProgressBarSegmentSeparator value,
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
        public const string Line = "LINE";
    }
}
