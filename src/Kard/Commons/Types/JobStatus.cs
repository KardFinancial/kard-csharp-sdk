using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(JobStatus.JobStatusSerializer))]
[Serializable]
public readonly record struct JobStatus : IStringEnum
{
    public static readonly JobStatus Queued = new(Values.Queued);

    public JobStatus(string value)
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
    public static JobStatus FromCustom(string value)
    {
        return new JobStatus(value);
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

    public static bool operator ==(JobStatus value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(JobStatus value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(JobStatus value) => value.Value;

    public static explicit operator JobStatus(string value) => new(value);

    internal class JobStatusSerializer : JsonConverter<JobStatus>
    {
        public override JobStatus Read(
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
            return new JobStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            JobStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override JobStatus ReadAsPropertyName(
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
            return new JobStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            JobStatus value,
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
        public const string Queued = "queued";
    }
}
