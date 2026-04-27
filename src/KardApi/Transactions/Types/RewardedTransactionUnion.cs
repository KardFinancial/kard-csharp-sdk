// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[JsonConverter(typeof(RewardedTransactionUnion.JsonConverter))]
[Serializable]
public record RewardedTransactionUnion
{
    internal RewardedTransactionUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of RewardedTransactionUnion with <see cref="RewardedTransactionUnion.RewardedTransaction"/>.
    /// </summary>
    public RewardedTransactionUnion(RewardedTransactionUnion.RewardedTransaction value)
    {
        Type = "rewardedTransaction";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RewardedTransactionUnion with <see cref="RewardedTransactionUnion.ApprovedTransaction"/>.
    /// </summary>
    public RewardedTransactionUnion(RewardedTransactionUnion.ApprovedTransaction value)
    {
        Type = "approvedTransaction";
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
    /// Returns true if <see cref="Type"/> is "rewardedTransaction"
    /// </summary>
    public bool IsRewardedTransaction => Type == "rewardedTransaction";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "approvedTransaction"
    /// </summary>
    public bool IsApprovedTransaction => Type == "approvedTransaction";

    /// <summary>
    /// Returns the value as a <see cref="KardApi.RewardedTransaction"/> if <see cref="Type"/> is 'rewardedTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'rewardedTransaction'.</exception>
    public KardApi.RewardedTransaction AsRewardedTransaction() =>
        IsRewardedTransaction
            ? (KardApi.RewardedTransaction)Value!
            : throw new global::System.Exception(
                "RewardedTransactionUnion.Type is not 'rewardedTransaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardApi.ApprovedTransaction"/> if <see cref="Type"/> is 'approvedTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'approvedTransaction'.</exception>
    public KardApi.ApprovedTransaction AsApprovedTransaction() =>
        IsApprovedTransaction
            ? (KardApi.ApprovedTransaction)Value!
            : throw new global::System.Exception(
                "RewardedTransactionUnion.Type is not 'approvedTransaction'"
            );

    public T Match<T>(
        Func<KardApi.RewardedTransaction, T> onRewardedTransaction,
        Func<KardApi.ApprovedTransaction, T> onApprovedTransaction,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "rewardedTransaction" => onRewardedTransaction(AsRewardedTransaction()),
            "approvedTransaction" => onApprovedTransaction(AsApprovedTransaction()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardApi.RewardedTransaction> onRewardedTransaction,
        Action<KardApi.ApprovedTransaction> onApprovedTransaction,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "rewardedTransaction":
                onRewardedTransaction(AsRewardedTransaction());
                break;
            case "approvedTransaction":
                onApprovedTransaction(AsApprovedTransaction());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.RewardedTransaction"/> and returns true if successful.
    /// </summary>
    public bool TryAsRewardedTransaction(out KardApi.RewardedTransaction? value)
    {
        if (Type == "rewardedTransaction")
        {
            value = (KardApi.RewardedTransaction)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.ApprovedTransaction"/> and returns true if successful.
    /// </summary>
    public bool TryAsApprovedTransaction(out KardApi.ApprovedTransaction? value)
    {
        if (Type == "approvedTransaction")
        {
            value = (KardApi.ApprovedTransaction)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator RewardedTransactionUnion(
        RewardedTransactionUnion.RewardedTransaction value
    ) => new(value);

    public static implicit operator RewardedTransactionUnion(
        RewardedTransactionUnion.ApprovedTransaction value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<RewardedTransactionUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(RewardedTransactionUnion).IsAssignableFrom(typeToConvert);

        public override RewardedTransactionUnion Read(
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
                "rewardedTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.RewardedTransaction?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.RewardedTransaction"
                        ),
                "approvedTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.ApprovedTransaction?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.ApprovedTransaction"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new RewardedTransactionUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RewardedTransactionUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "rewardedTransaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    "approvedTransaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override RewardedTransactionUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new RewardedTransactionUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RewardedTransactionUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for rewardedTransaction
    /// </summary>
    [Serializable]
    public struct RewardedTransaction
    {
        public RewardedTransaction(KardApi.RewardedTransaction value)
        {
            Value = value;
        }

        internal KardApi.RewardedTransaction Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RewardedTransactionUnion.RewardedTransaction(
            KardApi.RewardedTransaction value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for approvedTransaction
    /// </summary>
    [Serializable]
    public struct ApprovedTransaction
    {
        public ApprovedTransaction(KardApi.ApprovedTransaction value)
        {
            Value = value;
        }

        internal KardApi.ApprovedTransaction Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RewardedTransactionUnion.ApprovedTransaction(
            KardApi.ApprovedTransaction value
        ) => new(value);
    }
}
