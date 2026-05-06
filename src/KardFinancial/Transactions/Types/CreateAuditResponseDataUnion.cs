// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

[JsonConverter(typeof(CreateAuditResponseDataUnion.JsonConverter))]
[Serializable]
public record CreateAuditResponseDataUnion
{
    internal CreateAuditResponseDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateAuditResponseDataUnion with <see cref="CreateAuditResponseDataUnion.Audit"/>.
    /// </summary>
    public CreateAuditResponseDataUnion(CreateAuditResponseDataUnion.Audit value)
    {
        Type = "audit";
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
    /// Returns true if <see cref="Type"/> is "audit"
    /// </summary>
    public bool IsAudit => Type == "audit";

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.AuditResponseData"/> if <see cref="Type"/> is 'audit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'audit'.</exception>
    public KardFinancial.AuditResponseData AsAudit() =>
        IsAudit
            ? (KardFinancial.AuditResponseData)Value!
            : throw new global::System.Exception(
                "CreateAuditResponseDataUnion.Type is not 'audit'"
            );

    public T Match<T>(
        Func<KardFinancial.AuditResponseData, T> onAudit,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "audit" => onAudit(AsAudit()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.AuditResponseData> onAudit,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "audit":
                onAudit(AsAudit());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.AuditResponseData"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudit(out KardFinancial.AuditResponseData? value)
    {
        if (Type == "audit")
        {
            value = (KardFinancial.AuditResponseData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateAuditResponseDataUnion(
        CreateAuditResponseDataUnion.Audit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateAuditResponseDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateAuditResponseDataUnion).IsAssignableFrom(typeToConvert);

        public override CreateAuditResponseDataUnion Read(
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
                "audit" => jsonWithoutDiscriminator.Deserialize<KardFinancial.AuditResponseData?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize KardFinancial.AuditResponseData"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateAuditResponseDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateAuditResponseDataUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "audit" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override CreateAuditResponseDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateAuditResponseDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateAuditResponseDataUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for audit
    /// </summary>
    [Serializable]
    public struct Audit
    {
        public Audit(KardFinancial.AuditResponseData value)
        {
            Value = value;
        }

        internal KardFinancial.AuditResponseData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateAuditResponseDataUnion.Audit(
            KardFinancial.AuditResponseData value
        ) => new(value);
    }
}
