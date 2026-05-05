// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Organizations;

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
    /// Create an instance of CreatePlacementDataUnion with <see cref="CreatePlacementDataUnion.PlacementMainPage"/>.
    /// </summary>
    public CreatePlacementDataUnion(CreatePlacementDataUnion.PlacementMainPage value)
    {
        Type = "placementMainPage";
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
    /// Returns the value as a <see cref="Kard.Organizations.CreateMainPagePlacementData"/> if <see cref="Type"/> is 'placementMainPage', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementMainPage'.</exception>
    public Kard.Organizations.CreateMainPagePlacementData AsPlacementMainPage() =>
        IsPlacementMainPage
            ? (Kard.Organizations.CreateMainPagePlacementData)Value!
            : throw new global::System.Exception(
                "CreatePlacementDataUnion.Type is not 'placementMainPage'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Kard.Organizations.CreatePushNotificationPlacementData"/> if <see cref="Type"/> is 'placementPushNotification', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementPushNotification'.</exception>
    public Kard.Organizations.CreatePushNotificationPlacementData AsPlacementPushNotification() =>
        IsPlacementPushNotification
            ? (Kard.Organizations.CreatePushNotificationPlacementData)Value!
            : throw new global::System.Exception(
                "CreatePlacementDataUnion.Type is not 'placementPushNotification'"
            );

    public T Match<T>(
        Func<Kard.Organizations.CreateMainPagePlacementData, T> onPlacementMainPage,
        Func<Kard.Organizations.CreatePushNotificationPlacementData, T> onPlacementPushNotification,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "placementMainPage" => onPlacementMainPage(AsPlacementMainPage()),
            "placementPushNotification" => onPlacementPushNotification(
                AsPlacementPushNotification()
            ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Kard.Organizations.CreateMainPagePlacementData> onPlacementMainPage,
        Action<Kard.Organizations.CreatePushNotificationPlacementData> onPlacementPushNotification,
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
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.Organizations.CreateMainPagePlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementMainPage(out Kard.Organizations.CreateMainPagePlacementData? value)
    {
        if (Type == "placementMainPage")
        {
            value = (Kard.Organizations.CreateMainPagePlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.Organizations.CreatePushNotificationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementPushNotification(
        out Kard.Organizations.CreatePushNotificationPlacementData? value
    )
    {
        if (Type == "placementPushNotification")
        {
            value = (Kard.Organizations.CreatePushNotificationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreatePlacementDataUnion(
        CreatePlacementDataUnion.PlacementMainPage value
    ) => new(value);

    public static implicit operator CreatePlacementDataUnion(
        CreatePlacementDataUnion.PlacementPushNotification value
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
                "placementMainPage" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.Organizations.CreateMainPagePlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.Organizations.CreateMainPagePlacementData"
                        ),
                "placementPushNotification" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.Organizations.CreatePushNotificationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.Organizations.CreatePushNotificationPlacementData"
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
    /// Discriminated union type for placementMainPage
    /// </summary>
    [Serializable]
    public struct PlacementMainPage
    {
        public PlacementMainPage(Kard.Organizations.CreateMainPagePlacementData value)
        {
            Value = value;
        }

        internal Kard.Organizations.CreateMainPagePlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreatePlacementDataUnion.PlacementMainPage(
            Kard.Organizations.CreateMainPagePlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementPushNotification
    /// </summary>
    [Serializable]
    public struct PlacementPushNotification
    {
        public PlacementPushNotification(
            Kard.Organizations.CreatePushNotificationPlacementData value
        )
        {
            Value = value;
        }

        internal Kard.Organizations.CreatePushNotificationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreatePlacementDataUnion.PlacementPushNotification(
            Kard.Organizations.CreatePushNotificationPlacementData value
        ) => new(value);
    }
}
