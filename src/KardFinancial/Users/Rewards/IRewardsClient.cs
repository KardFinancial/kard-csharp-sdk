using KardFinancial;

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
    /// Retrieve offers for a placement slot. Returns offers sorted by highest cash back,
    /// limited by the placement's available slots.<br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    WithRawResponseTask<OffersResponseObject> PlacementOffersAsync(
        string organizationId,
        string userId,
        string placementId,
        GetOffersByPlacementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve batches for a batch-activation or group placement. Returns each
    /// slot in slot order with its current offer set, alias, and freshness fields
    /// (`isActive`, `lastActivatedAt`, `expiresAt`). Applies the same per-user
    /// eligibility and per-slot content-strategy filter as Get Offers By
    /// Placement, independently per slot. For a batch-activation placement, a
    /// slot only flips to `isActive: false` when its refresh interval has elapsed
    /// AND its post-eligibility `offers[]` is non-empty; otherwise the slot is
    /// still returned and stays active so the partner UI does not promote
    /// "refresh" with nothing to show. For a group placement, slots are always
    /// active and each slot returns its offers regardless of activation state,
    /// hiding only offers that require activation (`requiredInBatch`) and have
    /// no activation record.<br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    WithRawResponseTask<BatchesResponseObject> PlacementBatchesAsync(
        string organizationId,
        string userId,
        string placementId,
        GetBatchesByPlacementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the content for a placement. The placement type is resolved
    /// server-side so callers no longer pick an endpoint by placement type.
    /// Returns a JSON:API document whose `data` resources are self-describing
    /// by `type`: a standard placement returns `standardOffer` resources (the
    /// same payload as Get Offers By Placement — with `links`, optional
    /// `included` categories, and `meta`); a batch-activation or group
    /// placement returns `placementBatch` slot resources (the same payload as
    /// Get Batches By Placement). Distinguish the two by each resource's
    /// `type`. Email and push-notification placements are not servable through
    /// this endpoint and respond with a `400`.<br/>
    /// <b>Required scopes:</b> `rewards:read`
    /// </summary>
    WithRawResponseTask<PlacementContentResponse> PlacementContentAsync(
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
