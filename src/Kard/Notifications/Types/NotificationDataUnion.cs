// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard;

[JsonConverter(typeof(NotificationDataUnion.JsonConverter))]
[Serializable]
public record NotificationDataUnion
{
    internal NotificationDataUnion(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.EarnedRewardApproved"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.EarnedRewardApproved value)
    {
        Type = "earnedRewardApproved";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.EarnedRewardSettled"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.EarnedRewardSettled value)
    {
        Type = "earnedRewardSettled";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.ValidTransaction"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.ValidTransaction value)
    {
        Type = "validTransaction";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.FailedTransaction"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.FailedTransaction value)
    {
        Type = "failedTransaction";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.Clawback"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.Clawback value)
    {
        Type = "clawback";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.AuditUpdate"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.AuditUpdate value)
    {
        Type = "auditUpdate";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.FileProcessingResult"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.FileProcessingResult value)
    {
        Type = "fileProcessingResult";
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
    /// Returns true if <see cref="Type"/> is "earnedRewardApproved"
    /// </summary>
    public bool IsEarnedRewardApproved => Type == "earnedRewardApproved";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "earnedRewardSettled"
    /// </summary>
    public bool IsEarnedRewardSettled => Type == "earnedRewardSettled";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "validTransaction"
    /// </summary>
    public bool IsValidTransaction => Type == "validTransaction";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "failedTransaction"
    /// </summary>
    public bool IsFailedTransaction => Type == "failedTransaction";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "clawback"
    /// </summary>
    public bool IsClawback => Type == "clawback";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "auditUpdate"
    /// </summary>
    public bool IsAuditUpdate => Type == "auditUpdate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "fileProcessingResult"
    /// </summary>
    public bool IsFileProcessingResult => Type == "fileProcessingResult";

    /// <summary>
    /// Returns the value as a <see cref="Kard.EarnedRewardApprovedData"/> if <see cref="Type"/> is 'earnedRewardApproved', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'earnedRewardApproved'.</exception>
    public Kard.EarnedRewardApprovedData AsEarnedRewardApproved() =>
        IsEarnedRewardApproved
            ? (Kard.EarnedRewardApprovedData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'earnedRewardApproved'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Kard.EarnedRewardSettledData"/> if <see cref="Type"/> is 'earnedRewardSettled', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'earnedRewardSettled'.</exception>
    public Kard.EarnedRewardSettledData AsEarnedRewardSettled() =>
        IsEarnedRewardSettled
            ? (Kard.EarnedRewardSettledData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'earnedRewardSettled'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Kard.ValidTransactionData"/> if <see cref="Type"/> is 'validTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'validTransaction'.</exception>
    public Kard.ValidTransactionData AsValidTransaction() =>
        IsValidTransaction
            ? (Kard.ValidTransactionData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'validTransaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Kard.FailedTransactionData"/> if <see cref="Type"/> is 'failedTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'failedTransaction'.</exception>
    public Kard.FailedTransactionData AsFailedTransaction() =>
        IsFailedTransaction
            ? (Kard.FailedTransactionData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'failedTransaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Kard.ClawbackData"/> if <see cref="Type"/> is 'clawback', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'clawback'.</exception>
    public Kard.ClawbackData AsClawback() =>
        IsClawback
            ? (Kard.ClawbackData)Value!
            : throw new global::System.Exception("NotificationDataUnion.Type is not 'clawback'");

    /// <summary>
    /// Returns the value as a <see cref="Kard.AuditUpdateData"/> if <see cref="Type"/> is 'auditUpdate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'auditUpdate'.</exception>
    public Kard.AuditUpdateData AsAuditUpdate() =>
        IsAuditUpdate
            ? (Kard.AuditUpdateData)Value!
            : throw new global::System.Exception("NotificationDataUnion.Type is not 'auditUpdate'");

    /// <summary>
    /// Returns the value as a <see cref="Kard.FileResultData"/> if <see cref="Type"/> is 'fileProcessingResult', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'fileProcessingResult'.</exception>
    public Kard.FileResultData AsFileProcessingResult() =>
        IsFileProcessingResult
            ? (Kard.FileResultData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'fileProcessingResult'"
            );

    public T Match<T>(
        Func<Kard.EarnedRewardApprovedData, T> onEarnedRewardApproved,
        Func<Kard.EarnedRewardSettledData, T> onEarnedRewardSettled,
        Func<Kard.ValidTransactionData, T> onValidTransaction,
        Func<Kard.FailedTransactionData, T> onFailedTransaction,
        Func<Kard.ClawbackData, T> onClawback,
        Func<Kard.AuditUpdateData, T> onAuditUpdate,
        Func<Kard.FileResultData, T> onFileProcessingResult,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "earnedRewardApproved" => onEarnedRewardApproved(AsEarnedRewardApproved()),
            "earnedRewardSettled" => onEarnedRewardSettled(AsEarnedRewardSettled()),
            "validTransaction" => onValidTransaction(AsValidTransaction()),
            "failedTransaction" => onFailedTransaction(AsFailedTransaction()),
            "clawback" => onClawback(AsClawback()),
            "auditUpdate" => onAuditUpdate(AsAuditUpdate()),
            "fileProcessingResult" => onFileProcessingResult(AsFileProcessingResult()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Kard.EarnedRewardApprovedData> onEarnedRewardApproved,
        Action<Kard.EarnedRewardSettledData> onEarnedRewardSettled,
        Action<Kard.ValidTransactionData> onValidTransaction,
        Action<Kard.FailedTransactionData> onFailedTransaction,
        Action<Kard.ClawbackData> onClawback,
        Action<Kard.AuditUpdateData> onAuditUpdate,
        Action<Kard.FileResultData> onFileProcessingResult,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "earnedRewardApproved":
                onEarnedRewardApproved(AsEarnedRewardApproved());
                break;
            case "earnedRewardSettled":
                onEarnedRewardSettled(AsEarnedRewardSettled());
                break;
            case "validTransaction":
                onValidTransaction(AsValidTransaction());
                break;
            case "failedTransaction":
                onFailedTransaction(AsFailedTransaction());
                break;
            case "clawback":
                onClawback(AsClawback());
                break;
            case "auditUpdate":
                onAuditUpdate(AsAuditUpdate());
                break;
            case "fileProcessingResult":
                onFileProcessingResult(AsFileProcessingResult());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.EarnedRewardApprovedData"/> and returns true if successful.
    /// </summary>
    public bool TryAsEarnedRewardApproved(out Kard.EarnedRewardApprovedData? value)
    {
        if (Type == "earnedRewardApproved")
        {
            value = (Kard.EarnedRewardApprovedData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.EarnedRewardSettledData"/> and returns true if successful.
    /// </summary>
    public bool TryAsEarnedRewardSettled(out Kard.EarnedRewardSettledData? value)
    {
        if (Type == "earnedRewardSettled")
        {
            value = (Kard.EarnedRewardSettledData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.ValidTransactionData"/> and returns true if successful.
    /// </summary>
    public bool TryAsValidTransaction(out Kard.ValidTransactionData? value)
    {
        if (Type == "validTransaction")
        {
            value = (Kard.ValidTransactionData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.FailedTransactionData"/> and returns true if successful.
    /// </summary>
    public bool TryAsFailedTransaction(out Kard.FailedTransactionData? value)
    {
        if (Type == "failedTransaction")
        {
            value = (Kard.FailedTransactionData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.ClawbackData"/> and returns true if successful.
    /// </summary>
    public bool TryAsClawback(out Kard.ClawbackData? value)
    {
        if (Type == "clawback")
        {
            value = (Kard.ClawbackData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.AuditUpdateData"/> and returns true if successful.
    /// </summary>
    public bool TryAsAuditUpdate(out Kard.AuditUpdateData? value)
    {
        if (Type == "auditUpdate")
        {
            value = (Kard.AuditUpdateData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Kard.FileResultData"/> and returns true if successful.
    /// </summary>
    public bool TryAsFileProcessingResult(out Kard.FileResultData? value)
    {
        if (Type == "fileProcessingResult")
        {
            value = (Kard.FileResultData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.EarnedRewardApproved value
    ) => new(value);

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.EarnedRewardSettled value
    ) => new(value);

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.ValidTransaction value
    ) => new(value);

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.FailedTransaction value
    ) => new(value);

    public static implicit operator NotificationDataUnion(NotificationDataUnion.Clawback value) =>
        new(value);

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.AuditUpdate value
    ) => new(value);

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.FileProcessingResult value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<NotificationDataUnion>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(NotificationDataUnion).IsAssignableFrom(typeToConvert);

        public override NotificationDataUnion Read(
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
                "earnedRewardApproved" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.EarnedRewardApprovedData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.EarnedRewardApprovedData"
                        ),
                "earnedRewardSettled" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.EarnedRewardSettledData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.EarnedRewardSettledData"
                        ),
                "validTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.ValidTransactionData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.ValidTransactionData"
                        ),
                "failedTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.FailedTransactionData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Kard.FailedTransactionData"
                        ),
                "clawback" => jsonWithoutDiscriminator.Deserialize<Kard.ClawbackData?>(options)
                    ?? throw new JsonException("Failed to deserialize Kard.ClawbackData"),
                "auditUpdate" => jsonWithoutDiscriminator.Deserialize<Kard.AuditUpdateData?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Kard.AuditUpdateData"),
                "fileProcessingResult" =>
                    jsonWithoutDiscriminator.Deserialize<Kard.FileResultData?>(options)
                        ?? throw new JsonException("Failed to deserialize Kard.FileResultData"),
                _ => json.Deserialize<object?>(options),
            };
            return new NotificationDataUnion(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationDataUnion value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "earnedRewardApproved" => JsonSerializer.SerializeToNode(value.Value, options),
                    "earnedRewardSettled" => JsonSerializer.SerializeToNode(value.Value, options),
                    "validTransaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    "failedTransaction" => JsonSerializer.SerializeToNode(value.Value, options),
                    "clawback" => JsonSerializer.SerializeToNode(value.Value, options),
                    "auditUpdate" => JsonSerializer.SerializeToNode(value.Value, options),
                    "fileProcessingResult" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override NotificationDataUnion ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new NotificationDataUnion(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotificationDataUnion value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for earnedRewardApproved
    /// </summary>
    [Serializable]
    public struct EarnedRewardApproved
    {
        public EarnedRewardApproved(Kard.EarnedRewardApprovedData value)
        {
            Value = value;
        }

        internal Kard.EarnedRewardApprovedData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.EarnedRewardApproved(
            Kard.EarnedRewardApprovedData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for earnedRewardSettled
    /// </summary>
    [Serializable]
    public struct EarnedRewardSettled
    {
        public EarnedRewardSettled(Kard.EarnedRewardSettledData value)
        {
            Value = value;
        }

        internal Kard.EarnedRewardSettledData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.EarnedRewardSettled(
            Kard.EarnedRewardSettledData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for validTransaction
    /// </summary>
    [Serializable]
    public struct ValidTransaction
    {
        public ValidTransaction(Kard.ValidTransactionData value)
        {
            Value = value;
        }

        internal Kard.ValidTransactionData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.ValidTransaction(
            Kard.ValidTransactionData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for failedTransaction
    /// </summary>
    [Serializable]
    public struct FailedTransaction
    {
        public FailedTransaction(Kard.FailedTransactionData value)
        {
            Value = value;
        }

        internal Kard.FailedTransactionData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.FailedTransaction(
            Kard.FailedTransactionData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for clawback
    /// </summary>
    [Serializable]
    public struct Clawback
    {
        public Clawback(Kard.ClawbackData value)
        {
            Value = value;
        }

        internal Kard.ClawbackData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.Clawback(Kard.ClawbackData value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for auditUpdate
    /// </summary>
    [Serializable]
    public struct AuditUpdate
    {
        public AuditUpdate(Kard.AuditUpdateData value)
        {
            Value = value;
        }

        internal Kard.AuditUpdateData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.AuditUpdate(
            Kard.AuditUpdateData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for fileProcessingResult
    /// </summary>
    [Serializable]
    public struct FileProcessingResult
    {
        public FileProcessingResult(Kard.FileResultData value)
        {
            Value = value;
        }

        internal Kard.FileResultData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.FileProcessingResult(
            Kard.FileResultData value
        ) => new(value);
    }
}
