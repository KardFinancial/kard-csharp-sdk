// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Notifications;

[JsonConverter(typeof(SubscriptionUnion.JsonConverter))]
[Serializable]
public record SubscriptionUnion
{
    internal SubscriptionUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SubscriptionUnion with <see cref="SubscriptionUnion.Subscription"/>.
    /// </summary>
    public SubscriptionUnion(SubscriptionUnion.Subscription value)
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
    /// Returns the value as a <see cref="KardFinancial.Notifications.Subscription"/> if <see cref="Type"/> is 'subscription', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'subscription'.</exception>
    public KardFinancial.Notifications.Subscription AsSubscription() =>
        IsSubscription
            ? (KardFinancial.Notifications.Subscription)Value!
            : throw new global::System.Exception("SubscriptionUnion.Type is not 'subscription'");

    public T Match<T>(
        Func<KardFinancial.Notifications.Subscription, T> onSubscription,
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
        Action<KardFinancial.Notifications.Subscription> onSubscription,
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
    /// Attempts to cast the value to a <see cref="KardFinancial.Notifications.Subscription"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubscription(out KardFinancial.Notifications.Subscription? value)
    {
        if (Type == "subscription")
        {
            value = (KardFinancial.Notifications.Subscription)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SubscriptionUnion(SubscriptionUnion.Subscription value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SubscriptionUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SubscriptionUnion).IsAssignableFrom(typeToConvert);

        public override SubscriptionUnion Read(
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
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Notifications.Subscription?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Notifications.Subscription"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SubscriptionUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubscriptionUnion value,
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

        public override SubscriptionUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SubscriptionUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubscriptionUnion value,
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
        public Subscription(KardFinancial.Notifications.Subscription value)
        {
            Value = value;
        }

        internal KardFinancial.Notifications.Subscription Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SubscriptionUnion.Subscription(
            KardFinancial.Notifications.Subscription value
        ) => new(value);
    }
}
