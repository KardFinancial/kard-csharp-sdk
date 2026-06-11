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
    /// Create an instance of PlacementFormatUnion with <see cref="PlacementFormatUnion.Placement"/>.
    /// </summary>
    public PlacementFormatUnion(PlacementFormatUnion.Placement value)
    {
        Type = "placement";
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
    /// Create an instance of PlacementFormatUnion with <see cref="PlacementFormatUnion.PlacementEmail"/>.
    /// </summary>
    public PlacementFormatUnion(PlacementFormatUnion.PlacementEmail value)
    {
        Type = "placementEmail";
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
    /// Create an instance of PlacementFormatUnion with <see cref="PlacementFormatUnion.PlacementGroup"/>.
    /// </summary>
    public PlacementFormatUnion(PlacementFormatUnion.PlacementGroup value)
    {
        Type = "placementGroup";
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
    /// Returns true if <see cref="Type"/> is "placementBatchActivation"
    /// </summary>
    public bool IsPlacementBatchActivation => Type == "placementBatchActivation";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "placementGroup"
    /// </summary>
    public bool IsPlacementGroup => Type == "placementGroup";

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.PlacementData"/> if <see cref="Type"/> is 'placement', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placement'.</exception>
    public KardFinancial.Organizations.PlacementData AsPlacement() =>
        IsPlacement
            ? (KardFinancial.Organizations.PlacementData)Value!
            : throw new global::System.Exception("PlacementFormatUnion.Type is not 'placement'");

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
    /// Returns the value as a <see cref="KardFinancial.Organizations.EmailPlacementData"/> if <see cref="Type"/> is 'placementEmail', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementEmail'.</exception>
    public KardFinancial.Organizations.EmailPlacementData AsPlacementEmail() =>
        IsPlacementEmail
            ? (KardFinancial.Organizations.EmailPlacementData)Value!
            : throw new global::System.Exception(
                "PlacementFormatUnion.Type is not 'placementEmail'"
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

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.GroupPlacementData"/> if <see cref="Type"/> is 'placementGroup', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementGroup'.</exception>
    public KardFinancial.Organizations.GroupPlacementData AsPlacementGroup() =>
        IsPlacementGroup
            ? (KardFinancial.Organizations.GroupPlacementData)Value!
            : throw new global::System.Exception(
                "PlacementFormatUnion.Type is not 'placementGroup'"
            );

    public T Match<T>(
        Func<KardFinancial.Organizations.PlacementData, T> onPlacement,
        Func<
            KardFinancial.Organizations.PushNotificationPlacementData,
            T
        > onPlacementPushNotification,
        Func<KardFinancial.Organizations.EmailPlacementData, T> onPlacementEmail,
        Func<
            KardFinancial.Organizations.BatchActivationPlacementData,
            T
        > onPlacementBatchActivation,
        Func<KardFinancial.Organizations.GroupPlacementData, T> onPlacementGroup,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "placement" => onPlacement(AsPlacement()),
            "placementPushNotification" => onPlacementPushNotification(
                AsPlacementPushNotification()
            ),
            "placementEmail" => onPlacementEmail(AsPlacementEmail()),
            "placementBatchActivation" => onPlacementBatchActivation(AsPlacementBatchActivation()),
            "placementGroup" => onPlacementGroup(AsPlacementGroup()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.Organizations.PlacementData> onPlacement,
        Action<KardFinancial.Organizations.PushNotificationPlacementData> onPlacementPushNotification,
        Action<KardFinancial.Organizations.EmailPlacementData> onPlacementEmail,
        Action<KardFinancial.Organizations.BatchActivationPlacementData> onPlacementBatchActivation,
        Action<KardFinancial.Organizations.GroupPlacementData> onPlacementGroup,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "placement":
                onPlacement(AsPlacement());
                break;
            case "placementPushNotification":
                onPlacementPushNotification(AsPlacementPushNotification());
                break;
            case "placementEmail":
                onPlacementEmail(AsPlacementEmail());
                break;
            case "placementBatchActivation":
                onPlacementBatchActivation(AsPlacementBatchActivation());
                break;
            case "placementGroup":
                onPlacementGroup(AsPlacementGroup());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
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

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.GroupPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementGroup(out KardFinancial.Organizations.GroupPlacementData? value)
    {
        if (Type == "placementGroup")
        {
            value = (KardFinancial.Organizations.GroupPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PlacementFormatUnion(PlacementFormatUnion.Placement value) =>
        new(value);

    public static implicit operator PlacementFormatUnion(
        PlacementFormatUnion.PlacementPushNotification value
    ) => new(value);

    public static implicit operator PlacementFormatUnion(
        PlacementFormatUnion.PlacementEmail value
    ) => new(value);

    public static implicit operator PlacementFormatUnion(
        PlacementFormatUnion.PlacementBatchActivation value
    ) => new(value);

    public static implicit operator PlacementFormatUnion(
        PlacementFormatUnion.PlacementGroup value
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
                "placementBatchActivation" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.BatchActivationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.BatchActivationPlacementData"
                        ),
                "placementGroup" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.GroupPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.GroupPlacementData"
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
                    "placement" => JsonSerializer.SerializeToNode(value.Value, options),
                    "placementPushNotification" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "placementEmail" => JsonSerializer.SerializeToNode(value.Value, options),
                    "placementBatchActivation" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "placementGroup" => JsonSerializer.SerializeToNode(value.Value, options),
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

        public static implicit operator PlacementFormatUnion.Placement(
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

        public static implicit operator PlacementFormatUnion.PlacementPushNotification(
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

        public static implicit operator PlacementFormatUnion.PlacementEmail(
            KardFinancial.Organizations.EmailPlacementData value
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

    /// <summary>
    /// Discriminated union type for placementGroup
    /// </summary>
    [Serializable]
    public struct PlacementGroup
    {
        public PlacementGroup(KardFinancial.Organizations.GroupPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.GroupPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlacementFormatUnion.PlacementGroup(
            KardFinancial.Organizations.GroupPlacementData value
        ) => new(value);
    }
}
