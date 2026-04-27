using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(ProgressBarSegmentPosition.ProgressBarSegmentPositionSerializer))]
[Serializable]
public readonly record struct ProgressBarSegmentPosition : IStringEnum
{
    public static readonly ProgressBarSegmentPosition Left = new(Values.Left);

    public static readonly ProgressBarSegmentPosition Right = new(Values.Right);

    public static readonly ProgressBarSegmentPosition FullWidth = new(Values.FullWidth);

    public ProgressBarSegmentPosition(string value)
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
    public static ProgressBarSegmentPosition FromCustom(string value)
    {
        return new ProgressBarSegmentPosition(value);
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

    public static bool operator ==(ProgressBarSegmentPosition value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProgressBarSegmentPosition value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProgressBarSegmentPosition value) => value.Value;

    public static explicit operator ProgressBarSegmentPosition(string value) => new(value);

    internal class ProgressBarSegmentPositionSerializer : JsonConverter<ProgressBarSegmentPosition>
    {
        public override ProgressBarSegmentPosition Read(
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
            return new ProgressBarSegmentPosition(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProgressBarSegmentPosition value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProgressBarSegmentPosition ReadAsPropertyName(
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
            return new ProgressBarSegmentPosition(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProgressBarSegmentPosition value,
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
        public const string Left = "LEFT";

        public const string Right = "RIGHT";

        public const string FullWidth = "FULL_WIDTH";
    }
}
