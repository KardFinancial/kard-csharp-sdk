// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial.Users;

[JsonConverter(typeof(CreateUploadPartDataUnion.JsonConverter))]
[Serializable]
public record CreateUploadPartDataUnion
{
    internal CreateUploadPartDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateUploadPartDataUnion with <see cref="CreateUploadPartDataUnion.HistoricalTransaction"/>.
    /// </summary>
    public CreateUploadPartDataUnion(CreateUploadPartDataUnion.HistoricalTransaction value)
    {
        Type = "historicalTransaction";
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
    /// Returns true if <see cref="Type"/> is "historicalTransaction"
    /// </summary>
    public bool IsHistoricalTransaction => Type == "historicalTransaction";

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.TransactionsRequest"/> if <see cref="Type"/> is 'historicalTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'historicalTransaction'.</exception>
    public KardFinancial.TransactionsRequest AsHistoricalTransaction() =>
        IsHistoricalTransaction
            ? (KardFinancial.TransactionsRequest)Value!
            : throw new global::System.Exception(
                "CreateUploadPartDataUnion.Type is not 'historicalTransaction'"
            );

    public T Match<T>(
        Func<KardFinancial.TransactionsRequest, T> onHistoricalTransaction,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "historicalTransaction" => onHistoricalTransaction(AsHistoricalTransaction()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.TransactionsRequest> onHistoricalTransaction,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "historicalTransaction":
                onHistoricalTransaction(AsHistoricalTransaction());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.TransactionsRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsHistoricalTransaction(out KardFinancial.TransactionsRequest? value)
    {
        if (Type == "historicalTransaction")
        {
            value = (KardFinancial.TransactionsRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateUploadPartDataUnion(
        CreateUploadPartDataUnion.HistoricalTransaction value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateUploadPartDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateUploadPartDataUnion).IsAssignableFrom(typeToConvert);

        public override CreateUploadPartDataUnion Read(
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
                "historicalTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.TransactionsRequest?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.TransactionsRequest"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateUploadPartDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateUploadPartDataUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "historicalTransaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override CreateUploadPartDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateUploadPartDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateUploadPartDataUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for historicalTransaction
    /// </summary>
    [Serializable]
    public struct HistoricalTransaction
    {
        public HistoricalTransaction(KardFinancial.TransactionsRequest value)
        {
            Value = value;
        }

        internal KardFinancial.TransactionsRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateUploadPartDataUnion.HistoricalTransaction(
            KardFinancial.TransactionsRequest value
        ) => new(value);
    }
}
