// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Organizations;

/// <summary>
/// Discriminated union for creating a placement
/// </summary>
[JsonConverter(typeof(CreatePlacementDataUnion.JsonConverter))]
[Serializable]
public record CreatePlacementDataUnion
{
    internal CreatePlacementDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreatePlacementDataUnion with <see cref="CreatePlacementDataUnion.Placement"/>.
    /// </summary>
    public CreatePlacementDataUnion(CreatePlacementDataUnion.Placement value)
    {
        Type = "placement";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreatePlacementDataUnion with <see cref="CreatePlacementDataUnion.PlacementPushNotification"/>.
    /// </summary>
    public CreatePlacementDataUnion(CreatePlacementDataUnion.PlacementPushNotification value)
    {
        Type = "placementPushNotification";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreatePlacementDataUnion with <see cref="CreatePlacementDataUnion.PlacementEmail"/>.
    /// </summary>
    public CreatePlacementDataUnion(CreatePlacementDataUnion.PlacementEmail value)
    {
        Type = "placementEmail";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreatePlacementDataUnion with <see cref="CreatePlacementDataUnion.PlacementBatchActivation"/>.
    /// </summary>
    public CreatePlacementDataUnion(CreatePlacementDataUnion.PlacementBatchActivation value)
    {
        Type = "placementBatchActivation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CreatePlacementDataUnion with <see cref="CreatePlacementDataUnion.PlacementGroup"/>.
    /// </summary>
    public CreatePlacementDataUnion(CreatePlacementDataUnion.PlacementGroup value)
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
    /// Returns the value as a <see cref="KardFinancial.Organizations.CreateStandardPlacementData"/> if <see cref="Type"/> is 'placement', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placement'.</exception>
    public KardFinancial.Organizations.CreateStandardPlacementData AsPlacement() =>
        IsPlacement
            ? (KardFinancial.Organizations.CreateStandardPlacementData)Value!
            : throw new global::System.Exception(
                "CreatePlacementDataUnion.Type is not 'placement'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.CreatePushNotificationPlacementData"/> if <see cref="Type"/> is 'placementPushNotification', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementPushNotification'.</exception>
    public KardFinancial.Organizations.CreatePushNotificationPlacementData AsPlacementPushNotification() =>
        IsPlacementPushNotification
            ? (KardFinancial.Organizations.CreatePushNotificationPlacementData)Value!
            : throw new global::System.Exception(
                "CreatePlacementDataUnion.Type is not 'placementPushNotification'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.CreateEmailPlacementData"/> if <see cref="Type"/> is 'placementEmail', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementEmail'.</exception>
    public KardFinancial.Organizations.CreateEmailPlacementData AsPlacementEmail() =>
        IsPlacementEmail
            ? (KardFinancial.Organizations.CreateEmailPlacementData)Value!
            : throw new global::System.Exception(
                "CreatePlacementDataUnion.Type is not 'placementEmail'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.CreateBatchActivationPlacementData"/> if <see cref="Type"/> is 'placementBatchActivation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementBatchActivation'.</exception>
    public KardFinancial.Organizations.CreateBatchActivationPlacementData AsPlacementBatchActivation() =>
        IsPlacementBatchActivation
            ? (KardFinancial.Organizations.CreateBatchActivationPlacementData)Value!
            : throw new global::System.Exception(
                "CreatePlacementDataUnion.Type is not 'placementBatchActivation'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.Organizations.CreateGroupPlacementData"/> if <see cref="Type"/> is 'placementGroup', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementGroup'.</exception>
    public KardFinancial.Organizations.CreateGroupPlacementData AsPlacementGroup() =>
        IsPlacementGroup
            ? (KardFinancial.Organizations.CreateGroupPlacementData)Value!
            : throw new global::System.Exception(
                "CreatePlacementDataUnion.Type is not 'placementGroup'"
            );

    public T Match<T>(
        Func<KardFinancial.Organizations.CreateStandardPlacementData, T> onPlacement,
        Func<
            KardFinancial.Organizations.CreatePushNotificationPlacementData,
            T
        > onPlacementPushNotification,
        Func<KardFinancial.Organizations.CreateEmailPlacementData, T> onPlacementEmail,
        Func<
            KardFinancial.Organizations.CreateBatchActivationPlacementData,
            T
        > onPlacementBatchActivation,
        Func<KardFinancial.Organizations.CreateGroupPlacementData, T> onPlacementGroup,
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
        Action<KardFinancial.Organizations.CreateStandardPlacementData> onPlacement,
        Action<KardFinancial.Organizations.CreatePushNotificationPlacementData> onPlacementPushNotification,
        Action<KardFinancial.Organizations.CreateEmailPlacementData> onPlacementEmail,
        Action<KardFinancial.Organizations.CreateBatchActivationPlacementData> onPlacementBatchActivation,
        Action<KardFinancial.Organizations.CreateGroupPlacementData> onPlacementGroup,
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
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.CreateStandardPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacement(out KardFinancial.Organizations.CreateStandardPlacementData? value)
    {
        if (Type == "placement")
        {
            value = (KardFinancial.Organizations.CreateStandardPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.CreatePushNotificationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementPushNotification(
        out KardFinancial.Organizations.CreatePushNotificationPlacementData? value
    )
    {
        if (Type == "placementPushNotification")
        {
            value = (KardFinancial.Organizations.CreatePushNotificationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.CreateEmailPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementEmail(out KardFinancial.Organizations.CreateEmailPlacementData? value)
    {
        if (Type == "placementEmail")
        {
            value = (KardFinancial.Organizations.CreateEmailPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.CreateBatchActivationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementBatchActivation(
        out KardFinancial.Organizations.CreateBatchActivationPlacementData? value
    )
    {
        if (Type == "placementBatchActivation")
        {
            value = (KardFinancial.Organizations.CreateBatchActivationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.Organizations.CreateGroupPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementGroup(out KardFinancial.Organizations.CreateGroupPlacementData? value)
    {
        if (Type == "placementGroup")
        {
            value = (KardFinancial.Organizations.CreateGroupPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreatePlacementDataUnion(
        CreatePlacementDataUnion.Placement value
    ) => new(value);

    public static implicit operator CreatePlacementDataUnion(
        CreatePlacementDataUnion.PlacementPushNotification value
    ) => new(value);

    public static implicit operator CreatePlacementDataUnion(
        CreatePlacementDataUnion.PlacementEmail value
    ) => new(value);

    public static implicit operator CreatePlacementDataUnion(
        CreatePlacementDataUnion.PlacementBatchActivation value
    ) => new(value);

    public static implicit operator CreatePlacementDataUnion(
        CreatePlacementDataUnion.PlacementGroup value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreatePlacementDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreatePlacementDataUnion).IsAssignableFrom(typeToConvert);

        public override CreatePlacementDataUnion Read(
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
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.CreateStandardPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.CreateStandardPlacementData"
                        ),
                "placementPushNotification" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.CreatePushNotificationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.CreatePushNotificationPlacementData"
                        ),
                "placementEmail" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.CreateEmailPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.CreateEmailPlacementData"
                        ),
                "placementBatchActivation" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.CreateBatchActivationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.CreateBatchActivationPlacementData"
                        ),
                "placementGroup" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Organizations.CreateGroupPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Organizations.CreateGroupPlacementData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreatePlacementDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePlacementDataUnion value,
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

        public override CreatePlacementDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreatePlacementDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePlacementDataUnion value,
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
        public Placement(KardFinancial.Organizations.CreateStandardPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.CreateStandardPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreatePlacementDataUnion.Placement(
            KardFinancial.Organizations.CreateStandardPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementPushNotification
    /// </summary>
    [Serializable]
    public struct PlacementPushNotification
    {
        public PlacementPushNotification(
            KardFinancial.Organizations.CreatePushNotificationPlacementData value
        )
        {
            Value = value;
        }

        internal KardFinancial.Organizations.CreatePushNotificationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreatePlacementDataUnion.PlacementPushNotification(
            KardFinancial.Organizations.CreatePushNotificationPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementEmail
    /// </summary>
    [Serializable]
    public struct PlacementEmail
    {
        public PlacementEmail(KardFinancial.Organizations.CreateEmailPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.CreateEmailPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreatePlacementDataUnion.PlacementEmail(
            KardFinancial.Organizations.CreateEmailPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementBatchActivation
    /// </summary>
    [Serializable]
    public struct PlacementBatchActivation
    {
        public PlacementBatchActivation(
            KardFinancial.Organizations.CreateBatchActivationPlacementData value
        )
        {
            Value = value;
        }

        internal KardFinancial.Organizations.CreateBatchActivationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreatePlacementDataUnion.PlacementBatchActivation(
            KardFinancial.Organizations.CreateBatchActivationPlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementGroup
    /// </summary>
    [Serializable]
    public struct PlacementGroup
    {
        public PlacementGroup(KardFinancial.Organizations.CreateGroupPlacementData value)
        {
            Value = value;
        }

        internal KardFinancial.Organizations.CreateGroupPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreatePlacementDataUnion.PlacementGroup(
            KardFinancial.Organizations.CreateGroupPlacementData value
        ) => new(value);
    }
}
