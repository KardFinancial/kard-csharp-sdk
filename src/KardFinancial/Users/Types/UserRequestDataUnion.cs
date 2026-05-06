// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(UserRequestDataUnion.JsonConverter))]
[Serializable]
public record UserRequestDataUnion
{
    internal UserRequestDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UserRequestDataUnion with <see cref="UserRequestDataUnion.User"/>.
    /// </summary>
    public UserRequestDataUnion(UserRequestDataUnion.User value)
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
    /// Returns the value as a <see cref="KardFinancial.UserRequestData"/> if <see cref="Type"/> is 'user', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user'.</exception>
    public KardFinancial.UserRequestData AsUser() =>
        IsUser
            ? (KardFinancial.UserRequestData)Value!
            : throw new global::System.Exception("UserRequestDataUnion.Type is not 'user'");

    public T Match<T>(
        Func<KardFinancial.UserRequestData, T> onUser,
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
        Action<KardFinancial.UserRequestData> onUser,
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
    /// Attempts to cast the value to a <see cref="KardFinancial.UserRequestData"/> and returns true if successful.
    /// </summary>
    public bool TryAsUser(out KardFinancial.UserRequestData? value)
    {
        if (Type == "user")
        {
            value = (KardFinancial.UserRequestData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UserRequestDataUnion(UserRequestDataUnion.User value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UserRequestDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UserRequestDataUnion).IsAssignableFrom(typeToConvert);

        public override UserRequestDataUnion Read(
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
                "user" => jsonWithoutDiscriminator.Deserialize<KardFinancial.UserRequestData?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize KardFinancial.UserRequestData"),
                _ => json.Deserialize<object?>(options),
            };
            return new UserRequestDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserRequestDataUnion value,
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

        public override UserRequestDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UserRequestDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserRequestDataUnion value,
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
        public User(KardFinancial.UserRequestData value)
        {
            Value = value;
        }

        internal KardFinancial.UserRequestData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UserRequestDataUnion.User(
            KardFinancial.UserRequestData value
        ) => new(value);
    }
}
