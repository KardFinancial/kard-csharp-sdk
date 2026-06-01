## 13.0.0 - 2026-06-01
### Breaking Changes
* **`PlacementBatchAttributes.ShortDescription`** — removed; any code that constructs or reads this `required string` property must be updated. The equivalent copy is now available via `PlacementBatchAttributes.Components` (`OfferComponents`), which now carries `shortDescription` derived from the parent placement's `refreshInterval`.
* **`PlacementBatchAttributes.LongDescription`** — removed; any code that constructs or reads this `required string` property must be updated. The equivalent copy is now available via `PlacementBatchAttributes.Components` (`OfferComponents`), which now carries `longDescription` describing the slot's activation behavior.

## 12.0.0 - 2026-06-01
### Breaking Changes
* **`PlacementBatchAttributes.ShortDescription`** — new `required string` property added; any code that constructs `PlacementBatchAttributes` directly must now supply a `ShortDescription` value.
* **`PlacementBatchAttributes.LongDescription`** — new `required string` property added; any code that constructs `PlacementBatchAttributes` directly must now supply a `LongDescription` value.

## 11.0.0 - 2026-06-01
### Breaking Changes
* **`BatchSlotData`** — removed; replace all usages with the new `PlacementBatchData` record, which wraps batch slot data in a JSON:API envelope exposing `Id`, `Type`, and `Attributes`.
* **`BatchesResponseObject.Data`** — element type changed from `IEnumerable<BatchSlotData>` to `IEnumerable<PlacementBatchData>`; update any code that iterates or assigns this collection.
* **`BatchSlotData.SlotId`** and **`BatchSlotData.Alias`** — removed; the equivalent data is now available as `PlacementBatchAttributes.Name` (accessible via `PlacementBatchData.Attributes.Name`).
### Added
* **`PlacementBatchData`** — new JSON:API-shaped record representing one slot in a batch-activation placement, with required `Id`, `Type`, and `Attributes` properties.
* **`PlacementBatchAttributes`** — new record (replacing `BatchSlotData`) carrying slot-level attributes including the new `Name` field plus all existing freshness, component, asset, and offer fields.

## 10.0.0 - 2026-06-01
### Added
* **`IncludedResource`** — new discriminated union representing every resource type that can appear in a JSON:API `included` array, with `Match`, `Visit`, `TryAs*`, and `As*` accessor methods for `contentStrategy`, `batchActivationSlot`, `placementMainPage`, and `placementPushNotification` variants.
* **`PlacementRelationships`** — new record exposing the JSON:API relationship block on non-batch placements, including an optional `ContentStrategy` (`ToOneRelationship?`) link.
* **`ToOneRelationship`** and **`ToManyRelationship`** — new JSON:API relationship payload records carrying a `ResourceIdentifier` (or list thereof) to the linked resource.
* **`ResourceIdentifier`** — new record representing a JSON:API resource reference by `Type` and `Id`.
* **`MainPagePlacementData.Relationships`** and **`PushNotificationPlacementData.Relationships`** — new optional `PlacementRelationships?` properties exposing linked resources for each placement type.

## 9.2.0 - 2026-05-28
### Added
* **`BatchSlotData.Components`** — new optional `OfferComponents?` property exposing slot-level UI components, including a `cta` (when the slot has no active activation) or a `logoFlare` decoration (when it does).
* **`BatchSlotData.Assets`** — new optional `IEnumerable<Asset>?` property exposing slot-level visual assets such as the slot's initials SVG.

## 9.1.0 - 2026-05-28
### Added
* **`GetEarnedRewardsRequest.FilterPaidInFullOnly`** — new optional `bool?` property that, when `true`, restricts the `GetEarnedRewards` response to transactions paid in full to the issuer (`paidToIssuer` is `PAID_IN_FULL`) and limits `lifetimeRewardsInCents` to only those transactions.

## 9.0.1 - 2026-05-28
* chore: update child organization name validation docs and tests
* Reflect the relaxed naming rule for child organizations: names no longer
* need to be uppercase with no spaces — they now require at least one
* letter and may contain only letters and spaces.
* Key changes:
* Update XML doc comments on `ChildOrganizationAttributes`, `CreateChildAttributes`, and `UpdateChildAttributes` to describe the new name constraint
* Update `IChildrenClient` and `ChildrenClient` summary comments to match the new validation rule
* Update serialization test fixtures in `CreateChildAttributesTest` and `UpdateChildAttributesTest` to use mixed-case names with spaces (e.g. "Acme Child Bank")
* 🌿 Generated with Fern

## 9.0.0 - 2026-05-27
### Breaking Changes
* **`EarnedRewardRelationships`** — a new required `Offer` property (`RelationshipSingle`) has been added; any object initializer that constructs `EarnedRewardRelationships` without supplying `Offer` will produce a compile error. Add `Offer = new RelationshipSingle { Data = new RelationshipData { Type = "offer", Id = "<your-offer-id>" } }` to every construction site to fix the error.

## 8.0.1 - 2026-05-27
* chore: update XML doc comment links in UploadsClient
* Update deprecated API documentation links in UploadsClient and
* IUploadsClient to use versioned URL paths, ensuring references point
* to the correct 2024-10-01 API documentation endpoints.
* Key changes:
* Update "Add Upload Part" link from `/api/uploads/create-upload-part` to `/2024-10-01/api/transactions/uploads/create-part`
* Update "Create Upload" link from `/api/uploads/create-upload` to `/2024-10-01/api/transactions/uploads/create`
* Apply same doc link corrections to both `IUploadsClient` interface and `UploadsClient` implementation
* 🌿 Generated with Fern

## 8.0.0 - 2026-05-26
### Breaking Changes
* **`CreateAttributionRequestUnion.Match`** and **`CreateAttributionRequestUnion.Visit`** — a new required `onPlacementSlotAttribution` delegate parameter was added; add a handler for the `placementSlotAttribution` case at every call site to fix compile errors.
### Added
* **`AttributionsClient.ActivatePlacementSlotAsync`** — new method to record a slot-level ACTIVATE event for a batch-activation placement, fanning out per-offer `offerAttribution` ACTIVATE events and returning the slot-level event id and resolved `offerIds`.
* **`ActivatePlacementSlotResponse`**, **`ActivatePlacementSlotResponseData`**, and **`ActivatePlacementSlotResponseAttributes`** — new response record types representing the acknowledgement payload from a slot activation request.
* **`PlacementSlotAttributionRequest`** and **`PlacementSlotAttributionAttributes`** — new request record types for submitting a slot-level attribution event via `CreateAttributionRequestUnion`.
* **`PlacementSlotMedium`** — new string enum type with value `CTA` for specifying the medium on a slot attribution event; **`AttributionState`** also gains optional `PlacementId` and `SlotId` properties.

## 7.1.0 - 2026-05-26
### Added
* **`RewardsClient.PlacementBatchesAsync`** — new method to retrieve batches for a batch-activation placement, returning each slot in slot order with its current offer set, alias, and freshness fields (`IsActive`, `LastActivatedAt`, `ExpiresAt`).
* **`GetBatchesByPlacementRequest`** — new request record with an optional `SupportedComponents` property for filtering UI component types included in the response.
* **`BatchesResponseObject`** — new response record containing an ordered `Data` list of `BatchSlotData` items representing each slot in the placement.
* **`BatchSlotData`** — new record type exposing slot identity (`SlotId`, `Alias`), freshness state (`IsActive`, `LastActivatedAt`, `ExpiresAt`), and the per-slot `Offers` collection.

## 7.0.0 - 2026-05-26
### Breaking Changes
* **`PlacementFormatUnion.Match`** and **`PlacementFormatUnion.Visit`** — a new required `onPlacementBatchActivation` delegate parameter was added; add a handler for the `placementBatchActivation` case at every call site to fix compile errors.
* **`CreatePlacementDataUnion.Match`** and **`CreatePlacementDataUnion.Visit`** — same required `onPlacementBatchActivation` delegate parameter added; update all call sites accordingly.
* **`UpdatePlacementDataUnion.Match`** and **`UpdatePlacementDataUnion.Visit`** — same required `onPlacementBatchActivation` delegate parameter added; add a `Func<UpdateBatchActivationPlacementData, T>` or `Action<UpdateBatchActivationPlacementData>` handler at every call site.
### Added
* **`BatchActivationPlacementData`**, **`BatchActivationPlacementAttributes`**, and **`BatchActivationSlot`** — new response record types representing a batch-activation placement returned from the API.
* **New request record types for batch-activation placements** — `CreateBatchActivationPlacementData`, `CreateBatchActivationAttributes`, `CreateBatchActivationSlot`, `UpdateBatchActivationPlacementData`, `UpdateBatchActivationAttributes`, and `UpdateBatchActivationSlot` added for creating and updating batch-activation placements.
* **`UpdatePlacementDataUnion.PlacementBatchActivation`** — new discriminated union variant wrapping `UpdateBatchActivationPlacementData`, with companion members `IsPlacementBatchActivation`, `AsPlacementBatchActivation()`, and `TryAsPlacementBatchActivation()`.
* **`PlacementTypeFilter.PlacementBatchActivation`** — new enum constant for filtering placements by the `placementBatchActivation` type.

## 6.1.0 - 2026-05-22
### Added
* **`ProgressBarSegment.Separator`** — new optional `ProgressBarSegmentSeparator?` property specifying the separator style rendered between segment nodes.
* **`ProgressBarSegment.Labels`** — new optional `IEnumerable<ProgressBarSegmentLabel>?` property providing label configuration for each node in the segment.
* **`ProgressBarSegment.Selection`** — new optional `ProgressBarSegmentSelection?` property indicating which segment nodes the UI should render as selected based on `currentProgress`.
* **`ProgressBarSegmentLabel`** — new record type with required `Title` and `Description` string properties for labeling individual segment nodes.
* **`ProgressBarSegmentSeparator`** and **`ProgressBarSegmentSelection`** — new string enum types with values `LINE` and `CURRENT`/`CURRENT_AND_BELOW` respectively.

## 6.0.0 - 2026-05-21
### Breaking Changes
* **`ContentStrategyFilter`** — renamed to `ContentStrategySort`; replace all references to `ContentStrategyFilter` with `ContentStrategySort` in your code.
* **`ContentStrategyAttributes.Filter`** — renamed to `Sort` (`ContentStrategySort?`); update any reads or assignments from `.Filter` to `.Sort`.
* **`CreateContentStrategyAttributes.Filter`** — renamed to `Sort` (`ContentStrategySort?`); update assignments (e.g. `Filter = ContentStrategyFilter.HighestCashback`) to `Sort = ContentStrategySort.HighestCashback`.
* **`UpdateContentStrategyAttributes.Filter`** — renamed to `Sort` (`ContentStrategySort?`); apply the same migration as `CreateContentStrategyAttributes`.

## 5.0.0 - 2026-05-20
### Breaking Changes
* **`ContentStrategyAttributes.CreatedAt`** and **`ContentStrategyAttributes.LastModified`** — removed required properties. Remove any assignments or reads of these fields from your code.
* **`MainPagePlacementAttributes.CreatedAt`** and **`MainPagePlacementAttributes.LastModified`** — removed required properties. Remove any assignments or reads of these fields from your code.
* **`PushNotificationPlacementAttributes.CreatedAt`** and **`PushNotificationPlacementAttributes.LastModified`** — removed required properties. Remove any assignments or reads of these fields from your code.
* **`PlacementsClient.GetAsync`** — return type changed from `PlacementFormatUnion` to `PlacementResource`, and a new required `GetPlacementRequest` parameter was added. Update call sites to pass `new GetPlacementRequest()` and access the placement via `.Data` on the returned `PlacementResource`.
### Added
* **`PlacementResource`** — new response type for `GetAsync` that wraps the placement in a `Data` property and exposes an optional `Included` array of sideloaded `ContentStrategyResponse` objects.
* **`GetPlacementRequest`** — new request type for `GetAsync` with an optional `Include` property to request embedded content strategies (`include=contentStrategy`).
* **`ListPlacementsRequest.Include`** — new optional property to request sideloaded content strategies when listing placements.
* **`PlacementListResponse.Included`** — new optional property containing embedded `ContentStrategyResponse` objects when `include=contentStrategy` is supplied.

## 4.0.0 - 2026-05-20
### Breaking Changes
* **`ContentStrategyAttributes.Filters`** — removed; replaced by `Filter` (`ContentStrategyFilter?`). Update any code that assigned or read the `Filters` list to use the new single `Filter` property instead.
* **`CreateContentStrategyAttributes.Filters`** — removed; replaced by `Filter` (`ContentStrategyFilter?`). Replace list assignments (e.g. `Filters = new List<ContentStrategyFilter> { ... }`) with a single value assignment (e.g. `Filter = ContentStrategyFilter.HighestCashback`).
* **`UpdateContentStrategyAttributes.Filters`** — removed; replaced by `Filter` (`ContentStrategyFilter?`). Apply the same migration as `CreateContentStrategyAttributes`.

## 3.2.0 - 2026-05-19
### Added
* **`ContentStrategyId`** — new optional property on `MainPagePlacementAttributes`, `PushNotificationPlacementAttributes`, `CreateMainPageAttributes`, `CreatePushNotificationAttributes`, `UpdateMainPageAttributes`, and `UpdatePushNotificationAttributes` for linking a placement to a content strategy.
* **`ListPlacementsRequest.FilterContentStrategyId`** — new optional filter parameter to narrow placement list results by the ID of a linked content strategy.

## 3.1.0 - 2026-05-19
### Added
* **`ContentStrategiesClient`** — new sub-client accessible via `client.Organizations.ContentStrategies` supporting full CRUD operations (`CreateAsync`, `ListAsync`, `GetAsync`, `UpdateAsync`, `DeleteAsync`) for managing named offer-selection strategies scoped to an organization.
* **`ContentStrategyFilter`** — new string enum with values `NewlyLive`, `ExpiringSoon`, `HighestCashback`, and `Personalized` for configuring which offers a content strategy surfaces.
* **`ContentStrategyAttributes`** / **`ContentStrategyResponse`** — new types representing a content strategy resource, including its `Id`, `Name`, `OrganizationId`, `Filters`, `Categories`, exclusion lists, and timestamps.
* **`CreateContentStrategyAttributes`** / **`UpdateContentStrategyAttributes`** — new attribute types (and their corresponding request body wrappers) for creating and updating content strategies.
* **`ListContentStrategiesRequest`** / **`ContentStrategyListResponse`** — new request and paginated response types for listing content strategies, supporting `FilterName`, `PageAfter`, and `PageSize` query parameters.

## 3.0.0 - 2026-05-14
### Breaking Changes
* **`LocationAttributes.PartnerIds`** — property type changed from `IEnumerable<LocationPartnerId>?` (nullable) to `IEnumerable<LocationPartnerId>` (non-nullable, defaults to an empty list); remove any null checks or null-conditional access (`?.`) on this property, and update any code that assigned `null` to it.

## 2.0.0 - 2026-05-14
### Breaking Changes
* **`EarnedRewardAttributes`** — class has been removed; update any references to use `RewardNotificationAttributes` instead.
* **`EarnedRewardApprovedData.Attributes`** — property type changed from `EarnedRewardAttributes` to `RewardNotificationAttributes`; update object initializers and type references accordingly.
* **`RewardNotificationAttributes`** — two new required properties added: `TransactionId` (`string`) and `TransactionAmountInCents` (`int`); existing object initializers must supply both values.
* **`ValidTransactionAttributes`** — two new required properties added: `TransactionId` (`string`) and `TransactionAmountInCents` (`int`); existing object initializers must supply both values.
* **`EarnedRewardSettledAttributes`** — two new required properties added: `TransactionId` (`string`) and `TransactionAmountInCents` (`int`); existing object initializers must supply both values.

## 1.1.0 - 2026-05-12
### Added
* **`LocationPartnerId`** — new type representing a third-party partner identifier (e.g. a Google place ID) associated with a location.
* **`LocationPartnerIdType`** — new string enum type with a `Google` constant, used to identify the partner source on a `LocationPartnerId`.
* **`LocationAttributes.PartnerIds`** — new optional property (`IEnumerable<LocationPartnerId>?`) exposing partner IDs on LOCAL locations.

## 1.0.1 - 2026-05-07
* chore: update required scope for CreateBulkTransactionsUploadUrlAsync
* Correct the documented required OAuth scope for the
* `CreateBulkTransactionsUploadUrlAsync` method. The scope was previously
* listed as `transaction:write` but the correct required scope is
* `files:write`. This is a documentation-only fix with no change to the
* public API surface or runtime behavior.
* Key changes:
* Updated XML doc comment in `ITransactionsClient` to reflect `files:write` scope
* Updated XML doc comment in `TransactionsClient` to reflect `files:write` scope
* 🌿 Generated with Fern

