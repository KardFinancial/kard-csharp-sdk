// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(OfferDataUnion.JsonConverter))]
[Serializable]
public record OfferDataUnion
{
    internal OfferDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of OfferDataUnion with <see cref="OfferDataUnion.StandardOffer"/>.
    /// </summary>
    public OfferDataUnion(OfferDataUnion.StandardOffer value)
    {
        Type = "standardOffer";
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
    /// Returns true if <see cref="Type"/> is "standardOffer"
    /// </summary>
    public bool IsStandardOffer => Type == "standardOffer";

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Users.StandardOffer"/> if <see cref="Type"/> is 'standardOffer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'standardOffer'.</exception>
    public KardFinancial.Users.StandardOffer AsStandardOffer() =>
        IsStandardOffer
            ? (KardFinancial.Users.StandardOffer)Value!
            : throw new global::System.Exception("OfferDataUnion.Type is not 'standardOffer'");

    public T Match<T>(
        Func<KardFinancial.Users.StandardOffer, T> onStandardOffer,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "standardOffer" => onStandardOffer(AsStandardOffer()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.Users.StandardOffer> onStandardOffer,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "standardOffer":
                onStandardOffer(AsStandardOffer());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Users.StandardOffer"/> and returns true if successful.
    /// </summary>
    public bool TryAsStandardOffer(out KardFinancial.Users.StandardOffer? value)
    {
        if (Type == "standardOffer")
        {
            value = (KardFinancial.Users.StandardOffer)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator OfferDataUnion(OfferDataUnion.StandardOffer value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<OfferDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(OfferDataUnion).IsAssignableFrom(typeToConvert);

        public override OfferDataUnion Read(
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
                "standardOffer" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Users.StandardOffer?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Users.StandardOffer"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new OfferDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OfferDataUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "standardOffer" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override OfferDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new OfferDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OfferDataUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for standardOffer
    /// </summary>
    [Serializable]
    public struct StandardOffer
    {
        public StandardOffer(KardFinancial.Users.StandardOffer value)
        {
            Value = value;
        }

        internal KardFinancial.Users.StandardOffer Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator OfferDataUnion.StandardOffer(
            KardFinancial.Users.StandardOffer value
        ) => new(value);
    }
}
