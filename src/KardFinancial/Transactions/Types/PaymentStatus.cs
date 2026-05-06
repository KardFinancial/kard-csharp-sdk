using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(PaymentStatus.PaymentStatusSerializer))]
[Serializable]
public readonly record struct PaymentStatus : IStringEnum
{
    public static readonly PaymentStatus Unpaid = new(Values.Unpaid);

    public static readonly PaymentStatus PaidInFull = new(Values.PaidInFull);

    public PaymentStatus(string value)
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
    public static PaymentStatus FromCustom(string value)
    {
        return new PaymentStatus(value);
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

    public static bool operator ==(PaymentStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PaymentStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PaymentStatus value) => value.Value;

    public static explicit operator PaymentStatus(string value) => new(value);

    internal class PaymentStatusSerializer : JsonConverter<PaymentStatus>
    {
        public override PaymentStatus Read(
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
            return new PaymentStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PaymentStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PaymentStatus ReadAsPropertyName(
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
            return new PaymentStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PaymentStatus value,
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
        public const string Unpaid = "UNPAID";

        public const string PaidInFull = "PAID_IN_FULL";
    }
}
