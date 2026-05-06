// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(UpdateUploadResponseDataUnion.JsonConverter))]
[Serializable]
public record UpdateUploadResponseDataUnion
{
    internal UpdateUploadResponseDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UpdateUploadResponseDataUnion with <see cref="UpdateUploadResponseDataUnion.HistoricalTransactionComplete"/>.
    /// </summary>
    public UpdateUploadResponseDataUnion(
        UpdateUploadResponseDataUnion.HistoricalTransactionComplete value
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
    /// Returns the value as a <see cref="KardFinancial.Users.UpdateUploadResponseData"/> if <see cref="Type"/> is 'historicalTransactionComplete', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'historicalTransactionComplete'.</exception>
    public KardFinancial.Users.UpdateUploadResponseData AsHistoricalTransactionComplete() =>
        IsHistoricalTransactionComplete
            ? (KardFinancial.Users.UpdateUploadResponseData)Value!
            : throw new global::System.Exception(
                "UpdateUploadResponseDataUnion.Type is not 'historicalTransactionComplete'"
            );

    public T Match<T>(
        Func<KardFinancial.Users.UpdateUploadResponseData, T> onHistoricalTransactionComplete,
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
        Action<KardFinancial.Users.UpdateUploadResponseData> onHistoricalTransactionComplete,
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
    /// Attempts to cast the value to a <see cref="KardFinancial.Users.UpdateUploadResponseData"/> and returns true if successful.
    /// </summary>
    public bool TryAsHistoricalTransactionComplete(
        out KardFinancial.Users.UpdateUploadResponseData? value
    )
    {
        if (Type == "historicalTransactionComplete")
        {
            value = (KardFinancial.Users.UpdateUploadResponseData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UpdateUploadResponseDataUnion(
        UpdateUploadResponseDataUnion.HistoricalTransactionComplete value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UpdateUploadResponseDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UpdateUploadResponseDataUnion).IsAssignableFrom(typeToConvert);

        public override UpdateUploadResponseDataUnion Read(
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
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.Users.UpdateUploadResponseData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.Users.UpdateUploadResponseData"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new UpdateUploadResponseDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateUploadResponseDataUnion value,
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

        public override UpdateUploadResponseDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UpdateUploadResponseDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateUploadResponseDataUnion value,
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
        public HistoricalTransactionComplete(KardFinancial.Users.UpdateUploadResponseData value)
        {
            Value = value;
        }

        internal KardFinancial.Users.UpdateUploadResponseData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UpdateUploadResponseDataUnion.HistoricalTransactionComplete(
            KardFinancial.Users.UpdateUploadResponseData value
        ) => new(value);
    }
}
