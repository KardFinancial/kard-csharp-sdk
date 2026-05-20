using KardFinancial;

namespace KardFinancial.Organizations;

public partial interface IPlacementsClient
{
    /// <summary>
    /// Create a placement for the organization. Use type "placementMainPage" for main-page placements (requires name and availableSlots) or "placementPushNotification" for push-notification placements (requires name and cadence; availableSlots is automatically set to 1).
    /// </summary>
    WithRawResponseTask<PlacementFormatUnion> CreateAsync(
        string organizationId,
        CreatePlacementRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List placements belonging to the authenticated organization
    /// </summary>
    WithRawResponseTask<PlacementListResponse> ListAsync(
        string organizationId,
        ListPlacementsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific placement
    /// </summary>
    WithRawResponseTask<PlacementResource> GetAsync(
        string organizationId,
        string placementId,
        GetPlacementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a placement. All fields must be provided. Use type "placementMainPage" or "placementPushNotification" to set the placement kind. If the type is "placementPushNotification", availableSlots is automatically set to 1.
    /// </summary>
    WithRawResponseTask<PlacementFormatUnion> UpdateAsync(
        string organizationId,
        string placementId,
        UpdatePlacementRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a placement
    /// </summary>
    WithRawResponseTask<DeleteResourceResponse> DeleteAsync(
        string organizationId,
        string placementId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
