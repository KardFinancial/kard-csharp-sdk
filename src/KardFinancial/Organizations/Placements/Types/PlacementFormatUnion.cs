// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Discriminated union for placement resources keyed on type
/// </summary>
[JsonConverter(typeof(PlacementFormatUnion.JsonConverter))]
[Serializable]
public record PlacementFormatUnion
{
    internal PlacementFormatUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PlacementFormatUnion with <see cref="PlacementFormatUnion.PlacementMainPage"/>.
    /// </summary>
    public PlacementFormatUnion(PlacementFormatUnion.PlacementMainPage value)
    {
        Type = "placementMainPage";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlacementFormatUnion with <see cref="PlacementFormatUnion.PlacementPushNotification"/>.
    /// </summary>
    public PlacementFormatUnion(PlacementFormatUnion.PlacementPushNotification value)
    {
        Type = "placementPushNotification";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlacementFormatUnion with <see cref="PlacementFormatUnion.PlacementBatchActivation"/>.
    /// </summary>
    public PlacementFormatUnion(PlacementFormatUnion.PlacementBatchActivation value)
    {
        Type = "placementBatchActivation";
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
    /// Returns true if <see cref="Type"/> is "placementMainPage"
    /// </summary>
    public bool IsPlacementMainPage => Type == "placementMainPage";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "placementPushNotification"
    /// </summary>
    public bool IsPlacementPushNotification => Type == "placementPushNotification";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "placementBatchActivation"
    /// </summary>
    public bool IsPlacementBatchActivation => Type == "placementBatchActivation";

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.MainPagePlacementData"/> if <see cref="Type"/> is 'placementMainPage', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementMainPage'.</exception>
    public KardFinancial.Organizations.MainPagePlacementData AsPlacementMainPage() =>
        IsPlacementMainPage
            ? (KardFinancial.Organizations.MainPagePlacementData)Value!
            : throw new global::System.Exception(
                "PlacementFormatUnion.Type is not 'placementMainPage'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.PushNotificationPlacementData"/> if <see cref="Type"/> is 'placementPushNotification', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementPushNotification'.</exception>
    public KardFinancial.Organizations.PushNotificationPlacementData AsPlacementPushNotification() =>
        IsPlacementPushNotification
            ? (KardFinancial.Organizations.PushNotificationPlacementData)Value!
            : throw new global::System.Exception(
                "PlacementFormatUnion.Type is not 'placementPushNotification'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.BatchActivationPlacementData"/> if <see cref="Type"/> is 'placementBatchActivation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementBatchActivation'.</exception>
    public KardFinancial.Organizations.BatchActivationPlacementData AsPlacementBatchActivation() =>
        IsPlacementBatchActivation
            ? (KardFinancial.Organizations.BatchActivationPlacementData)Value!
            : throw new global::System.Exception(
                "PlacementFormatUnion.Type is not 'placementBatchActivation'"
            );

    public T Match<T>(
        Func<KardFinancial.Organizations.MainPagePlacementData, T> onPlacementMainPage,
        Func<
            KardFinancial.Organizations.PushNotificationPlacementData,
            T
        > onPlacementPushNotification,
        Func<
            KardFinancial.Organizations.BatchActivationPlacementData,
            T
        > onPlacementBatchActivation,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "placementMainPage" => onPlacementMainPage(AsPlacementMainPage()),
            "placementPushNotification" => onPlacementPushNotification(
                AsPlacementPushNotification()
            ),
            "placementBatchActivation" => onPlacementBatchActivation(AsPlacementBatchActivation()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.Organizations.MainPagePlacementData> onPlacementMainPage,
        Action<KardFinancial.Organizations.PushNotificationPlacementData> onPlacementPushNotification,
        Action<KardFinancial.Organizations.BatchActivationPlacementData> onPlacementBatchActivation,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "placementMainPage":
                onPlacementMainPage(AsPlacementMainPage());
                break;
            case "placementPushNotification":
                onPlacementPushNotification(AsPlacementPushNotification());
                break;
            case "placementBatchActivation":
                onPlacementBatchActivation(AsPlacementBatchActivation());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
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

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.BatchActivationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementBatchActivation(
        out KardFinancial.Organizations.BatchActivationPlacementData? value
    )
    {
        if (Type == "placementBatchActivation")
        {
            value = (KardFinancial.Organizations.BatchActivationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PlacementFormatUnion(
        PlacementFormatUnion.PlacementMainPage value
    ) => new(value);

    public static implicit operator PlacementFormatUnion(
        PlacementFormatUnion.PlacementPushNotification value
    ) => new(value);

    public static implicit operator PlacementFormatUnion(
        PlacementFormatUnion.PlacementBatchActivation value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PlacementFormatUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PlacementFormatUnion).IsAssignableFrom(typeToConvert);

        public override PlacementFormatUnion Read(
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
                "placementBatchActivation" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.BatchActivationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.BatchActivationPlacementData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PlacementFormatUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlacementFormatUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "placementMainPage" => JsonSerializer.SerializeToNode(value.Value, options),
                    "placementPushNotification" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "placementBatchActivation" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override PlacementFormatUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PlacementFormatUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlacementFormatUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
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

        public static implicit operator PlacementFormatUnion.PlacementMainPage(
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

        public static implicit operator PlacementFormatUnion.PlacementPushNotification(
            KardFinancial.Organizations.PushNotificationPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementBatchActivation
    /// </summary>
    [Serializable]
    public struct PlacementBatchActivation
    {
        public PlacementBatchActivation(
            KardFinancial.Organizations.BatchActivationPlacementData value
        )
        {
            Value = value;
        }

        internal KardFinancial.Organizations.BatchActivationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlacementFormatUnion.PlacementBatchActivation(
            KardFinancial.Organizations.BatchActivationPlacementData value
        ) => new(value);
    }
}
