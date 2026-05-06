using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(FileUploadType.FileUploadTypeSerializer))]
[Serializable]
public readonly record struct FileUploadType : IStringEnum
{
    public static readonly FileUploadType IncomingTransactionsFile = new(
        Values.IncomingTransactionsFile
    );

    public static readonly FileUploadType HistoricalTransactionsFile = new(
        Values.HistoricalTransactionsFile
    );

    public FileUploadType(string value)
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
    public static FileUploadType FromCustom(string value)
    {
        return new FileUploadType(value);
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

    public static bool operator ==(FileUploadType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FileUploadType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FileUploadType value) => value.Value;

    public static explicit operator FileUploadType(string value) => new(value);

    internal class FileUploadTypeSerializer : JsonConverter<FileUploadType>
    {
        public override FileUploadType Read(
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
            return new FileUploadType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FileUploadType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FileUploadType ReadAsPropertyName(
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
            return new FileUploadType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FileUploadType value,
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
        public const string IncomingTransactionsFile = "incomingTransactionsFile";

        public const string HistoricalTransactionsFile = "historicalTransactionsFile";
    }
}
