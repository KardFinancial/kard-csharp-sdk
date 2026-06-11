using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

[JsonConverter(typeof(PlacementTypeFilter.PlacementTypeFilterSerializer))]
[Serializable]
public readonly record struct PlacementTypeFilter : IStringEnum
{
    public static readonly PlacementTypeFilter Placement = new(Values.Placement);

    public static readonly PlacementTypeFilter PlacementPushNotification = new(
        Values.PlacementPushNotification
    );

    public static readonly PlacementTypeFilter PlacementEmail = new(Values.PlacementEmail);

    public static readonly PlacementTypeFilter PlacementBatchActivation = new(
        Values.PlacementBatchActivation
    );

    public static readonly PlacementTypeFilter PlacementGroup = new(Values.PlacementGroup);

    public PlacementTypeFilter(string value)
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
    public static PlacementTypeFilter FromCustom(string value)
    {
        return new PlacementTypeFilter(value);
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

    public static bool operator ==(PlacementTypeFilter value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlacementTypeFilter value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlacementTypeFilter value) => value.Value;

    public static explicit operator PlacementTypeFilter(string value) => new(value);

    internal class PlacementTypeFilterSerializer : JsonConverter<PlacementTypeFilter>
    {
        public override PlacementTypeFilter Read(
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
            return new PlacementTypeFilter(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlacementTypeFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlacementTypeFilter ReadAsPropertyName(
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
            return new PlacementTypeFilter(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlacementTypeFilter value,
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
        public const string Placement = "placement";

        public const string PlacementPushNotification = "placementPushNotification";

        public const string PlacementEmail = "placementEmail";

        public const string PlacementBatchActivation = "placementBatchActivation";

        public const string PlacementGroup = "placementGroup";
    }
}
