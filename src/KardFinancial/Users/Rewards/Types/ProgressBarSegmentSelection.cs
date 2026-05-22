using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(ProgressBarSegmentSelection.ProgressBarSegmentSelectionSerializer))]
[Serializable]
public readonly record struct ProgressBarSegmentSelection : IStringEnum
{
    public static readonly ProgressBarSegmentSelection Current = new(Values.Current);

    public static readonly ProgressBarSegmentSelection CurrentAndBelow = new(
        Values.CurrentAndBelow
    );

    public ProgressBarSegmentSelection(string value)
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
    public static ProgressBarSegmentSelection FromCustom(string value)
    {
        return new ProgressBarSegmentSelection(value);
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

    public static bool operator ==(ProgressBarSegmentSelection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProgressBarSegmentSelection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProgressBarSegmentSelection value) => value.Value;

    public static explicit operator ProgressBarSegmentSelection(string value) => new(value);

    internal class ProgressBarSegmentSelectionSerializer
        : JsonConverter<ProgressBarSegmentSelection>
    {
        public override ProgressBarSegmentSelection Read(
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
            return new ProgressBarSegmentSelection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProgressBarSegmentSelection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProgressBarSegmentSelection ReadAsPropertyName(
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
            return new ProgressBarSegmentSelection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProgressBarSegmentSelection value,
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
        public const string Current = "CURRENT";

        public const string CurrentAndBelow = "CURRENT_AND_BELOW";
    }
}
