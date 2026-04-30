// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(ProcessorMid.JsonConverter))]
[Serializable]
public record ProcessorMid
{
    internal ProcessorMid(string type, object? value)
    {
        Processor = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ProcessorMid with <see cref="ProcessorMid.Visa"/>.
    /// </summary>
    public ProcessorMid(ProcessorMid.Visa value)
    {
        Processor = "VISA";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("processor")]
    public string Processor { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Processor"/> is "VISA"
    /// </summary>
    public bool IsVisa => Processor == "VISA";

    /// <summary>
    /// Returns the value as a <see cref="Kard.VisaMid"/> if <see cref="Processor"/> is 'VISA', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Processor"/> is not 'VISA'.</exception>
    public Kard.VisaMid AsVisa() =>
        IsVisa
            ? (Kard.VisaMid)Value!
            : throw new global::System.Exception("ProcessorMid.Processor is not 'VISA'");

    public T Match<T>(Func<Kard.VisaMid, T> onVisa, Func<string, object?, T> onUnknown_)
    {
        return Processor switch
        {
            "VISA" => onVisa(AsVisa()),
            _ => onUnknown_(Processor, Value),
        };
    }

    public void Visit(Action<Kard.VisaMid> onVisa, Action<string, object?> onUnknown_)
    {
        switch (Processor)
        {
            case "VISA":
                onVisa(AsVisa());
                break;
            default:
                onUnknown_(Processor, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.VisaMid"/> and returns true if successful.
    /// </summary>
    public bool TryAsVisa(out Kard.VisaMid? value)
    {
        if (Processor == "VISA")
        {
            value = (Kard.VisaMid)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ProcessorMid(ProcessorMid.Visa value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ProcessorMid>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ProcessorMid).IsAssignableFrom(typeToConvert);

        public override ProcessorMid Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("processor", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'processor'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'processor' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'processor' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'processor' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("processor");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "VISA" => jsonWithoutDiscriminator.Deserialize<Kard.VisaMid?>(options)
                    ?? throw new JsonException("Failed to deserialize Kard.VisaMid"),
                _ => json.Deserialize<object?>(options),
            };
            return new ProcessorMid(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProcessorMid value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Processor switch
                {
                    "VISA" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["processor"] = value.Processor;
            json.WriteTo(writer, options);
        }

        public override ProcessorMid ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ProcessorMid(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProcessorMid value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Processor);
        }
    }

    /// <summary>
    /// Discriminated union type for VISA
    /// </summary>
    [Serializable]
    public struct Visa
    {
        public Visa(Kard.VisaMid value)
        {
            Value = value;
        }

        internal Kard.VisaMid Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ProcessorMid.Visa(Kard.VisaMid value) => new(value);
    }
}
