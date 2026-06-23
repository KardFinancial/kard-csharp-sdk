using KardFinancial;

namespace KardFinancial.Users;

public partial interface IAttributionsClient
{
    /// <summary>
    /// Call this endpoint to send attribution events made by a single enrolled user for processing. A maximum of 100 events can be included in a single request.
    ///
    /// <b>Required scopes:</b> `attributions:write`
    /// </summary>
    WithRawResponseTask<CreateAttributionResponse> CreateAsync(
        string organizationId,
        string userId,
        CreateAttributionRequestObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Record when a user activates an offer. Creates an attribution event with eventCode=ACTIVATE and medium=CTA.
    /// Optionally include the offer data by passing `include=offer`.
    /// </summary>
    WithRawResponseTask<ActivateOfferResponse> ActivateAsync(
        string organizationId,
        string userId,
        string offerId,
        ActivateOfferRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Record when a user boosts an offer. Creates an attribution event with eventCode=BOOST and medium=CTA.
    /// Optionally include the offer data by passing `include=offer`.
    /// </summary>
    WithRawResponseTask<BoostOfferResponse> BoostAsync(
        string organizationId,
        string userId,
        string offerId,
        BoostOfferRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Record when a user activates a batch-activation placement slot. Writes a slot-level
    /// `placementSlotAttribution` ACTIVATE event and fans out a per-offer
    /// `offerAttribution` ACTIVATE event for every offer resolved by the slot's content
    /// strategy. The slot-level event id and the resolved `offerIds` are returned so the
    /// partner can render the batch immediately without an extra round-trip to re-fetch
    /// the placement content.
    ///
    /// <b>Required scopes:</b> `attributions:write`
    /// </summary>
    WithRawResponseTask<ActivatePlacementSlotResponse> ActivatePlacementSlotAsync(
        string organizationId,
        string userId,
        string placementId,
        string slotId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
