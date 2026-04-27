// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(TransactionIncludedResource.JsonConverter))]
[Serializable]
public record TransactionIncludedResource
{
    internal TransactionIncludedResource(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TransactionIncludedResource with <see cref="TransactionIncludedResource.Merchant"/>.
    /// </summary>
    public TransactionIncludedResource(TransactionIncludedResource.Merchant value)
    {
        Type = "merchant";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TransactionIncludedResource with <see cref="TransactionIncludedResource.Offer"/>.
    /// </summary>
    public TransactionIncludedResource(TransactionIncludedResource.Offer value)
    {
        Type = "offer";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "merchant"
    /// </summary>
    public bool IsMerchant => Type == "merchant";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "offer"
    /// </summary>
    public bool IsOffer => Type == "offer";

    /// <summary>
    /// Returns the value as a <see cref="KardApi.TransactionMerchantResource"/> if <see cref="Type"/> is 'merchant', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'merchant'.</exception>
    public KardApi.TransactionMerchantResource AsMerchant() =>
        IsMerchant
            ? (KardApi.TransactionMerchantResource)Value!
            : throw new global::System.Exception(
                "TransactionIncludedResource.Type is not 'merchant'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardApi.TransactionOfferResource"/> if <see cref="Type"/> is 'offer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'offer'.</exception>
    public KardApi.TransactionOfferResource AsOffer() =>
        IsOffer
            ? (KardApi.TransactionOfferResource)Value!
            : throw new global::System.Exception("TransactionIncludedResource.Type is not 'offer'");

    public T Match<T>(
        Func<KardApi.TransactionMerchantResource, T> onMerchant,
        Func<KardApi.TransactionOfferResource, T> onOffer,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "merchant" => onMerchant(AsMerchant()),
            "offer" => onOffer(AsOffer()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardApi.TransactionMerchantResource> onMerchant,
        Action<KardApi.TransactionOfferResource> onOffer,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "merchant":
                onMerchant(AsMerchant());
                break;
            case "offer":
                onOffer(AsOffer());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.TransactionMerchantResource"/> and returns true if successful.
    /// </summary>
    public bool TryAsMerchant(out KardApi.TransactionMerchantResource? value)
    {
        if (Type == "merchant")
        {
            value = (KardApi.TransactionMerchantResource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.TransactionOfferResource"/> and returns true if successful.
    /// </summary>
    public bool TryAsOffer(out KardApi.TransactionOfferResource? value)
    {
        if (Type == "offer")
        {
            value = (KardApi.TransactionOfferResource)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TransactionIncludedResource(
        TransactionIncludedResource.Merchant value
    ) => new(value);

    public static implicit operator TransactionIncludedResource(
        TransactionIncludedResource.Offer value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TransactionIncludedResource>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TransactionIncludedResource).IsAssignableFrom(typeToConvert);

        public override TransactionIncludedResource Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("type");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "merchant" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.TransactionMerchantResource?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.TransactionMerchantResource"
                        ),
                "offer" => jsonWithoutDiscriminator.Deserialize<KardApi.TransactionOfferResource?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize KardApi.TransactionOfferResource"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new TransactionIncludedResource(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransactionIncludedResource value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "merchant" => JsonSerializer.SerializeToNode(value.Value, options),
                    "offer" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override TransactionIncludedResource ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TransactionIncludedResource(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransactionIncludedResource value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for merchant
    /// </summary>
    [Serializable]
    public struct Merchant
    {
        public Merchant(KardApi.TransactionMerchantResource value)
        {
            Value = value;
        }

        internal KardApi.TransactionMerchantResource Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransactionIncludedResource.Merchant(
            KardApi.TransactionMerchantResource value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for offer
    /// </summary>
    [Serializable]
    public struct Offer
    {
        public Offer(KardApi.TransactionOfferResource value)
        {
            Value = value;
        }

        internal KardApi.TransactionOfferResource Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransactionIncludedResource.Offer(
            KardApi.TransactionOfferResource value
        ) => new(value);
    }
}
