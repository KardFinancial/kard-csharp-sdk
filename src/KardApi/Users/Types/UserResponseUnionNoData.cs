// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(UserResponseUnionNoData.JsonConverter))]
[Serializable]
public record UserResponseUnionNoData
{
    internal UserResponseUnionNoData(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UserResponseUnionNoData with <see cref="UserResponseUnionNoData.User"/>.
    /// </summary>
    public UserResponseUnionNoData(UserResponseUnionNoData.User value)
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
    /// Returns the value as a <see cref="KardApi.UserResponseNoData"/> if <see cref="Type"/> is 'user', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user'.</exception>
    public KardApi.UserResponseNoData AsUser() =>
        IsUser
            ? (KardApi.UserResponseNoData)Value!
            : throw new global::System.Exception("UserResponseUnionNoData.Type is not 'user'");

    public T Match<T>(
        Func<KardApi.UserResponseNoData, T> onUser,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "user" => onUser(AsUser()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(Action<KardApi.UserResponseNoData> onUser, Action<string, object?> onUnknown_)
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
    /// Attempts to cast the value to a <see cref="KardApi.UserResponseNoData"/> and returns true if successful.
    /// </summary>
    public bool TryAsUser(out KardApi.UserResponseNoData? value)
    {
        if (Type == "user")
        {
            value = (KardApi.UserResponseNoData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UserResponseUnionNoData(UserResponseUnionNoData.User value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UserResponseUnionNoData>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UserResponseUnionNoData).IsAssignableFrom(typeToConvert);

        public override UserResponseUnionNoData Read(
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
                "user" => jsonWithoutDiscriminator.Deserialize<KardApi.UserResponseNoData?>(options)
                    ?? throw new JsonException("Failed to deserialize KardApi.UserResponseNoData"),
                _ => json.Deserialize<object?>(options),
            };
            return new UserResponseUnionNoData(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserResponseUnionNoData value,
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

        public override UserResponseUnionNoData ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UserResponseUnionNoData(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserResponseUnionNoData value,
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
        public User(KardApi.UserResponseNoData value)
        {
            Value = value;
        }

        internal KardApi.UserResponseNoData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UserResponseUnionNoData.User(
            KardApi.UserResponseNoData value
        ) => new(value);
    }
}
