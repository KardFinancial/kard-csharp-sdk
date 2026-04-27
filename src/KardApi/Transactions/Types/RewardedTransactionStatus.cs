using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(RewardedTransactionStatus.RewardedTransactionStatusSerializer))]
[Serializable]
public readonly record struct RewardedTransactionStatus : IStringEnum
{
    public static readonly RewardedTransactionStatus Approved = new(Values.Approved);

    public static readonly RewardedTransactionStatus Settled = new(Values.Settled);

    public RewardedTransactionStatus(string value)
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
    public static RewardedTransactionStatus FromCustom(string value)
    {
        return new RewardedTransactionStatus(value);
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

    public static bool operator ==(RewardedTransactionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RewardedTransactionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RewardedTransactionStatus value) => value.Value;

    public static explicit operator RewardedTransactionStatus(string value) => new(value);

    internal class RewardedTransactionStatusSerializer : JsonConverter<RewardedTransactionStatus>
    {
        public override RewardedTransactionStatus Read(
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
            return new RewardedTransactionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RewardedTransactionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RewardedTransactionStatus ReadAsPropertyName(
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
            return new RewardedTransactionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RewardedTransactionStatus value,
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
        public const string Approved = "APPROVED";

        public const string Settled = "SETTLED";
    }
}
