// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Notifications;

[JsonConverter(typeof(SubscriptionRequestUnion.JsonConverter))]
[Serializable]
public record SubscriptionRequestUnion
{
    internal SubscriptionRequestUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SubscriptionRequestUnion with <see cref="SubscriptionRequestUnion.Subscription"/>.
    /// </summary>
    public SubscriptionRequestUnion(SubscriptionRequestUnion.Subscription value)
    {
        Type = "subscription";
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
    /// Returns true if <see cref="Type"/> is "subscription"
    /// </summary>
    public bool IsSubscription => Type == "subscription";

    /// <summary>
    /// Returns the value as a <see cref="KardApi.Notifications.SubscriptionRequest"/> if <see cref="Type"/> is 'subscription', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'subscription'.</exception>
    public KardApi.Notifications.SubscriptionRequest AsSubscription() =>
        IsSubscription
            ? (KardApi.Notifications.SubscriptionRequest)Value!
            : throw new global::System.Exception(
                "SubscriptionRequestUnion.Type is not 'subscription'"
            );

    public T Match<T>(
        Func<KardApi.Notifications.SubscriptionRequest, T> onSubscription,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "subscription" => onSubscription(AsSubscription()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardApi.Notifications.SubscriptionRequest> onSubscription,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "subscription":
                onSubscription(AsSubscription());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.Notifications.SubscriptionRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubscription(out KardApi.Notifications.SubscriptionRequest? value)
    {
        if (Type == "subscription")
        {
            value = (KardApi.Notifications.SubscriptionRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SubscriptionRequestUnion(
        SubscriptionRequestUnion.Subscription value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SubscriptionRequestUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SubscriptionRequestUnion).IsAssignableFrom(typeToConvert);

        public override SubscriptionRequestUnion Read(
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
                "subscription" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.Notifications.SubscriptionRequest?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.Notifications.SubscriptionRequest"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SubscriptionRequestUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubscriptionRequestUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "subscription" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override SubscriptionRequestUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SubscriptionRequestUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubscriptionRequestUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for subscription
    /// </summary>
    [Serializable]
    public struct Subscription
    {
        public Subscription(KardApi.Notifications.SubscriptionRequest value)
        {
            Value = value;
        }

        internal KardApi.Notifications.SubscriptionRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SubscriptionRequestUnion.Subscription(
            KardApi.Notifications.SubscriptionRequest value
        ) => new(value);
    }
}
