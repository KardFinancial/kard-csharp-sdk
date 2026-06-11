// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Discriminated union of every resource type that can appear in the `included` array. The shape of each branch matches the corresponding primary-data resource (same attributes and relationships), keyed on the JSON:API `type` discriminant.
/// </summary>
[JsonConverter(typeof(IncludedResource.JsonConverter))]
[Serializable]
public record IncludedResource
{
    internal IncludedResource(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of IncludedResource with <see cref="IncludedResource.ContentStrategy"/>.
    /// </summary>
    public IncludedResource(IncludedResource.ContentStrategy value)
    {
        Type = "contentStrategy";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of IncludedResource with <see cref="IncludedResource.BatchActivationSlot"/>.
    /// </summary>
    public IncludedResource(IncludedResource.BatchActivationSlot value)
    {
        Type = "batchActivationSlot";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of IncludedResource with <see cref="IncludedResource.Placement"/>.
    /// </summary>
    public IncludedResource(IncludedResource.Placement value)
    {
        Type = "placement";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of IncludedResource with <see cref="IncludedResource.PlacementPushNotification"/>.
    /// </summary>
    public IncludedResource(IncludedResource.PlacementPushNotification value)
    {
        Type = "placementPushNotification";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of IncludedResource with <see cref="IncludedResource.PlacementEmail"/>.
    /// </summary>
    public IncludedResource(IncludedResource.PlacementEmail value)
    {
        Type = "placementEmail";
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
    /// Returns true if <see cref="Type"/> is "contentStrategy"
    /// </summary>
    public bool IsContentStrategy => Type == "contentStrategy";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "batchActivationSlot"
    /// </summary>
    public bool IsBatchActivationSlot => Type == "batchActivationSlot";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "placement"
    /// </summary>
    public bool IsPlacement => Type == "placement";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "placementPushNotification"
    /// </summary>
    public bool IsPlacementPushNotification => Type == "placementPushNotification";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "placementEmail"
    /// </summary>
    public bool IsPlacementEmail => Type == "placementEmail";

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.ContentStrategyInclusion"/> if <see cref="Type"/> is 'contentStrategy', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'contentStrategy'.</exception>
    public KardFinancial.Organizations.ContentStrategyInclusion AsContentStrategy() =>
        IsContentStrategy
            ? (KardFinancial.Organizations.ContentStrategyInclusion)Value!
            : throw new global::System.Exception("IncludedResource.Type is not 'contentStrategy'");

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.BatchActivationSlotInclusion"/> if <see cref="Type"/> is 'batchActivationSlot', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'batchActivationSlot'.</exception>
    public KardFinancial.Organizations.BatchActivationSlotInclusion AsBatchActivationSlot() =>
        IsBatchActivationSlot
            ? (KardFinancial.Organizations.BatchActivationSlotInclusion)Value!
            : throw new global::System.Exception(
                "IncludedResource.Type is not 'batchActivationSlot'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.PlacementData"/> if <see cref="Type"/> is 'placement', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placement'.</exception>
    public KardFinancial.Organizations.PlacementData AsPlacement() =>
        IsPlacement
            ? (KardFinancial.Organizations.PlacementData)Value!
            : throw new global::System.Exception("IncludedResource.Type is not 'placement'");

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.PushNotificationPlacementData"/> if <see cref="Type"/> is 'placementPushNotification', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementPushNotification'.</exception>
    public KardFinancial.Organizations.PushNotificationPlacementData AsPlacementPushNotification() =>
        IsPlacementPushNotification
            ? (KardFinancial.Organizations.PushNotificationPlacementData)Value!
            : throw new global::System.Exception(
                "IncludedResource.Type is not 'placementPushNotification'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.EmailPlacementData"/> if <see cref="Type"/> is 'placementEmail', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementEmail'.</exception>
    public KardFinancial.Organizations.EmailPlacementData AsPlacementEmail() =>
        IsPlacementEmail
            ? (KardFinancial.Organizations.EmailPlacementData)Value!
            : throw new global::System.Exception("IncludedResource.Type is not 'placementEmail'");

    public T Match<T>(
        Func<KardFinancial.Organizations.ContentStrategyInclusion, T> onContentStrategy,
        Func<KardFinancial.Organizations.BatchActivationSlotInclusion, T> onBatchActivationSlot,
        Func<KardFinancial.Organizations.PlacementData, T> onPlacement,
        Func<
            KardFinancial.Organizations.PushNotificationPlacementData,
            T
        > onPlacementPushNotification,
        Func<KardFinancial.Organizations.EmailPlacementData, T> onPlacementEmail,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "contentStrategy" => onContentStrategy(AsContentStrategy()),
            "batchActivationSlot" => onBatchActivationSlot(AsBatchActivationSlot()),
            "placement" => onPlacement(AsPlacement()),
            "placementPushNotification" => onPlacementPushNotification(
                AsPlacementPushNotification()
            ),
            "placementEmail" => onPlacementEmail(AsPlacementEmail()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.Organizations.ContentStrategyInclusion> onContentStrategy,
        Action<KardFinancial.Organizations.BatchActivationSlotInclusion> onBatchActivationSlot,
        Action<KardFinancial.Organizations.PlacementData> onPlacement,
        Action<KardFinancial.Organizations.PushNotificationPlacementData> onPlacementPushNotification,
        Action<KardFinancial.Organizations.EmailPlacementData> onPlacementEmail,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "contentStrategy":
                onContentStrategy(AsContentStrategy());
                break;
            case "batchActivationSlot":
                onBatchActivationSlot(AsBatchActivationSlot());
                break;
            case "placement":
                onPlacement(AsPlacement());
                break;
            case "placementPushNotification":
                onPlacementPushNotification(AsPlacementPushNotification());
                break;
            case "placementEmail":
                onPlacementEmail(AsPlacementEmail());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.ContentStrategyInclusion"/> and returns true if successful.
    /// </summary>
    public bool TryAsContentStrategy(
        out KardFinancial.Organizations.ContentStrategyInclusion? value
    )
    {
        if (Type == "contentStrategy")
        {
            value = (KardFinancial.Organizations.ContentStrategyInclusion)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.BatchActivationSlotInclusion"/> and returns true if successful.
    /// </summary>
    public bool TryAsBatchActivationSlot(
        out KardFinancial.Organizations.BatchActivationSlotInclusion? value
    )
    {
        if (Type == "batchActivationSlot")
        {
            value = (KardFinancial.Organizations.BatchActivationSlotInclusion)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.PlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacement(out KardFinancial.Organizations.PlacementData? value)
    {
        if (Type == "placement")
        {
            value = (KardFinancial.Organizations.PlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.PushNotificationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementPushNotification(
        out KardFinancial.Organizations.PushNotificationPlacementData? value
    )
    {
        if (Type == "placementPushNotification")
        {
            value = (KardFinancial.Organizations.PushNotificationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.EmailPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementEmail(out KardFinancial.Organizations.EmailPlacementData? value)
    {
        if (Type == "placementEmail")
        {
            value = (KardFinancial.Organizations.EmailPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator IncludedResource(IncludedResource.ContentStrategy value) =>
        new(value);

    public static implicit operator IncludedResource(IncludedResource.BatchActivationSlot value) =>
        new(value);

    public static implicit operator IncludedResource(IncludedResource.Placement value) =>
        new(value);

    public static implicit operator IncludedResource(
        IncludedResource.PlacementPushNotification value
    ) => new(value);

    public static implicit operator IncludedResource(IncludedResource.PlacementEmail value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<IncludedResource>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(IncludedResource).IsAssignableFrom(typeToConvert);

        public override IncludedResource Read(
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
                "contentStrategy" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.ContentStrategyInclusion?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.ContentStrategyInclusion"
                        ),
                "batchActivationSlot" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.BatchActivationSlotInclusion?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.BatchActivationSlotInclusion"
                        ),
                "placement" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.PlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.PlacementData"
                        ),
                "placementPushNotification" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.PushNotificationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.PushNotificationPlacementData"
                        ),
                "placementEmail" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.EmailPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.EmailPlacementData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new IncludedResource(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IncludedResource value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "contentStrategy" => JsonSerializer.SerializeToNode(value.Value, options),
                    "batchActivationSlot" => JsonSerializer.SerializeToNode(value.Value, options),
                    "placement" => JsonSerializer.SerializeToNode(value.Value, options),
                    "placementPushNotification" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "placementEmail" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override IncludedResource ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new IncludedResource(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IncludedResource value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for contentStrategy
    /// </summary>
    [Serializable]
    public struct ContentStrategy
    {
        public ContentStrategy(KardFinancial.Organizations.ContentStrategyInclusion value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.ContentStrategyInclusion Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator IncludedResource.ContentStrategy(
            KardFinancial.Organizations.ContentStrategyInclusion value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for batchActivationSlot
    /// </summary>
    [Serializable]
    public struct BatchActivationSlot
    {
        public BatchActivationSlot(KardFinancial.Organizations.BatchActivationSlotInclusion value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.BatchActivationSlotInclusion Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator IncludedResource.BatchActivationSlot(
            KardFinancial.Organizations.BatchActivationSlotInclusion value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placement
    /// </summary>
    [Serializable]
    public struct Placement
    {
        public Placement(KardFinancial.Organizations.PlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.PlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator IncludedResource.Placement(
            KardFinancial.Organizations.PlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementPushNotification
    /// </summary>
    [Serializable]
    public struct PlacementPushNotification
    {
        public PlacementPushNotification(
            KardFinancial.Organizations.PushNotificationPlacementData value
        )
        {
            Value = value;
        }

        internal KardFinancial.Organizations.PushNotificationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator IncludedResource.PlacementPushNotification(
            KardFinancial.Organizations.PushNotificationPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementEmail
    /// </summary>
    [Serializable]
    public struct PlacementEmail
    {
        public PlacementEmail(KardFinancial.Organizations.EmailPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.EmailPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator IncludedResource.PlacementEmail(
            KardFinancial.Organizations.EmailPlacementData value
        ) => new(value);
    }
}
