// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi.Users;

[JsonConverter(typeof(UpdateUploadRequestDataUnion.JsonConverter))]
[Serializable]
public record UpdateUploadRequestDataUnion
{
    internal UpdateUploadRequestDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UpdateUploadRequestDataUnion with <see cref="UpdateUploadRequestDataUnion.HistoricalTransactionComplete"/>.
    /// </summary>
    public UpdateUploadRequestDataUnion(
        UpdateUploadRequestDataUnion.HistoricalTransactionComplete value
    )
    {
        Type = "historicalTransactionComplete";
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
    /// Returns true if <see cref="Type"/> is "historicalTransactionComplete"
    /// </summary>
    public bool IsHistoricalTransactionComplete => Type == "historicalTransactionComplete";

    /// <summary>
    /// Returns the value as a <see cref="KardApi.Users.HistoricalTransactionCompleteNoData"/> if <see cref="Type"/> is 'historicalTransactionComplete', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'historicalTransactionComplete'.</exception>
    public KardApi.Users.HistoricalTransactionCompleteNoData AsHistoricalTransactionComplete() =>
        IsHistoricalTransactionComplete
            ? (KardApi.Users.HistoricalTransactionCompleteNoData)Value!
            : throw new global::System.Exception(
                "UpdateUploadRequestDataUnion.Type is not 'historicalTransactionComplete'"
            );

    public T Match<T>(
        Func<KardApi.Users.HistoricalTransactionCompleteNoData, T> onHistoricalTransactionComplete,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "historicalTransactionComplete" => onHistoricalTransactionComplete(
                AsHistoricalTransactionComplete()
            ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardApi.Users.HistoricalTransactionCompleteNoData> onHistoricalTransactionComplete,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "historicalTransactionComplete":
                onHistoricalTransactionComplete(AsHistoricalTransactionComplete());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.Users.HistoricalTransactionCompleteNoData"/> and returns true if successful.
    /// </summary>
    public bool TryAsHistoricalTransactionComplete(
        out KardApi.Users.HistoricalTransactionCompleteNoData? value
    )
    {
        if (Type == "historicalTransactionComplete")
        {
            value = (KardApi.Users.HistoricalTransactionCompleteNoData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UpdateUploadRequestDataUnion(
        UpdateUploadRequestDataUnion.HistoricalTransactionComplete value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UpdateUploadRequestDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UpdateUploadRequestDataUnion).IsAssignableFrom(typeToConvert);

        public override UpdateUploadRequestDataUnion Read(
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
                "historicalTransactionComplete" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.Users.HistoricalTransactionCompleteNoData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.Users.HistoricalTransactionCompleteNoData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new UpdateUploadRequestDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateUploadRequestDataUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "historicalTransactionComplete" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override UpdateUploadRequestDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UpdateUploadRequestDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateUploadRequestDataUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for historicalTransactionComplete
    /// </summary>
    [Serializable]
    public struct HistoricalTransactionComplete
    {
        public HistoricalTransactionComplete(
            KardApi.Users.HistoricalTransactionCompleteNoData value
        )
        {
            Value = value;
        }

        internal KardApi.Users.HistoricalTransactionCompleteNoData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdateUploadRequestDataUnion.HistoricalTransactionComplete(
            KardApi.Users.HistoricalTransactionCompleteNoData value
        ) => new(value);
    }
}
