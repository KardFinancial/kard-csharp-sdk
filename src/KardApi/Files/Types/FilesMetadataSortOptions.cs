using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(FilesMetadataSortOptions.FilesMetadataSortOptionsSerializer))]
[Serializable]
public readonly record struct FilesMetadataSortOptions : IStringEnum
{
    public static readonly FilesMetadataSortOptions SentDateAsc = new(Values.SentDateAsc);

    public static readonly FilesMetadataSortOptions SentDateDesc = new(Values.SentDateDesc);

    public FilesMetadataSortOptions(string value)
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
    public static FilesMetadataSortOptions FromCustom(string value)
    {
        return new FilesMetadataSortOptions(value);
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

    public static bool operator ==(FilesMetadataSortOptions value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FilesMetadataSortOptions value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FilesMetadataSortOptions value) => value.Value;

    public static explicit operator FilesMetadataSortOptions(string value) => new(value);

    internal class FilesMetadataSortOptionsSerializer : JsonConverter<FilesMetadataSortOptions>
    {
        public override FilesMetadataSortOptions Read(
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
            return new FilesMetadataSortOptions(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FilesMetadataSortOptions value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FilesMetadataSortOptions ReadAsPropertyName(
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
            return new FilesMetadataSortOptions(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FilesMetadataSortOptions value,
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
        public const string SentDateAsc = "sentDate";

        public const string SentDateDesc = "-sentDate";
    }
}
