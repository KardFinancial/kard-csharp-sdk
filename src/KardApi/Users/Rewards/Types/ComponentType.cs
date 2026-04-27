using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(ComponentType.ComponentTypeSerializer))]
[Serializable]
public readonly record struct ComponentType : IStringEnum
{
    public static readonly ComponentType ShortDescription = new(Values.ShortDescription);

    public static readonly ComponentType LongDescription = new(Values.LongDescription);

    public static readonly ComponentType BaseReward = new(Values.BaseReward);

    public static readonly ComponentType BoostedReward = new(Values.BoostedReward);

    public static readonly ComponentType Cta = new(Values.Cta);

    public static readonly ComponentType Tags = new(Values.Tags);

    public static readonly ComponentType DetailTags = new(Values.DetailTags);

    public static readonly ComponentType LogoFlare = new(Values.LogoFlare);

    public static readonly ComponentType ProgressBar = new(Values.ProgressBar);

    public ComponentType(string value)
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
    public static ComponentType FromCustom(string value)
    {
        return new ComponentType(value);
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

    public static bool operator ==(ComponentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ComponentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ComponentType value) => value.Value;

    public static explicit operator ComponentType(string value) => new(value);

    internal class ComponentTypeSerializer : JsonConverter<ComponentType>
    {
        public override ComponentType Read(
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
            return new ComponentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ComponentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ComponentType ReadAsPropertyName(
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
            return new ComponentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ComponentType value,
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
        public const string ShortDescription = "shortDescription";

        public const string LongDescription = "longDescription";

        public const string BaseReward = "baseReward";

        public const string BoostedReward = "boostedReward";

        public const string Cta = "cta";

        public const string Tags = "tags";

        public const string DetailTags = "detailTags";

        public const string LogoFlare = "logoFlare";

        public const string ProgressBar = "progressBar";
    }
}
