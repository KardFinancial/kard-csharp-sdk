using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(NotificationType.NotificationTypeSerializer))]
[Serializable]
public readonly record struct NotificationType : IStringEnum
{
    public static readonly NotificationType EarnedRewardApproved = new(Values.EarnedRewardApproved);

    public static readonly NotificationType EarnedRewardSettled = new(Values.EarnedRewardSettled);

    public static readonly NotificationType ValidTransaction = new(Values.ValidTransaction);

    public static readonly NotificationType FailedTransaction = new(Values.FailedTransaction);

    public static readonly NotificationType Clawback = new(Values.Clawback);

    public static readonly NotificationType AuditUpdate = new(Values.AuditUpdate);

    public static readonly NotificationType FileProcessingResult = new(Values.FileProcessingResult);

    public NotificationType(string value)
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
    public static NotificationType FromCustom(string value)
    {
        return new NotificationType(value);
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

    public static bool operator ==(NotificationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationType value) => value.Value;

    public static explicit operator NotificationType(string value) => new(value);

    internal class NotificationTypeSerializer : JsonConverter<NotificationType>
    {
        public override NotificationType Read(
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
            return new NotificationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NotificationType ReadAsPropertyName(
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
            return new NotificationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotificationType value,
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
        public const string EarnedRewardApproved = "earnedRewardApproved";

        public const string EarnedRewardSettled = "earnedRewardSettled";

        public const string ValidTransaction = "validTransaction";

        public const string FailedTransaction = "failedTransaction";

        public const string Clawback = "clawback";

        public const string AuditUpdate = "auditUpdate";

        public const string FileProcessingResult = "fileProcessingResult";
    }
}
