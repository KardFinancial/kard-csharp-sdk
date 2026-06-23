using KardFinancial;
using OneOf;

namespace KardFinancial.Users;

public partial interface IRewardsClient
{
    /// <summary>
    /// Retrieve national brand offers that a specified user is eligible for. Call this endpoint to build out your
    /// [targeted offers UX experience](/2024-10-01/api/getting-started#b-discover-a-lapsed-customer-clo). Local offers details
    /// can be found by calling the [Get Eligible Locations](/2024-10-01/api/rewards/locations).<br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    WithRawResponseTask<OffersResponseObject> OffersAsync(
        string organizationId,
        string userId,
        GetOffersByUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the content for a placement. The placement type is resolved
    /// server-side so callers no longer pick an endpoint by placement type.
    /// Returns a JSON:API document whose `data` resources are self-describing
    /// by `type`: a standard placement returns `standardOffer` resources (with
    /// `links`, optional `included` categories, and `meta`); a batch-activation
    /// or group placement returns `placementBatch` slot resources. Distinguish
    /// the two by each resource's `type`. Email and push-notification
    /// placements are not servable through this endpoint and respond with a
    /// `400`.<br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    WithRawResponseTask<OneOf<OffersResponseObject, BatchesResponseObject>> PlacementContentAsync(
        string organizationId,
        string userId,
        string placementId,
        GetPlacementContentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve national and local geographic locations that a specified user has eligible in-store offers at. Use this endpoint to build
    /// out your [map-specific UX experiences](/2024-10-01/api/getting-started#c-discover-clos-near-you-map-view). Please note
    /// that Longitude and Latitude fields are prioritized over State, City and Zipcode and are the recommended search
    /// pattern.<br/>
    /// <br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    WithRawResponseTask<LocationsResponseObject> LocationsAsync(
        string organizationId,
        string userId,
        GetLocationsByUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
