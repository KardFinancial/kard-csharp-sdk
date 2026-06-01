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
    /// Create an instance of IncludedResource with <see cref="IncludedResource.PlacementMainPage"/>.
    /// </summary>
    public IncludedResource(IncludedResource.PlacementMainPage value)
    {
        Type = "placementMainPage";
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
    /// Returns true if <see cref="Type"/> is "placementMainPage"
    /// </summary>
    public bool IsPlacementMainPage => Type == "placementMainPage";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "placementPushNotification"
    /// </summary>
    public bool IsPlacementPushNotification => Type == "placementPushNotification";

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
    /// Returns the value as a <see cref="KardFinancial.Organizations.MainPagePlacementData"/> if <see cref="Type"/> is 'placementMainPage', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementMainPage'.</exception>
    public KardFinancial.Organizations.MainPagePlacementData AsPlacementMainPage() =>
        IsPlacementMainPage
            ? (KardFinancial.Organizations.MainPagePlacementData)Value!
            : throw new global::System.Exception(
                "IncludedResource.Type is not 'placementMainPage'"
            );

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

    public T Match<T>(
        Func<KardFinancial.Organizations.ContentStrategyInclusion, T> onContentStrategy,
        Func<KardFinancial.Organizations.BatchActivationSlotInclusion, T> onBatchActivationSlot,
        Func<KardFinancial.Organizations.MainPagePlacementData, T> onPlacementMainPage,
        Func<
            KardFinancial.Organizations.PushNotificationPlacementData,
            T
        > onPlacementPushNotification,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "contentStrategy" => onContentStrategy(AsContentStrategy()),
            "batchActivationSlot" => onBatchActivationSlot(AsBatchActivationSlot()),
            "placementMainPage" => onPlacementMainPage(AsPlacementMainPage()),
            "placementPushNotification" => onPlacementPushNotification(
                AsPlacementPushNotification()
            ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.Organizations.ContentStrategyInclusion> onContentStrategy,
        Action<KardFinancial.Organizations.BatchActivationSlotInclusion> onBatchActivationSlot,
        Action<KardFinancial.Organizations.MainPagePlacementData> onPlacementMainPage,
        Action<KardFinancial.Organizations.PushNotificationPlacementData> onPlacementPushNotification,
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
            case "placementMainPage":
                onPlacementMainPage(AsPlacementMainPage());
                break;
            case "placementPushNotification":
                onPlacementPushNotification(AsPlacementPushNotification());
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
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.MainPagePlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementMainPage(out KardFinancial.Organizations.MainPagePlacementData? value)
    {
        if (Type == "placementMainPage")
        {
            value = (KardFinancial.Organizations.MainPagePlacementData)Value!;
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

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator IncludedResource(IncludedResource.ContentStrategy value) =>
        new(value);

    public static implicit operator IncludedResource(IncludedResource.BatchActivationSlot value) =>
        new(value);

    public static implicit operator IncludedResource(IncludedResource.PlacementMainPage value) =>
        new(value);

    public static implicit operator IncludedResource(
        IncludedResource.PlacementPushNotification value
    ) => new(value);

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
                "placementMainPage" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.MainPagePlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.MainPagePlacementData"
                        ),
                "placementPushNotification" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.PushNotificationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.PushNotificationPlacementData"
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
                    "placementMainPage" => JsonSerializer.SerializeToNode(value.Value, options),
                    "placementPushNotification" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
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
    /// Discriminated union type for placementMainPage
    /// </summary>
    [Serializable]
    public struct PlacementMainPage
    {
        public PlacementMainPage(KardFinancial.Organizations.MainPagePlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.MainPagePlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator IncludedResource.PlacementMainPage(
            KardFinancial.Organizations.MainPagePlacementData value
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
}
