using KardFinancial;

namespace KardFinancial.Organizations;

public partial interface IChildrenClient
{
    /// <summary>
    /// List child organizations belonging to the authenticated issuer
    /// </summary>
    WithRawResponseTask<ChildOrganizationListResponse> ListAsync(
        string organizationId,
        ListChildrenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a child organization by cloning the parent and overriding specified fields. An 8-digit numeric ID is generated automatically. The name is required, must contain at least one letter, and may contain only letters and spaces.
    /// </summary>
    WithRawResponseTask<ChildOrganizationResponse> CreateAsync(
        string organizationId,
        CreateChildRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific child organization
    /// </summary>
    WithRawResponseTask<ChildOrganizationResponse> GetAsync(
        string organizationId,
        string childId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a child organization. Only the name can be changed.
    /// </summary>
    WithRawResponseTask<ChildOrganizationResponse> UpdateAsync(
        string organizationId,
        string childId,
        UpdateChildRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a child organization
    /// </summary>
    WithRawResponseTask<DeleteResourceResponse> DeleteAsync(
        string organizationId,
        string childId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
