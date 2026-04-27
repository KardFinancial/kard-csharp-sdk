// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(CreateAuditRequestDataUnion.JsonConverter))]
[Serializable]
public record CreateAuditRequestDataUnion
{
    internal CreateAuditRequestDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CreateAuditRequestDataUnion with <see cref="CreateAuditRequestDataUnion.Audit"/>.
    /// </summary>
    public CreateAuditRequestDataUnion(CreateAuditRequestDataUnion.Audit value)
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
    /// Returns the value as a <see cref="KardApi.AuditRequestData"/> if <see cref="Type"/> is 'audit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'audit'.</exception>
    public KardApi.AuditRequestData AsAudit() =>
        IsAudit
            ? (KardApi.AuditRequestData)Value!
            : throw new global::System.Exception("CreateAuditRequestDataUnion.Type is not 'audit'");

    public T Match<T>(
        Func<KardApi.AuditRequestData, T> onAudit,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "audit" => onAudit(AsAudit()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(Action<KardApi.AuditRequestData> onAudit, Action<string, object?> onUnknown_)
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
    /// Attempts to cast the value to a <see cref="KardApi.AuditRequestData"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudit(out KardApi.AuditRequestData? value)
    {
        if (Type == "audit")
        {
            value = (KardApi.AuditRequestData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CreateAuditRequestDataUnion(
        CreateAuditRequestDataUnion.Audit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateAuditRequestDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CreateAuditRequestDataUnion).IsAssignableFrom(typeToConvert);

        public override CreateAuditRequestDataUnion Read(
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
                "audit" => jsonWithoutDiscriminator.Deserialize<KardApi.AuditRequestData?>(options)
                    ?? throw new JsonException("Failed to deserialize KardApi.AuditRequestData"),
                _ => json.Deserialize<object?>(options),
            };
            return new CreateAuditRequestDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateAuditRequestDataUnion value,
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

        public override CreateAuditRequestDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CreateAuditRequestDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateAuditRequestDataUnion value,
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
        public Audit(KardApi.AuditRequestData value)
        {
            Value = value;
        }

        internal KardApi.AuditRequestData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CreateAuditRequestDataUnion.Audit(
            KardApi.AuditRequestData value
        ) => new(value);
    }
}
