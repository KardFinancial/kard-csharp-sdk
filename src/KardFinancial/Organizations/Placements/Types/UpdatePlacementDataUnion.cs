// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Discriminated union for updating a placement
/// </summary>
[JsonConverter(typeof(UpdatePlacementDataUnion.JsonConverter))]
[Serializable]
public record UpdatePlacementDataUnion
{
    internal UpdatePlacementDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UpdatePlacementDataUnion with <see cref="UpdatePlacementDataUnion.Placement"/>.
    /// </summary>
    public UpdatePlacementDataUnion(UpdatePlacementDataUnion.Placement value)
    {
        Type = "placement";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of UpdatePlacementDataUnion with <see cref="UpdatePlacementDataUnion.PlacementPushNotification"/>.
    /// </summary>
    public UpdatePlacementDataUnion(UpdatePlacementDataUnion.PlacementPushNotification value)
    {
        Type = "placementPushNotification";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of UpdatePlacementDataUnion with <see cref="UpdatePlacementDataUnion.PlacementEmail"/>.
    /// </summary>
    public UpdatePlacementDataUnion(UpdatePlacementDataUnion.PlacementEmail value)
    {
        Type = "placementEmail";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of UpdatePlacementDataUnion with <see cref="UpdatePlacementDataUnion.PlacementBatchActivation"/>.
    /// </summary>
    public UpdatePlacementDataUnion(UpdatePlacementDataUnion.PlacementBatchActivation value)
    {
        Type = "placementBatchActivation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of UpdatePlacementDataUnion with <see cref="UpdatePlacementDataUnion.PlacementGroup"/>.
    /// </summary>
    public UpdatePlacementDataUnion(UpdatePlacementDataUnion.PlacementGroup value)
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
    /// Returns the value as a <see cref="KardFinancial.Organizations.UpdateStandardPlacementData"/> if <see cref="Type"/> is 'placement', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placement'.</exception>
    public KardFinancial.Organizations.UpdateStandardPlacementData AsPlacement() =>
        IsPlacement
            ? (KardFinancial.Organizations.UpdateStandardPlacementData)Value!
            : throw new global::System.Exception(
                "UpdatePlacementDataUnion.Type is not 'placement'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.UpdatePushNotificationPlacementData"/> if <see cref="Type"/> is 'placementPushNotification', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementPushNotification'.</exception>
    public KardFinancial.Organizations.UpdatePushNotificationPlacementData AsPlacementPushNotification() =>
        IsPlacementPushNotification
            ? (KardFinancial.Organizations.UpdatePushNotificationPlacementData)Value!
            : throw new global::System.Exception(
                "UpdatePlacementDataUnion.Type is not 'placementPushNotification'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.UpdateEmailPlacementData"/> if <see cref="Type"/> is 'placementEmail', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementEmail'.</exception>
    public KardFinancial.Organizations.UpdateEmailPlacementData AsPlacementEmail() =>
        IsPlacementEmail
            ? (KardFinancial.Organizations.UpdateEmailPlacementData)Value!
            : throw new global::System.Exception(
                "UpdatePlacementDataUnion.Type is not 'placementEmail'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.UpdateBatchActivationPlacementData"/> if <see cref="Type"/> is 'placementBatchActivation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementBatchActivation'.</exception>
    public KardFinancial.Organizations.UpdateBatchActivationPlacementData AsPlacementBatchActivation() =>
        IsPlacementBatchActivation
            ? (KardFinancial.Organizations.UpdateBatchActivationPlacementData)Value!
            : throw new global::System.Exception(
                "UpdatePlacementDataUnion.Type is not 'placementBatchActivation'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.UpdateGroupPlacementData"/> if <see cref="Type"/> is 'placementGroup', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementGroup'.</exception>
    public KardFinancial.Organizations.UpdateGroupPlacementData AsPlacementGroup() =>
        IsPlacementGroup
            ? (KardFinancial.Organizations.UpdateGroupPlacementData)Value!
            : throw new global::System.Exception(
                "UpdatePlacementDataUnion.Type is not 'placementGroup'"
            );

    public T Match<T>(
        Func<KardFinancial.Organizations.UpdateStandardPlacementData, T> onPlacement,
        Func<
            KardFinancial.Organizations.UpdatePushNotificationPlacementData,
            T
        > onPlacementPushNotification,
        Func<KardFinancial.Organizations.UpdateEmailPlacementData, T> onPlacementEmail,
        Func<
            KardFinancial.Organizations.UpdateBatchActivationPlacementData,
            T
        > onPlacementBatchActivation,
        Func<KardFinancial.Organizations.UpdateGroupPlacementData, T> onPlacementGroup,
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
        Action<KardFinancial.Organizations.UpdateStandardPlacementData> onPlacement,
        Action<KardFinancial.Organizations.UpdatePushNotificationPlacementData> onPlacementPushNotification,
        Action<KardFinancial.Organizations.UpdateEmailPlacementData> onPlacementEmail,
        Action<KardFinancial.Organizations.UpdateBatchActivationPlacementData> onPlacementBatchActivation,
        Action<KardFinancial.Organizations.UpdateGroupPlacementData> onPlacementGroup,
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
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.UpdateStandardPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacement(out KardFinancial.Organizations.UpdateStandardPlacementData? value)
    {
        if (Type == "placement")
        {
            value = (KardFinancial.Organizations.UpdateStandardPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.UpdatePushNotificationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementPushNotification(
        out KardFinancial.Organizations.UpdatePushNotificationPlacementData? value
    )
    {
        if (Type == "placementPushNotification")
        {
            value = (KardFinancial.Organizations.UpdatePushNotificationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.UpdateEmailPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementEmail(out KardFinancial.Organizations.UpdateEmailPlacementData? value)
    {
        if (Type == "placementEmail")
        {
            value = (KardFinancial.Organizations.UpdateEmailPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.UpdateBatchActivationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementBatchActivation(
        out KardFinancial.Organizations.UpdateBatchActivationPlacementData? value
    )
    {
        if (Type == "placementBatchActivation")
        {
            value = (KardFinancial.Organizations.UpdateBatchActivationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.UpdateGroupPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementGroup(out KardFinancial.Organizations.UpdateGroupPlacementData? value)
    {
        if (Type == "placementGroup")
        {
            value = (KardFinancial.Organizations.UpdateGroupPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UpdatePlacementDataUnion(
        UpdatePlacementDataUnion.Placement value
    ) => new(value);

    public static implicit operator UpdatePlacementDataUnion(
        UpdatePlacementDataUnion.PlacementPushNotification value
    ) => new(value);

    public static implicit operator UpdatePlacementDataUnion(
        UpdatePlacementDataUnion.PlacementEmail value
    ) => new(value);

    public static implicit operator UpdatePlacementDataUnion(
        UpdatePlacementDataUnion.PlacementBatchActivation value
    ) => new(value);

    public static implicit operator UpdatePlacementDataUnion(
        UpdatePlacementDataUnion.PlacementGroup value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UpdatePlacementDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UpdatePlacementDataUnion).IsAssignableFrom(typeToConvert);

        public override UpdatePlacementDataUnion Read(
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
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.UpdateStandardPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.UpdateStandardPlacementData"
                        ),
                "placementPushNotification" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.UpdatePushNotificationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.UpdatePushNotificationPlacementData"
                        ),
                "placementEmail" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.UpdateEmailPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.UpdateEmailPlacementData"
                        ),
                "placementBatchActivation" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.UpdateBatchActivationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.UpdateBatchActivationPlacementData"
                        ),
                "placementGroup" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.UpdateGroupPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.UpdateGroupPlacementData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new UpdatePlacementDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePlacementDataUnion value,
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

        public override UpdatePlacementDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UpdatePlacementDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePlacementDataUnion value,
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
        public Placement(KardFinancial.Organizations.UpdateStandardPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.UpdateStandardPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdatePlacementDataUnion.Placement(
            KardFinancial.Organizations.UpdateStandardPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementPushNotification
    /// </summary>
    [Serializable]
    public struct PlacementPushNotification
    {
        public PlacementPushNotification(
            KardFinancial.Organizations.UpdatePushNotificationPlacementData value
        )
        {
            Value = value;
        }

        internal KardFinancial.Organizations.UpdatePushNotificationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdatePlacementDataUnion.PlacementPushNotification(
            KardFinancial.Organizations.UpdatePushNotificationPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementEmail
    /// </summary>
    [Serializable]
    public struct PlacementEmail
    {
        public PlacementEmail(KardFinancial.Organizations.UpdateEmailPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.UpdateEmailPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdatePlacementDataUnion.PlacementEmail(
            KardFinancial.Organizations.UpdateEmailPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementBatchActivation
    /// </summary>
    [Serializable]
    public struct PlacementBatchActivation
    {
        public PlacementBatchActivation(
            KardFinancial.Organizations.UpdateBatchActivationPlacementData value
        )
        {
            Value = value;
        }

        internal KardFinancial.Organizations.UpdateBatchActivationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdatePlacementDataUnion.PlacementBatchActivation(
            KardFinancial.Organizations.UpdateBatchActivationPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementGroup
    /// </summary>
    [Serializable]
    public struct PlacementGroup
    {
        public PlacementGroup(KardFinancial.Organizations.UpdateGroupPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.UpdateGroupPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdatePlacementDataUnion.PlacementGroup(
            KardFinancial.Organizations.UpdateGroupPlacementData value
        ) => new(value);
    }
}
