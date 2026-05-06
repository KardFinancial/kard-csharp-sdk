using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(TransactionStatus.TransactionStatusSerializer))]
[Serializable]
public readonly record struct TransactionStatus : IStringEnum
{
    public static readonly TransactionStatus Approved = new(Values.Approved);

    public static readonly TransactionStatus Settled = new(Values.Settled);

    public static readonly TransactionStatus Reversed = new(Values.Reversed);

    public static readonly TransactionStatus Returned = new(Values.Returned);

    public static readonly TransactionStatus Declined = new(Values.Declined);

    public TransactionStatus(string value)
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
    public static TransactionStatus FromCustom(string value)
    {
        return new TransactionStatus(value);
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

    public static bool operator ==(TransactionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransactionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransactionStatus value) => value.Value;

    public static explicit operator TransactionStatus(string value) => new(value);

    internal class TransactionStatusSerializer : JsonConverter<TransactionStatus>
    {
        public override TransactionStatus Read(
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
            return new TransactionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransactionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransactionStatus ReadAsPropertyName(
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
            return new TransactionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransactionStatus value,
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

        public const string Reversed = "REVERSED";

        public const string Returned = "RETURNED";

        public const string Declined = "DECLINED";
    }
}
