// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Organizations;

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
    /// Create an instance of UpdatePlacementDataUnion with <see cref="UpdatePlacementDataUnion.PlacementMainPage"/>.
    /// </summary>
    public UpdatePlacementDataUnion(UpdatePlacementDataUnion.PlacementMainPage value)
    {
        Type = "placementMainPage";
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
    /// Returns the value as a <see cref="Kard.Organizations.UpdateMainPagePlacementData"/> if <see cref="Type"/> is 'placementMainPage', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementMainPage'.</exception>
    public Kard.Organizations.UpdateMainPagePlacementData AsPlacementMainPage() =>
        IsPlacementMainPage
            ? (Kard.Organizations.UpdateMainPagePlacementData)Value!
            : throw new global::System.Exception(
                "UpdatePlacementDataUnion.Type is not 'placementMainPage'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Kard.Organizations.UpdatePushNotificationPlacementData"/> if <see cref="Type"/> is 'placementPushNotification', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'placementPushNotification'.</exception>
    public Kard.Organizations.UpdatePushNotificationPlacementData AsPlacementPushNotification() =>
        IsPlacementPushNotification
            ? (Kard.Organizations.UpdatePushNotificationPlacementData)Value!
            : throw new global::System.Exception(
                "UpdatePlacementDataUnion.Type is not 'placementPushNotification'"
            );

    public T Match<T>(
        Func<Kard.Organizations.UpdateMainPagePlacementData, T> onPlacementMainPage,
        Func<Kard.Organizations.UpdatePushNotificationPlacementData, T> onPlacementPushNotification,
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
        Action<Kard.Organizations.UpdateMainPagePlacementData> onPlacementMainPage,
        Action<Kard.Organizations.UpdatePushNotificationPlacementData> onPlacementPushNotification,
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
    /// Attempts to cast the value to a <see cref="Kard.Organizations.UpdateMainPagePlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementMainPage(out Kard.Organizations.UpdateMainPagePlacementData? value)
    {
        if (Type == "placementMainPage")
        {
            value = (Kard.Organizations.UpdateMainPagePlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.Organizations.UpdatePushNotificationPlacementData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlacementPushNotification(
        out Kard.Organizations.UpdatePushNotificationPlacementData? value
    )
    {
        if (Type == "placementPushNotification")
        {
            value = (Kard.Organizations.UpdatePushNotificationPlacementData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UpdatePlacementDataUnion(
        UpdatePlacementDataUnion.PlacementMainPage value
    ) => new(value);

    public static implicit operator UpdatePlacementDataUnion(
        UpdatePlacementDataUnion.PlacementPushNotification value
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
                "placementMainPage" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.Organizations.UpdateMainPagePlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.Organizations.UpdateMainPagePlacementData"
                        ),
                "placementPushNotification" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.Organizations.UpdatePushNotificationPlacementData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.Organizations.UpdatePushNotificationPlacementData"
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
    /// Discriminated union type for placementMainPage
    /// </summary>
    [Serializable]
    public struct PlacementMainPage
    {
        public PlacementMainPage(Kard.Organizations.UpdateMainPagePlacementData value)
        {
            Value = value;
        }

        internal Kard.Organizations.UpdateMainPagePlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdatePlacementDataUnion.PlacementMainPage(
            Kard.Organizations.UpdateMainPagePlacementData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for placementPushNotification
    /// </summary>
    [Serializable]
    public struct PlacementPushNotification
    {
        public PlacementPushNotification(
            Kard.Organizations.UpdatePushNotificationPlacementData value
        )
        {
            Value = value;
        }

        internal Kard.Organizations.UpdatePushNotificationPlacementData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdatePlacementDataUnion.PlacementPushNotification(
            Kard.Organizations.UpdatePushNotificationPlacementData value
        ) => new(value);
    }
}
