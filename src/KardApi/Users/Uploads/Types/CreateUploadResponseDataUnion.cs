// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(CreateUploadResponseDataUnion.JsonConverter))]
[Serializable]
public record CreateUploadResponseDataUnion
{
    internal CreateUploadResponseDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateUploadResponseDataUnion with <see cref="CreateUploadResponseDataUnion.HistoricalTransactionStart"/>.
    /// </summary>
    public CreateUploadResponseDataUnion(
        CreateUploadResponseDataUnion.HistoricalTransactionStart value
    )
    {
        Type = "historicalTransactionStart";
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
    /// Returns true if <see cref="Type"/> is "historicalTransactionStart"
    /// </summary>
    public bool IsHistoricalTransactionStart => Type == "historicalTransactionStart";

    /// <summary>
    /// Returns the value as a <see cref="KardApi.Users.CreateUploadResponseData"/> if <see cref="Type"/> is 'historicalTransactionStart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'historicalTransactionStart'.</exception>
    public KardApi.Users.CreateUploadResponseData AsHistoricalTransactionStart() =>
        IsHistoricalTransactionStart
            ? (KardApi.Users.CreateUploadResponseData)Value!
            : throw new global::System.Exception(
                "CreateUploadResponseDataUnion.Type is not 'historicalTransactionStart'"
            );

    public T Match<T>(
        Func<KardApi.Users.CreateUploadResponseData, T> onHistoricalTransactionStart,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "historicalTransactionStart" => onHistoricalTransactionStart(
                AsHistoricalTransactionStart()
            ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardApi.Users.CreateUploadResponseData> onHistoricalTransactionStart,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "historicalTransactionStart":
                onHistoricalTransactionStart(AsHistoricalTransactionStart());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.Users.CreateUploadResponseData"/> and returns true if successful.
    /// </summary>
    public bool TryAsHistoricalTransactionStart(out KardApi.Users.CreateUploadResponseData? value)
    {
        if (Type == "historicalTransactionStart")
        {
            value = (KardApi.Users.CreateUploadResponseData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateUploadResponseDataUnion(
        CreateUploadResponseDataUnion.HistoricalTransactionStart value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateUploadResponseDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateUploadResponseDataUnion).IsAssignableFrom(typeToConvert);

        public override CreateUploadResponseDataUnion Read(
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
                "historicalTransactionStart" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.Users.CreateUploadResponseData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.Users.CreateUploadResponseData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateUploadResponseDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateUploadResponseDataUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "historicalTransactionStart" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override CreateUploadResponseDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateUploadResponseDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateUploadResponseDataUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for historicalTransactionStart
    /// </summary>
    [Serializable]
    public struct HistoricalTransactionStart
    {
        public HistoricalTransactionStart(KardApi.Users.CreateUploadResponseData value)
        {
            Value = value;
        }

        internal KardApi.Users.CreateUploadResponseData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateUploadResponseDataUnion.HistoricalTransactionStart(
            KardApi.Users.CreateUploadResponseData value
        ) => new(value);
    }
}
