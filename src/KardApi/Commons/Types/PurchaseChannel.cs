using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(PurchaseChannel.PurchaseChannelSerializer))]
[Serializable]
public readonly record struct PurchaseChannel : IStringEnum
{
    public static readonly PurchaseChannel Instore = new(Values.Instore);

    public static readonly PurchaseChannel Online = new(Values.Online);

    public PurchaseChannel(string value)
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
    public static PurchaseChannel FromCustom(string value)
    {
        return new PurchaseChannel(value);
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

    public static bool operator ==(PurchaseChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PurchaseChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PurchaseChannel value) => value.Value;

    public static explicit operator PurchaseChannel(string value) => new(value);

    internal class PurchaseChannelSerializer : JsonConverter<PurchaseChannel>
    {
        public override PurchaseChannel Read(
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
            return new PurchaseChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PurchaseChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PurchaseChannel ReadAsPropertyName(
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
            return new PurchaseChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PurchaseChannel value,
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
        public const string Instore = "INSTORE";

        public const string Online = "ONLINE";
    }
}
