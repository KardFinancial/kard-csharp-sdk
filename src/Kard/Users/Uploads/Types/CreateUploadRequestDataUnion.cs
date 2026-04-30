// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Users;

[JsonConverter(typeof(CreateUploadRequestDataUnion.JsonConverter))]
[Serializable]
public record CreateUploadRequestDataUnion
{
    internal CreateUploadRequestDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateUploadRequestDataUnion with <see cref="CreateUploadRequestDataUnion.HistoricalTransactionStart"/>.
    /// </summary>
    public CreateUploadRequestDataUnion(
        CreateUploadRequestDataUnion.HistoricalTransactionStart value
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
    /// Returns the value as a <see cref="Kard.Users.StartHistoricalUploadNoData"/> if <see cref="Type"/> is 'historicalTransactionStart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'historicalTransactionStart'.</exception>
    public Kard.Users.StartHistoricalUploadNoData AsHistoricalTransactionStart() =>
        IsHistoricalTransactionStart
            ? (Kard.Users.StartHistoricalUploadNoData)Value!
            : throw new global::System.Exception(
                "CreateUploadRequestDataUnion.Type is not 'historicalTransactionStart'"
            );

    public T Match<T>(
        Func<Kard.Users.StartHistoricalUploadNoData, T> onHistoricalTransactionStart,
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
        Action<Kard.Users.StartHistoricalUploadNoData> onHistoricalTransactionStart,
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
    /// Attempts to cast the value to a <see cref="Kard.Users.StartHistoricalUploadNoData"/> and returns true if successful.
    /// </summary>
    public bool TryAsHistoricalTransactionStart(out Kard.Users.StartHistoricalUploadNoData? value)
    {
        if (Type == "historicalTransactionStart")
        {
            value = (Kard.Users.StartHistoricalUploadNoData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateUploadRequestDataUnion(
        CreateUploadRequestDataUnion.HistoricalTransactionStart value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateUploadRequestDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateUploadRequestDataUnion).IsAssignableFrom(typeToConvert);

        public override CreateUploadRequestDataUnion Read(
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
                    jsonWithoutDiscriminator.Deserialize<Kard.Users.StartHistoricalUploadNoData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.Users.StartHistoricalUploadNoData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateUploadRequestDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateUploadRequestDataUnion value,
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

        public override CreateUploadRequestDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateUploadRequestDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateUploadRequestDataUnion value,
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
        public HistoricalTransactionStart(Kard.Users.StartHistoricalUploadNoData value)
        {
            Value = value;
        }

        internal Kard.Users.StartHistoricalUploadNoData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateUploadRequestDataUnion.HistoricalTransactionStart(
            Kard.Users.StartHistoricalUploadNoData value
        ) => new(value);
    }
}
