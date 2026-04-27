// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(UpdateUserRequestDataUnion.JsonConverter))]
[Serializable]
public record UpdateUserRequestDataUnion
{
    internal UpdateUserRequestDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UpdateUserRequestDataUnion with <see cref="UpdateUserRequestDataUnion.User"/>.
    /// </summary>
    public UpdateUserRequestDataUnion(UpdateUserRequestDataUnion.User value)
    {
        Type = "user";
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
    /// Returns true if <see cref="Type"/> is "user"
    /// </summary>
    public bool IsUser => Type == "user";

    /// <summary>
    /// Returns the value as a <see cref="KardApi.UpdateUserRequestData"/> if <see cref="Type"/> is 'user', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user'.</exception>
    public KardApi.UpdateUserRequestData AsUser() =>
        IsUser
            ? (KardApi.UpdateUserRequestData)Value!
            : throw new global::System.Exception("UpdateUserRequestDataUnion.Type is not 'user'");

    public T Match<T>(
        Func<KardApi.UpdateUserRequestData, T> onUser,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "user" => onUser(AsUser()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardApi.UpdateUserRequestData> onUser,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "user":
                onUser(AsUser());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.UpdateUserRequestData"/> and returns true if successful.
    /// </summary>
    public bool TryAsUser(out KardApi.UpdateUserRequestData? value)
    {
        if (Type == "user")
        {
            value = (KardApi.UpdateUserRequestData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UpdateUserRequestDataUnion(
        UpdateUserRequestDataUnion.User value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UpdateUserRequestDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UpdateUserRequestDataUnion).IsAssignableFrom(typeToConvert);

        public override UpdateUserRequestDataUnion Read(
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
                "user" => jsonWithoutDiscriminator.Deserialize<KardApi.UpdateUserRequestData?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize KardApi.UpdateUserRequestData"),
                _ => json.Deserialize<object?>(options),
            };
            return new UpdateUserRequestDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateUserRequestDataUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "user" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override UpdateUserRequestDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UpdateUserRequestDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateUserRequestDataUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for user
    /// </summary>
    [Serializable]
    public struct User
    {
        public User(KardApi.UpdateUserRequestData value)
        {
            Value = value;
        }

        internal KardApi.UpdateUserRequestData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdateUserRequestDataUnion.User(
            KardApi.UpdateUserRequestData value
        ) => new(value);
    }
}
