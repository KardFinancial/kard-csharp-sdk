// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;
using KardFinancial.Core;

namespace KardFinancial;

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
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.PushNotificationPlacementFile"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.PushNotificationPlacementFile value)
    {
        Type = "pushNotificationPlacementFile";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of NotificationDataUnion with <see cref="NotificationDataUnion.EmailNotificationPlacementFile"/>.
    /// </summary>
    public NotificationDataUnion(NotificationDataUnion.EmailNotificationPlacementFile value)
    {
        Type = "emailNotificationPlacementFile";
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
    /// Returns true if <see cref="Type"/> is "pushNotificationPlacementFile"
    /// </summary>
    public bool IsPushNotificationPlacementFile => Type == "pushNotificationPlacementFile";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailNotificationPlacementFile"
    /// </summary>
    public bool IsEmailNotificationPlacementFile => Type == "emailNotificationPlacementFile";

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.EarnedRewardApprovedData"/> if <see cref="Type"/> is 'earnedRewardApproved', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'earnedRewardApproved'.</exception>
    public KardFinancial.EarnedRewardApprovedData AsEarnedRewardApproved() =>
        IsEarnedRewardApproved
            ? (KardFinancial.EarnedRewardApprovedData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'earnedRewardApproved'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.EarnedRewardSettledData"/> if <see cref="Type"/> is 'earnedRewardSettled', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'earnedRewardSettled'.</exception>
    public KardFinancial.EarnedRewardSettledData AsEarnedRewardSettled() =>
        IsEarnedRewardSettled
            ? (KardFinancial.EarnedRewardSettledData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'earnedRewardSettled'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.ValidTransactionData"/> if <see cref="Type"/> is 'validTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'validTransaction'.</exception>
    public KardFinancial.ValidTransactionData AsValidTransaction() =>
        IsValidTransaction
            ? (KardFinancial.ValidTransactionData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'validTransaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.FailedTransactionData"/> if <see cref="Type"/> is 'failedTransaction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'failedTransaction'.</exception>
    public KardFinancial.FailedTransactionData AsFailedTransaction() =>
        IsFailedTransaction
            ? (KardFinancial.FailedTransactionData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'failedTransaction'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.ClawbackData"/> if <see cref="Type"/> is 'clawback', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'clawback'.</exception>
    public KardFinancial.ClawbackData AsClawback() =>
        IsClawback
            ? (KardFinancial.ClawbackData)Value!
            : throw new global::System.Exception("NotificationDataUnion.Type is not 'clawback'");

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.AuditUpdateData"/> if <see cref="Type"/> is 'auditUpdate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'auditUpdate'.</exception>
    public KardFinancial.AuditUpdateData AsAuditUpdate() =>
        IsAuditUpdate
            ? (KardFinancial.AuditUpdateData)Value!
            : throw new global::System.Exception("NotificationDataUnion.Type is not 'auditUpdate'");

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.FileResultData"/> if <see cref="Type"/> is 'fileProcessingResult', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'fileProcessingResult'.</exception>
    public KardFinancial.FileResultData AsFileProcessingResult() =>
        IsFileProcessingResult
            ? (KardFinancial.FileResultData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'fileProcessingResult'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.PushNotificationPlacementFileData"/> if <see cref="Type"/> is 'pushNotificationPlacementFile', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'pushNotificationPlacementFile'.</exception>
    public KardFinancial.PushNotificationPlacementFileData AsPushNotificationPlacementFile() =>
        IsPushNotificationPlacementFile
            ? (KardFinancial.PushNotificationPlacementFileData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'pushNotificationPlacementFile'"
            );

    /// <summary>
    /// Returns the value as a <see cref="KardFinancial.EmailNotificationPlacementFileData"/> if <see cref="Type"/> is 'emailNotificationPlacementFile', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'emailNotificationPlacementFile'.</exception>
    public KardFinancial.EmailNotificationPlacementFileData AsEmailNotificationPlacementFile() =>
        IsEmailNotificationPlacementFile
            ? (KardFinancial.EmailNotificationPlacementFileData)Value!
            : throw new global::System.Exception(
                "NotificationDataUnion.Type is not 'emailNotificationPlacementFile'"
            );

    public T Match<T>(
        Func<KardFinancial.EarnedRewardApprovedData, T> onEarnedRewardApproved,
        Func<KardFinancial.EarnedRewardSettledData, T> onEarnedRewardSettled,
        Func<KardFinancial.ValidTransactionData, T> onValidTransaction,
        Func<KardFinancial.FailedTransactionData, T> onFailedTransaction,
        Func<KardFinancial.ClawbackData, T> onClawback,
        Func<KardFinancial.AuditUpdateData, T> onAuditUpdate,
        Func<KardFinancial.FileResultData, T> onFileProcessingResult,
        Func<KardFinancial.PushNotificationPlacementFileData, T> onPushNotificationPlacementFile,
        Func<KardFinancial.EmailNotificationPlacementFileData, T> onEmailNotificationPlacementFile,
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
            "pushNotificationPlacementFile" => onPushNotificationPlacementFile(
                AsPushNotificationPlacementFile()
            ),
            "emailNotificationPlacementFile" => onEmailNotificationPlacementFile(
                AsEmailNotificationPlacementFile()
            ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<KardFinancial.EarnedRewardApprovedData> onEarnedRewardApproved,
        Action<KardFinancial.EarnedRewardSettledData> onEarnedRewardSettled,
        Action<KardFinancial.ValidTransactionData> onValidTransaction,
        Action<KardFinancial.FailedTransactionData> onFailedTransaction,
        Action<KardFinancial.ClawbackData> onClawback,
        Action<KardFinancial.AuditUpdateData> onAuditUpdate,
        Action<KardFinancial.FileResultData> onFileProcessingResult,
        Action<KardFinancial.PushNotificationPlacementFileData> onPushNotificationPlacementFile,
        Action<KardFinancial.EmailNotificationPlacementFileData> onEmailNotificationPlacementFile,
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
            case "pushNotificationPlacementFile":
                onPushNotificationPlacementFile(AsPushNotificationPlacementFile());
                break;
            case "emailNotificationPlacementFile":
                onEmailNotificationPlacementFile(AsEmailNotificationPlacementFile());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.EarnedRewardApprovedData"/> and returns true if successful.
    /// </summary>
    public bool TryAsEarnedRewardApproved(out KardFinancial.EarnedRewardApprovedData? value)
    {
        if (Type == "earnedRewardApproved")
        {
            value = (KardFinancial.EarnedRewardApprovedData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.EarnedRewardSettledData"/> and returns true if successful.
    /// </summary>
    public bool TryAsEarnedRewardSettled(out KardFinancial.EarnedRewardSettledData? value)
    {
        if (Type == "earnedRewardSettled")
        {
            value = (KardFinancial.EarnedRewardSettledData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.ValidTransactionData"/> and returns true if successful.
    /// </summary>
    public bool TryAsValidTransaction(out KardFinancial.ValidTransactionData? value)
    {
        if (Type == "validTransaction")
        {
            value = (KardFinancial.ValidTransactionData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.FailedTransactionData"/> and returns true if successful.
    /// </summary>
    public bool TryAsFailedTransaction(out KardFinancial.FailedTransactionData? value)
    {
        if (Type == "failedTransaction")
        {
            value = (KardFinancial.FailedTransactionData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.ClawbackData"/> and returns true if successful.
    /// </summary>
    public bool TryAsClawback(out KardFinancial.ClawbackData? value)
    {
        if (Type == "clawback")
        {
            value = (KardFinancial.ClawbackData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.AuditUpdateData"/> and returns true if successful.
    /// </summary>
    public bool TryAsAuditUpdate(out KardFinancial.AuditUpdateData? value)
    {
        if (Type == "auditUpdate")
        {
            value = (KardFinancial.AuditUpdateData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.FileResultData"/> and returns true if successful.
    /// </summary>
    public bool TryAsFileProcessingResult(out KardFinancial.FileResultData? value)
    {
        if (Type == "fileProcessingResult")
        {
            value = (KardFinancial.FileResultData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.PushNotificationPlacementFileData"/> and returns true if successful.
    /// </summary>
    public bool TryAsPushNotificationPlacementFile(
        out KardFinancial.PushNotificationPlacementFileData? value
    )
    {
        if (Type == "pushNotificationPlacementFile")
        {
            value = (KardFinancial.PushNotificationPlacementFileData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="KardFinancial.EmailNotificationPlacementFileData"/> and returns true if successful.
    /// </summary>
    public bool TryAsEmailNotificationPlacementFile(
        out KardFinancial.EmailNotificationPlacementFileData? value
    )
    {
        if (Type == "emailNotificationPlacementFile")
        {
            value = (KardFinancial.EmailNotificationPlacementFileData)Value!;
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

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.PushNotificationPlacementFile value
    ) => new(value);

    public static implicit operator NotificationDataUnion(
        NotificationDataUnion.EmailNotificationPlacementFile value
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
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.EarnedRewardApprovedData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.EarnedRewardApprovedData"
                        ),
                "earnedRewardSettled" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.EarnedRewardSettledData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.EarnedRewardSettledData"
                        ),
                "validTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.ValidTransactionData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.ValidTransactionData"
                        ),
                "failedTransaction" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.FailedTransactionData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.FailedTransactionData"
                        ),
                "clawback" => jsonWithoutDiscriminator.Deserialize<KardFinancial.ClawbackData?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize KardFinancial.ClawbackData"),
                "auditUpdate" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.AuditUpdateData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.AuditUpdateData"
                        ),
                "fileProcessingResult" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.FileResultData?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.FileResultData"
                        ),
                "pushNotificationPlacementFile" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.PushNotificationPlacementFileData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.PushNotificationPlacementFileData"
                        ),
                "emailNotificationPlacementFile" =>
                    jsonWithoutDiscriminator.Deserialize<KardFinancial.EmailNotificationPlacementFileData?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize KardFinancial.EmailNotificationPlacementFileData"
                        ),
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
                    "pushNotificationPlacementFile" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "emailNotificationPlacementFile" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
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
        public EarnedRewardApproved(KardFinancial.EarnedRewardApprovedData value)
        {
            Value = value;
        }

        internal KardFinancial.EarnedRewardApprovedData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.EarnedRewardApproved(
            KardFinancial.EarnedRewardApprovedData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for earnedRewardSettled
    /// </summary>
    [Serializable]
    public struct EarnedRewardSettled
    {
        public EarnedRewardSettled(KardFinancial.EarnedRewardSettledData value)
        {
            Value = value;
        }

        internal KardFinancial.EarnedRewardSettledData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.EarnedRewardSettled(
            KardFinancial.EarnedRewardSettledData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for validTransaction
    /// </summary>
    [Serializable]
    public struct ValidTransaction
    {
        public ValidTransaction(KardFinancial.ValidTransactionData value)
        {
            Value = value;
        }

        internal KardFinancial.ValidTransactionData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.ValidTransaction(
            KardFinancial.ValidTransactionData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for failedTransaction
    /// </summary>
    [Serializable]
    public struct FailedTransaction
    {
        public FailedTransaction(KardFinancial.FailedTransactionData value)
        {
            Value = value;
        }

        internal KardFinancial.FailedTransactionData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.FailedTransaction(
            KardFinancial.FailedTransactionData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for clawback
    /// </summary>
    [Serializable]
    public struct Clawback
    {
        public Clawback(KardFinancial.ClawbackData value)
        {
            Value = value;
        }

        internal KardFinancial.ClawbackData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.Clawback(
            KardFinancial.ClawbackData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for auditUpdate
    /// </summary>
    [Serializable]
    public struct AuditUpdate
    {
        public AuditUpdate(KardFinancial.AuditUpdateData value)
        {
            Value = value;
        }

        internal KardFinancial.AuditUpdateData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.AuditUpdate(
            KardFinancial.AuditUpdateData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for fileProcessingResult
    /// </summary>
    [Serializable]
    public struct FileProcessingResult
    {
        public FileProcessingResult(KardFinancial.FileResultData value)
        {
            Value = value;
        }

        internal KardFinancial.FileResultData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.FileProcessingResult(
            KardFinancial.FileResultData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for pushNotificationPlacementFile
    /// </summary>
    [Serializable]
    public struct PushNotificationPlacementFile
    {
        public PushNotificationPlacementFile(KardFinancial.PushNotificationPlacementFileData value)
        {
            Value = value;
        }

        internal KardFinancial.PushNotificationPlacementFileData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.PushNotificationPlacementFile(
            KardFinancial.PushNotificationPlacementFileData value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for emailNotificationPlacementFile
    /// </summary>
    [Serializable]
    public struct EmailNotificationPlacementFile
    {
        public EmailNotificationPlacementFile(
            KardFinancial.EmailNotificationPlacementFileData value
        )
        {
            Value = value;
        }

        internal KardFinancial.EmailNotificationPlacementFileData Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator NotificationDataUnion.EmailNotificationPlacementFile(
            KardFinancial.EmailNotificationPlacementFileData value
        ) => new(value);
    }
}
