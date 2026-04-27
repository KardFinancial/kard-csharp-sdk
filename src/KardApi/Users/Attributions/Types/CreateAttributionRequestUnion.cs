// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(CreateAttributionRequestUnion.JsonConverter))]
[Serializable]
public record CreateAttributionRequestUnion
{
    internal CreateAttributionRequestUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateAttributionRequestUnion with <see cref="CreateAttributionRequestUnion.OfferAttribution"/>.
    /// </summary>
    public CreateAttributionRequestUnion(CreateAttributionRequestUnion.OfferAttribution value)
    {
        Type = "offerAttribution";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreateAttributionRequestUnion with <see cref="CreateAttributionRequestUnion.NotificationAttribution"/>.
    /// </summary>
    public CreateAttributionRequestUnion(
        CreateAttributionRequestUnion.NotificationAttribution value
    )
    {
        Type = "notificationAttribution";
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
    /// Returns true if <see cref="Type"/> is "offerAttribution"
    /// </summary>
    public bool IsOfferAttribution => Type == "offerAttribution";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "notificationAttribution"
    /// </summary>
    public bool IsNotificationAttribution => Type == "notificationAttribution";

    /// <summary>
    /// Returns the value as a <see cref="KardApi.Users.OfferAttributionRequest"/> if <see cref="Type"/> is 'offerAttribution', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'offerAttribution'.</exception>
    public KardApi.Users.OfferAttributionRequest AsOfferAttribution() =>
        IsOfferAttribution
            ? (KardApi.Users.OfferAttributionRequest)Value!
            : throw new global::System.Exception(
                "CreateAttributionRequestUnion.Type is not 'offerAttribution'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardApi.Users.NotificationAttributionRequest"/> if <see cref="Type"/> is 'notificationAttribution', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'notificationAttribution'.</exception>
    public KardApi.Users.NotificationAttributionRequest AsNotificationAttribution() =>
        IsNotificationAttribution
            ? (KardApi.Users.NotificationAttributionRequest)Value!
            : throw new global::System.Exception(
                "CreateAttributionRequestUnion.Type is not 'notificationAttribution'"
            );

    public T Match<T>(
        Func<KardApi.Users.OfferAttributionRequest, T> onOfferAttribution,
        Func<KardApi.Users.NotificationAttributionRequest, T> onNotificationAttribution,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "offerAttribution" => onOfferAttribution(AsOfferAttribution()),
            "notificationAttribution" => onNotificationAttribution(AsNotificationAttribution()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardApi.Users.OfferAttributionRequest> onOfferAttribution,
        Action<KardApi.Users.NotificationAttributionRequest> onNotificationAttribution,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "offerAttribution":
                onOfferAttribution(AsOfferAttribution());
                break;
            case "notificationAttribution":
                onNotificationAttribution(AsNotificationAttribution());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.Users.OfferAttributionRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsOfferAttribution(out KardApi.Users.OfferAttributionRequest? value)
    {
        if (Type == "offerAttribution")
        {
            value = (KardApi.Users.OfferAttributionRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.Users.NotificationAttributionRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsNotificationAttribution(
        out KardApi.Users.NotificationAttributionRequest? value
    )
    {
        if (Type == "notificationAttribution")
        {
            value = (KardApi.Users.NotificationAttributionRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateAttributionRequestUnion(
        CreateAttributionRequestUnion.OfferAttribution value
    ) => new(value);

    public static implicit operator CreateAttributionRequestUnion(
        CreateAttributionRequestUnion.NotificationAttribution value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateAttributionRequestUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateAttributionRequestUnion).IsAssignableFrom(typeToConvert);

        public override CreateAttributionRequestUnion Read(
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
                "offerAttribution" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.Users.OfferAttributionRequest?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.Users.OfferAttributionRequest"
                        ),
                "notificationAttribution" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.Users.NotificationAttributionRequest?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.Users.NotificationAttributionRequest"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateAttributionRequestUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateAttributionRequestUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "offerAttribution" => JsonSerializer.SerializeToNode(value.Value, options),
                    "notificationAttribution" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override CreateAttributionRequestUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateAttributionRequestUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateAttributionRequestUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for offerAttribution
    /// </summary>
    [Serializable]
    public struct OfferAttribution
    {
        public OfferAttribution(KardApi.Users.OfferAttributionRequest value)
        {
            Value = value;
        }

        internal KardApi.Users.OfferAttributionRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateAttributionRequestUnion.OfferAttribution(
            KardApi.Users.OfferAttributionRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for notificationAttribution
    /// </summary>
    [Serializable]
    public struct NotificationAttribution
    {
        public NotificationAttribution(KardApi.Users.NotificationAttributionRequest value)
        {
            Value = value;
        }

        internal KardApi.Users.NotificationAttributionRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateAttributionRequestUnion.NotificationAttribution(
            KardApi.Users.NotificationAttributionRequest value
        ) => new(value);
    }
}
