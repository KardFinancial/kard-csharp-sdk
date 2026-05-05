using global::System.Text.Json.Serialization;
using Kard.Core;

namespace Kard.Organizations;

[Serializable]
public record ListChildrenRequest
{
    /// <summary>
    /// Cursor value for the next page of results
    /// </summary>
    [JsonIgnore]
    public string? PageAfter { get; set; }

    /// <summary>
    /// Maximum number of records to return [1 - 200] (default = 200)
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
