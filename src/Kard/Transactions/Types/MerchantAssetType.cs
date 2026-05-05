using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(MerchantAssetType.MerchantAssetTypeSerializer))]
[Serializable]
public readonly record struct MerchantAssetType : IStringEnum
{
    public static readonly MerchantAssetType ImgView = new(Values.ImgView);

    public static readonly MerchantAssetType BannerView = new(Values.BannerView);

    public MerchantAssetType(string value)
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
    public static MerchantAssetType FromCustom(string value)
    {
        return new MerchantAssetType(value);
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

    public static bool operator ==(MerchantAssetType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MerchantAssetType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MerchantAssetType value) => value.Value;

    public static explicit operator MerchantAssetType(string value) => new(value);

    internal class MerchantAssetTypeSerializer : JsonConverter<MerchantAssetType>
    {
        public override MerchantAssetType Read(
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
            return new MerchantAssetType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MerchantAssetType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MerchantAssetType ReadAsPropertyName(
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
            return new MerchantAssetType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MerchantAssetType value,
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
        public const string ImgView = "IMG_VIEW";

        public const string BannerView = "BANNER_VIEW";
    }
}
