using global::System.Text.Json.Serialization;
using KardApi.Core;

namespace KardApi;

[Serializable]
public record GetFilesMetadataRequest
{
    /// <summary>
    /// Start date for filtering files (format ISO8601). If not provided, defaults to current date minus 1 month.
    /// </summary>
    [JsonIgnore]
    public string? FilterDateFrom { get; set; }

    /// <summary>
    /// End date for filtering files (format ISO8601). If not provided, defaults to current date.
    /// </summary>
    [JsonIgnore]
    public string? FilterDateTo { get; set; }

    /// <summary>
    /// The document file type.
    /// </summary>
    [JsonIgnore]
    public FileType? FilterFileType { get; set; }

    /// <summary>
    /// Number of items per page. Defaults to 10 if not specified and maximum value allowed 100 items per page.
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Cursor for forward pagination (next page).
    /// </summary>
    [JsonIgnore]
    public string? PageAfter { get; set; }

    /// <summary>
    /// Cursor for backward pagination (previous page).
    /// </summary>
    [JsonIgnore]
    public string? PageBefore { get; set; }

    /// <summary>
    /// If provided, response will be sorted by the specified fields. Defaults to descending sentDate, equivalent to "-sentDate"
    /// </summary>
    [JsonIgnore]
    public IEnumerable<FilesMetadataSortOptions> Sort { get; set; } =
        new List<FilesMetadataSortOptions>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
