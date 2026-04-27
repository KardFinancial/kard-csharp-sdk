// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

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
    /// Returns the value as a <see cref="KardApi.EarnedRewardApprovedData"/> if <see cref="Type"/> is 'earnedRewardApproved', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'earnedRewardApproved'.</exception>
    public KardApi.EarnedRewardApprovedData AsEarnedRewardApproved() =>
        IsEarnedRewardApproved
            ? (KardApi.EarnedRewardApprovedData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'earnedRewardApproved'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardApi.EarnedRewardSettledData"/> if <see cref="Type"/> is 'earnedRewardSettled', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'earnedRewardSettled'.</exception>
    public KardApi.EarnedRewardSettledData AsEarnedRewardSettled() =>
        IsEarnedRewardSettled
            ? (KardApi.EarnedRewardSettledData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'earnedRewardSettled'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardApi.ValidTransactionData"/> if <see cref="Type"/> is 'validTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'validTransaction'.</exception>
    public KardApi.ValidTransactionData AsValidTransaction() =>
        IsValidTransaction
            ? (KardApi.ValidTransactionData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'validTransaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardApi.FailedTransactionData"/> if <see cref="Type"/> is 'failedTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'failedTransaction'.</exception>
    public KardApi.FailedTransactionData AsFailedTransaction() =>
        IsFailedTransaction
            ? (KardApi.FailedTransactionData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'failedTransaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardApi.ClawbackData"/> if <see cref="Type"/> is 'clawback', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'clawback'.</exception>
    public KardApi.ClawbackData AsClawback() =>
        IsClawback
            ? (KardApi.ClawbackData)Value!
            : throw new global::System.Exception("NotificationDataUnion.Type is not 'clawback'");

    /// <summary>
    /// Returns the value as a <see cref="KardApi.AuditUpdateData"/> if <see cref="Type"/> is 'auditUpdate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'auditUpdate'.</exception>
    public KardApi.AuditUpdateData AsAuditUpdate() =>
        IsAuditUpdate
            ? (KardApi.AuditUpdateData)Value!
            : throw new global::System.Exception("NotificationDataUnion.Type is not 'auditUpdate'");

    /// <summary>
    /// Returns the value as a <see cref="KardApi.FileResultData"/> if <see cref="Type"/> is 'fileProcessingResult', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'fileProcessingResult'.</exception>
    public KardApi.FileResultData AsFileProcessingResult() =>
        IsFileProcessingResult
            ? (KardApi.FileResultData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'fileProcessingResult'"
            );

    public T Match<T>(
        Func<KardApi.EarnedRewardApprovedData, T> onEarnedRewardApproved,
        Func<KardApi.EarnedRewardSettledData, T> onEarnedRewardSettled,
        Func<KardApi.ValidTransactionData, T> onValidTransaction,
        Func<KardApi.FailedTransactionData, T> onFailedTransaction,
        Func<KardApi.ClawbackData, T> onClawback,
        Func<KardApi.AuditUpdateData, T> onAuditUpdate,
        Func<KardApi.FileResultData, T> onFileProcessingResult,
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
        Action<KardApi.EarnedRewardApprovedData> onEarnedRewardApproved,
        Action<KardApi.EarnedRewardSettledData> onEarnedRewardSettled,
        Action<KardApi.ValidTransactionData> onValidTransaction,
        Action<KardApi.FailedTransactionData> onFailedTransaction,
        Action<KardApi.ClawbackData> onClawback,
        Action<KardApi.AuditUpdateData> onAuditUpdate,
        Action<KardApi.FileResultData> onFileProcessingResult,
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
    /// Attempts to cast the value to a <see cref="KardApi.EarnedRewardApprovedData"/> and returns true if successful.
    /// </summary>
    public bool TryAsEarnedRewardApproved(out KardApi.EarnedRewardApprovedData? value)
    {
        if (Type == "earnedRewardApproved")
        {
            value = (KardApi.EarnedRewardApprovedData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.EarnedRewardSettledData"/> and returns true if successful.
    /// </summary>
    public bool TryAsEarnedRewardSettled(out KardApi.EarnedRewardSettledData? value)
    {
        if (Type == "earnedRewardSettled")
        {
            value = (KardApi.EarnedRewardSettledData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.ValidTransactionData"/> and returns true if successful.
    /// </summary>
    public bool TryAsValidTransaction(out KardApi.ValidTransactionData? value)
    {
        if (Type == "validTransaction")
        {
            value = (KardApi.ValidTransactionData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.FailedTransactionData"/> and returns true if successful.
    /// </summary>
    public bool TryAsFailedTransaction(out KardApi.FailedTransactionData? value)
    {
        if (Type == "failedTransaction")
        {
            value = (KardApi.FailedTransactionData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.ClawbackData"/> and returns true if successful.
    /// </summary>
    public bool TryAsClawback(out KardApi.ClawbackData? value)
    {
        if (Type == "clawback")
        {
            value = (KardApi.ClawbackData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.AuditUpdateData"/> and returns true if successful.
    /// </summary>
    public bool TryAsAuditUpdate(out KardApi.AuditUpdateData? value)
    {
        if (Type == "auditUpdate")
        {
            value = (KardApi.AuditUpdateData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardApi.FileResultData"/> and returns true if successful.
    /// </summary>
    public bool TryAsFileProcessingResult(out KardApi.FileResultData? value)
    {
        if (Type == "fileProcessingResult")
        {
            value = (KardApi.FileResultData)Value!;
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
                    jsonWithoutDiscriminator.Deserialize<KardApi.EarnedRewardApprovedData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.EarnedRewardApprovedData"
                        ),
                "earnedRewardSettled" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.EarnedRewardSettledData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.EarnedRewardSettledData"
                        ),
                "validTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.ValidTransactionData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.ValidTransactionData"
                        ),
                "failedTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.FailedTransactionData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardApi.FailedTransactionData"
                        ),
                "clawback" => jsonWithoutDiscriminator.Deserialize<KardApi.ClawbackData?>(options)
                    ?? throw new JsonException("Failed to deserialize KardApi.ClawbackData"),
                "auditUpdate" => jsonWithoutDiscriminator.Deserialize<KardApi.AuditUpdateData?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize KardApi.AuditUpdateData"),
                "fileProcessingResult" =>
                    jsonWithoutDiscriminator.Deserialize<KardApi.FileResultData?>(options)
                        ?? throw new JsonException("Failed to deserialize KardApi.FileResultData"),
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
        public EarnedRewardApproved(KardApi.EarnedRewardApprovedData value)
        {
            Value = value;
        }

        internal KardApi.EarnedRewardApprovedData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.EarnedRewardApproved(
            KardApi.EarnedRewardApprovedData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for earnedRewardSettled
    /// </summary>
    [Serializable]
    public struct EarnedRewardSettled
    {
        public EarnedRewardSettled(KardApi.EarnedRewardSettledData value)
        {
            Value = value;
        }

        internal KardApi.EarnedRewardSettledData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.EarnedRewardSettled(
            KardApi.EarnedRewardSettledData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for validTransaction
    /// </summary>
    [Serializable]
    public struct ValidTransaction
    {
        public ValidTransaction(KardApi.ValidTransactionData value)
        {
            Value = value;
        }

        internal KardApi.ValidTransactionData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.ValidTransaction(
            KardApi.ValidTransactionData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for failedTransaction
    /// </summary>
    [Serializable]
    public struct FailedTransaction
    {
        public FailedTransaction(KardApi.FailedTransactionData value)
        {
            Value = value;
        }

        internal KardApi.FailedTransactionData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.FailedTransaction(
            KardApi.FailedTransactionData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for clawback
    /// </summary>
    [Serializable]
    public struct Clawback
    {
        public Clawback(KardApi.ClawbackData value)
        {
            Value = value;
        }

        internal KardApi.ClawbackData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.Clawback(
            KardApi.ClawbackData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for auditUpdate
    /// </summary>
    [Serializable]
    public struct AuditUpdate
    {
        public AuditUpdate(KardApi.AuditUpdateData value)
        {
            Value = value;
        }

        internal KardApi.AuditUpdateData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.AuditUpdate(
            KardApi.AuditUpdateData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for fileProcessingResult
    /// </summary>
    [Serializable]
    public struct FileProcessingResult
    {
        public FileProcessingResult(KardApi.FileResultData value)
        {
            Value = value;
        }

        internal KardApi.FileResultData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.FileProcessingResult(
            KardApi.FileResultData value
        ) => new(value);
    }
}
