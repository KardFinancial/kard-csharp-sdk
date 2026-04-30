// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(Transactions.JsonConverter))]
[Serializable]
public record Transactions
{
    internal Transactions(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Transactions with <see cref="Transactions.Transaction"/>.
    /// </summary>
    public Transactions(Transactions.Transaction value)
    {
        Type = "transaction";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Transactions with <see cref="Transactions.MatchedTransaction"/>.
    /// </summary>
    public Transactions(Transactions.MatchedTransaction value)
    {
        Type = "matchedTransaction";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Transactions with <see cref="Transactions.CoreTransaction"/>.
    /// </summary>
    public Transactions(Transactions.CoreTransaction value)
    {
        Type = "coreTransaction";
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
    /// Returns true if <see cref="Type"/> is "transaction"
    /// </summary>
    public bool IsTransaction => Type == "transaction";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "matchedTransaction"
    /// </summary>
    public bool IsMatchedTransaction => Type == "matchedTransaction";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "coreTransaction"
    /// </summary>
    public bool IsCoreTransaction => Type == "coreTransaction";

    /// <summary>
    /// Returns the value as a <see cref="Kard.TransactionsRequest"/> if <see cref="Type"/> is 'transaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'transaction'.</exception>
    public Kard.TransactionsRequest AsTransaction() =>
        IsTransaction
            ? (Kard.TransactionsRequest)Value!
            : throw new global::System.Exception("Transactions.Type is not 'transaction'");

    /// <summary>
    /// Returns the value as a <see cref="Kard.MatchedTransactionsRequest"/> if <see cref="Type"/> is 'matchedTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'matchedTransaction'.</exception>
    public Kard.MatchedTransactionsRequest AsMatchedTransaction() =>
        IsMatchedTransaction
            ? (Kard.MatchedTransactionsRequest)Value!
            : throw new global::System.Exception("Transactions.Type is not 'matchedTransaction'");

    /// <summary>
    /// Returns the value as a <see cref="Kard.CoreTransactionRequest"/> if <see cref="Type"/> is 'coreTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'coreTransaction'.</exception>
    public Kard.CoreTransactionRequest AsCoreTransaction() =>
        IsCoreTransaction
            ? (Kard.CoreTransactionRequest)Value!
            : throw new global::System.Exception("Transactions.Type is not 'coreTransaction'");

    public T Match<T>(
        Func<Kard.TransactionsRequest, T> onTransaction,
        Func<Kard.MatchedTransactionsRequest, T> onMatchedTransaction,
        Func<Kard.CoreTransactionRequest, T> onCoreTransaction,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "transaction" => onTransaction(AsTransaction()),
            "matchedTransaction" => onMatchedTransaction(AsMatchedTransaction()),
            "coreTransaction" => onCoreTransaction(AsCoreTransaction()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Kard.TransactionsRequest> onTransaction,
        Action<Kard.MatchedTransactionsRequest> onMatchedTransaction,
        Action<Kard.CoreTransactionRequest> onCoreTransaction,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "transaction":
                onTransaction(AsTransaction());
                break;
            case "matchedTransaction":
                onMatchedTransaction(AsMatchedTransaction());
                break;
            case "coreTransaction":
                onCoreTransaction(AsCoreTransaction());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.TransactionsRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransaction(out Kard.TransactionsRequest? value)
    {
        if (Type == "transaction")
        {
            value = (Kard.TransactionsRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.MatchedTransactionsRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsMatchedTransaction(out Kard.MatchedTransactionsRequest? value)
    {
        if (Type == "matchedTransaction")
        {
            value = (Kard.MatchedTransactionsRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.CoreTransactionRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsCoreTransaction(out Kard.CoreTransactionRequest? value)
    {
        if (Type == "coreTransaction")
        {
            value = (Kard.CoreTransactionRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Transactions(Transactions.Transaction value) => new(value);

    public static implicit operator Transactions(Transactions.MatchedTransaction value) =>
        new(value);

    public static implicit operator Transactions(Transactions.CoreTransaction value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Transactions>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Transactions).IsAssignableFrom(typeToConvert);

        public override Transactions Read(
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
                "transaction" => jsonWithoutDiscriminator.Deserialize<Kard.TransactionsRequest?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Kard.TransactionsRequest"),
                "matchedTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.MatchedTransactionsRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.MatchedTransactionsRequest"
                        ),
                "coreTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.CoreTransactionRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.CoreTransactionRequest"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new Transactions(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Transactions value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "transaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    "matchedTransaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    "coreTransaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override Transactions ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Transactions(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Transactions value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for transaction
    /// </summary>
    [Serializable]
    public struct Transaction
    {
        public Transaction(Kard.TransactionsRequest value)
        {
            Value = value;
        }

        internal Kard.TransactionsRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Transactions.Transaction(Kard.TransactionsRequest value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for matchedTransaction
    /// </summary>
    [Serializable]
    public struct MatchedTransaction
    {
        public MatchedTransaction(Kard.MatchedTransactionsRequest value)
        {
            Value = value;
        }

        internal Kard.MatchedTransactionsRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Transactions.MatchedTransaction(
            Kard.MatchedTransactionsRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for coreTransaction
    /// </summary>
    [Serializable]
    public struct CoreTransaction
    {
        public CoreTransaction(Kard.CoreTransactionRequest value)
        {
            Value = value;
        }

        internal Kard.CoreTransactionRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Transactions.CoreTransaction(
            Kard.CoreTransactionRequest value
        ) => new(value);
    }
}
