using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(FileType.FileTypeSerializer))]
[Serializable]
public readonly record struct FileType : IStringEnum
{
    public static readonly FileType EarnedRewardApprovedDailyReconciliationFile = new(
        Values.EarnedRewardApprovedDailyReconciliationFile
    );

    public static readonly FileType EarnedRewardSettledDailyReconciliationFile = new(
        Values.EarnedRewardSettledDailyReconciliationFile
    );

    public static readonly FileType ValidatedTransactionDailyReconciliationFile = new(
        Values.ValidatedTransactionDailyReconciliationFile
    );

    public static readonly FileType MonthlyReconciliationFile = new(
        Values.MonthlyReconciliationFile
    );

    public FileType(string value)
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
    public static FileType FromCustom(string value)
    {
        return new FileType(value);
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

    public static bool operator ==(FileType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(FileType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(FileType value) => value.Value;

    public static explicit operator FileType(string value) => new(value);

    internal class FileTypeSerializer : JsonConverter<FileType>
    {
        public override FileType Read(
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
            return new FileType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FileType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FileType ReadAsPropertyName(
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
            return new FileType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FileType value,
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
        public const string EarnedRewardApprovedDailyReconciliationFile =
            "earnedRewardApprovedDailyReconciliationFile";

        public const string EarnedRewardSettledDailyReconciliationFile =
            "earnedRewardSettledDailyReconciliationFile";

        public const string ValidatedTransactionDailyReconciliationFile =
            "validatedTransactionDailyReconciliationFile";

        public const string MonthlyReconciliationFile = "monthlyReconciliationFile";
    }
}
