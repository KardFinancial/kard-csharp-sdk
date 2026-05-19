using KardFinancial;

namespace KardFinancial.Organizations;

public partial interface IContentStrategiesClient
{
    /// <summary>
    /// Create a content strategy for the organization. The strategy name must be unique within the organization.
    /// </summary>
    WithRawResponseTask<ContentStrategyResponse> CreateAsync(
        string organizationId,
        CreateContentStrategyRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List content strategies belonging to the authenticated organization
    /// </summary>
    WithRawResponseTask<ContentStrategyListResponse> ListAsync(
        string organizationId,
        ListContentStrategiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific content strategy
    /// </summary>
    WithRawResponseTask<ContentStrategyResponse> GetAsync(
        string organizationId,
        string contentStrategyId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a content strategy. All fields must be provided; any omitted attribute is treated as cleared.
    /// </summary>
    WithRawResponseTask<ContentStrategyResponse> UpdateAsync(
        string organizationId,
        string contentStrategyId,
        UpdateContentStrategyRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a content strategy. Returns 409 if the strategy is still referenced by another resource.
    /// </summary>
    WithRawResponseTask<DeleteResourceResponse> DeleteAsync(
        string organizationId,
        string contentStrategyId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
