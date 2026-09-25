using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(RejectedReason.RejectedReasonSerializer))]
[Serializable]
public readonly record struct RejectedReason : IStringEnum
{
    public static readonly RejectedReason AggregatorCardOverlap = new(Values.AggregatorCardOverlap);

    public static readonly RejectedReason MaxRedemptionLimitReached = new(
        Values.MaxRedemptionLimitReached
    );

    public static readonly RejectedReason SettlementRejected = new(Values.SettlementRejected);

    public static readonly RejectedReason UserNotEnrolled = new(Values.UserNotEnrolled);

    public static readonly RejectedReason UserNotInAudienceSegment = new(
        Values.UserNotInAudienceSegment
    );

    public RejectedReason(string value)
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
    public static RejectedReason FromCustom(string value)
    {
        return new RejectedReason(value);
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

    public static bool operator ==(RejectedReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RejectedReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RejectedReason value) => value.Value;

    public static explicit operator RejectedReason(string value) => new(value);

    internal class RejectedReasonSerializer : JsonConverter<RejectedReason>
    {
        public override RejectedReason Read(
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
            return new RejectedReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RejectedReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RejectedReason ReadAsPropertyName(
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
            return new RejectedReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RejectedReason value,
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
        public const string AggregatorCardOverlap = "AGGREGATOR_CARD_OVERLAP";

        public const string MaxRedemptionLimitReached = "MAX_REDEMPTION_LIMIT_REACHED";

        public const string SettlementRejected = "SETTLEMENT_REJECTED";

        public const string UserNotEnrolled = "USER_NOT_ENROLLED";

        public const string UserNotInAudienceSegment = "USER_NOT_IN_AUDIENCE_SEGMENT";
    }
}
