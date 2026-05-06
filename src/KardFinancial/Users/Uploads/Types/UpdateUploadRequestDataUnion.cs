// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

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
    /// Returns the value as a <see cref="KardFinancial.Users.HistoricalTransactionCompleteNoData"/> if <see cref="Type"/> is 'historicalTransactionComplete', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'historicalTransactionComplete'.</exception>
    public KardFinancial.Users.HistoricalTransactionCompleteNoData AsHistoricalTransactionComplete() =>
        IsHistoricalTransactionComplete
            ? (KardFinancial.Users.HistoricalTransactionCompleteNoData)Value!
            : throw new global::System.Exception(
                "UpdateUploadRequestDataUnion.Type is not 'historicalTransactionComplete'"
            );

    public T Match<T>(
        Func<
            KardFinancial.Users.HistoricalTransactionCompleteNoData,
            T
        > onHistoricalTransactionComplete,
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
        Action<KardFinancial.Users.HistoricalTransactionCompleteNoData> onHistoricalTransactionComplete,
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
    /// Attempts to cast the value to a <see cref="KardFinancial.Users.HistoricalTransactionCompleteNoData"/> and returns true if successful.
    /// </summary>
    public bool TryAsHistoricalTransactionComplete(
        out KardFinancial.Users.HistoricalTransactionCompleteNoData? value
    )
    {
        if (Type == "historicalTransactionComplete")
        {
            value = (KardFinancial.Users.HistoricalTransactionCompleteNoData)Value!;
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
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Users.HistoricalTransactionCompleteNoData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Users.HistoricalTransactionCompleteNoData"
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
            KardFinancial.Users.HistoricalTransactionCompleteNoData value
        )
        {
            Value = value;
        }

        internal KardFinancial.Users.HistoricalTransactionCompleteNoData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdateUploadRequestDataUnion.HistoricalTransactionComplete(
            KardFinancial.Users.HistoricalTransactionCompleteNoData value
        ) => new(value);
    }
}
