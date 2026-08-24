## 24.2.0 - 2026-08-24
### Added
* **`PlacementStatus`** — new string-enum struct in the `KardFinancial.Organizations` namespace representing whether a placement is active or inactive, with built-in constants `PlacementStatus.Active` and `PlacementStatus.Inactive`.
* **`PlacementAttributes.Status`**, **`EmailPlacementAttributes.Status`**, **`GroupPlacementAttributes.Status`**, **`PushNotificationPlacementAttributes.Status`**, and **`BatchActivationPlacementAttributes.Status`** — new required `PlacementStatus` property on all response-side placement attribute records indicating whether the placement currently serves content.
* **`Status`** on all create and update placement attribute types (e.g. `CreateStandardAttributes`, `UpdateEmailAttributes`) — new optional `PlacementStatus?` property; defaults to `ACTIVE` on create and preserves the existing status when omitted on update.

## 24.1.0 - 2026-08-18
### Added
* **`CuisineOption`** — new string-enum struct in the `KardFinancial` namespace representing the kind of food or venue a location offers, with 140+ built-in constants (e.g. `CuisineOption.Pizza`, `CuisineOption.Sushi`, `CuisineOption.Brewery`).
* **`LocationRating`** — new record in the `KardFinancial.Users` namespace carrying a `Value` (1–5 scale) and an optional `Count` representing the number of ratings a score is based on.
* **`LocationAttributes.Cuisine`** — new optional `CuisineOption?` property indicating the venue category for a location.
* **`LocationAttributes.Rating`** — new optional `LocationRating?` property carrying the customer rating for a location.
* **`LocationAttributes.PriceLevel`** — new optional `int?` property indicating the typical price range (1 = least expensive, 4 = most expensive).

## 24.0.1 - 2026-08-07
* chore: update XML doc comments for GetLocationsByUserRequest and RewardsClient
* Improve inline documentation for the `GetLocationsByUserRequest` record
* and the `GetLocationsByUser` method in both `RewardsClient` and
* `IRewardsClient`. No public API surface was added, removed, or changed.
* Key changes:
* Added XML `<summary>` doc comments to `FilterCity`, `FilterZipCode`, `FilterState`, `FilterLongitude`, `FilterLatitude`, and `FilterRadius` properties on `GetLocationsByUserRequest`, clarifying their roles and constraints
* Removed the outdated note about Longitude/Latitude being prioritized over State, City, and Zipcode from the `GetLocationsByUser` method summary in both `RewardsClient` and `IRewardsClient`
* 🌿 Generated with Fern

## 24.0.0 - 2026-08-05
### Breaking Changes
* **`ExternalOrganizationAttributes.CardNetworks`** — property type changed from `IEnumerable<CardNetwork>` to `IEnumerable<OrganizationCardNetwork>`; update all call sites that read, assign, or iterate this property to use `OrganizationCardNetwork` instead of `CardNetwork`.
### Added
* **`OrganizationCardNetwork`** — new string-enum struct in the `KardFinancial` namespace representing card networks supported by an organization, with built-in constants `Visa`, `Mastercard`, `AmericanExpress`, and `Discover`.

## 23.0.0 - 2026-08-05
### Breaking Changes
* **`ButtonStyle`**, **`CtaAction`**, **`CtaComponent`**, **`LogoFlare`**, **`LogoFlareBadge`**, **`LogoFlareBadgePosition`**, **`LogoFlareBorderColor`**, **`OfferComponents`**, **`ProgressBar`**, **`ProgressBarLabelPair`**, **`ProgressBarLabels`**, **`ProgressBarSegment`**, **`ProgressBarSegmentLabel`**, **`ProgressBarSegmentPosition`**, **`ProgressBarSegmentProgress`**, **`ProgressBarSegmentSelection`**, **`ProgressBarSegmentSeparator`**, and **`ProgressBarSegments`** — moved from the `KardFinancial.Users` namespace to the root `KardFinancial` namespace; update all `using KardFinancial.Users;` directives to `using KardFinancial;` at any call site that references these types.
### Added
* **`RewardedTransactionAttributes.Components`** — new optional `OfferComponents?` property carrying UI component data (e.g. a progress bar for progressive and punch-card offers) built from the offer state persisted on the matched transaction; omitted when the reward carries no persisted state.

## 22.0.0 - 2026-08-04
### Breaking Changes
* **`ClawbackData`** — public record class removed; callers that reference or construct this type must remove all usages.
* **`FailedTransactionData`**, **`FailedTransactionAttributes`**, and **`FailedTransactionRelationships`** — public record classes removed; update any references to remove usages of these types.
* **`ValidTransactionData`**, **`ValidTransactionAttributes`**, **`ValidTransactionCommissionEarned`**, and **`TransactionRelationships`** — public record classes removed; update any references to remove usages of these types.
* **`NotificationDataUnion.ValidTransaction`**, **`NotificationDataUnion.FailedTransaction`**, and **`NotificationDataUnion.Clawback`** — inner structs and all related members (`IsValidTransaction`, `IsFailedTransaction`, `IsClawback`, `AsValidTransaction()`, `AsFailedTransaction()`, `AsClawback()`, `TryAsValidTransaction()`, `TryAsFailedTransaction()`, `TryAsClawback()`, implicit operators, and the corresponding constructor overloads) removed; update all call sites to remove these branches.
* **`NotificationDataUnion.Match<T>`** and **`NotificationDataUnion.Visit`** — the `onValidTransaction`, `onFailedTransaction`, and `onClawback` parameters have been removed from both overloads; update all call sites to remove these arguments.

## 21.0.0 - 2026-08-04
### Breaking Changes
* **`MatchedTransactionsRequest`** — public record class removed; callers that construct or reference this type must migrate to `TransactionsRequest` or `CoreTransactionRequest`.
* **`MatchedTransactionsAttributes`** — public record class removed alongside `MatchedTransactionsRequest`; all properties (e.g. `UserId`, `PaymentType`, `ReceiptMedium`) are no longer available through this type.
* **`PaymentType`** — string enum (`CARD`, `CASH`, `UNKNOWN`) removed; update any references to remove usages of this type.
* **`ReceiptMediumType`** — string enum (`ELECTRONIC`, `PHYSICAL`) removed; update any references to remove usages of this type.
* **`Transactions.MatchedTransaction`** — inner struct and all related members (`IsMatchedTransaction`, `AsMatchedTransaction()`, `TryAsMatchedTransaction()`, implicit operator, and the `onMatchedTransaction` parameter in `Match<T>` and `Visit`) removed; update all call sites to remove the `matchedTransaction` branch.

## 20.0.0 - 2026-08-03
### Breaking Changes
* **`NotificationType.ValidTransaction`** — constant removed; update any references to use a remaining supported `NotificationType` value or a custom value via `new NotificationType("validTransaction")`.
* **`NotificationType.FailedTransaction`** — constant removed; update any references to use a remaining supported `NotificationType` value or a custom value via `new NotificationType("failedTransaction")`.
* **`NotificationType.Clawback`** — constant removed; update any references to use a remaining supported `NotificationType` value or a custom value via `new NotificationType("clawback")`.
* **`NotificationType.Values.ValidTransaction`**, **`Values.FailedTransaction`**, and **`Values.Clawback`** string constants removed alongside their parent fields.

## 19.1.0 - 2026-08-03
### Added
* **`NotificationMedium.Email`** — new constant (`"EMAIL"`) added to the `NotificationMedium` string enum, enabling email as a supported notification delivery channel alongside the existing `Push` value.

## 19.0.0 - 2026-07-29
### Breaking Changes
* **`EarnedRewardRejectedAttributes.Reason`** — property type changed from `string` to `RejectedReason`; update assignments and comparisons to use `RejectedReason` values (e.g. `RejectedReason.AggregatorCardOverlap`) or access the underlying string via `.Value`.
### Added
* **`RejectedReason`** — new strongly-typed string enum with constants `AggregatorCardOverlap` (`"AGGREGATOR_CARD_OVERLAP"`), `SettlementRejected` (`"SETTLEMENT_REJECTED"`), `UserNotEnrolled` (`"USER_NOT_ENROLLED"`), and `UserNotInAudienceSegment` (`"USER_NOT_IN_AUDIENCE_SEGMENT"`); supports custom values via `RejectedReason.FromCustom(string)`.

## 18.1.0 - 2026-07-28
### Added
* **`EarnedRewardsRange`** — new string enum type with constants `Last12Months` (`12M`), `Last6Months` (`6M`), `Last3Months` (`3M`), and `YearToDate` (`YTD`), representing the supported time-window values for the earned-rewards filter.
* **`GetEarnedRewardsRequest.FilterRange`** — new optional property that maps to the `filter[range]` query parameter, letting callers narrow the returned transaction window to the last 6 months, last 3 months, or year-to-date instead of the default 12-month window.
### Changed
* **`GetEarnedRewardsMeta.LifetimeRewardsInCents`** — the aggregate total is now scoped to the window selected by `filter[range]` (defaulting to the last 12 months), so the meta total always matches the rows returned in the response.

## 18.0.0 - 2026-07-15
### Breaking Changes
* **`ContentStrategyAttributes.Filters`**, **`CreateContentStrategyAttributes.Filters`**, and **`UpdateContentStrategyAttributes.Filters`** — a new `required ContentStrategyFilters Filters` property has been added to all three types; existing object initializers that omit `Filters` will fail to compile. Add `Filters = new ContentStrategyFilters()` (with any desired filter values) to each affected initializer.
### Added
* **`ContentStrategyFilters`** — new record type representing offer-selection filters for a content strategy, with optional `Categories`, `CategoryExclusions`, `MerchantExclusions`, and `OfferFeatures` properties.
* **`OfferFeatures`** — new string enum type with the `Interactive` ("INTERACTIVE") constant, used to filter offers by feature when building a `ContentStrategyFilters`.

## 17.0.0 - 2026-07-15
### Breaking Changes
* **`EarnedRewardApprovedData.Attributes`** — property type changed from `RewardNotificationAttributes` to `EarnedRewardNotificationAttributes`; update any variable declarations or pattern matches that reference `RewardNotificationAttributes` to use `EarnedRewardNotificationAttributes` instead.
### Added
* **`EarnedRewardNotificationAttributes`** — new type replacing `RewardNotificationAttributes` for earned-reward notification attributes, with all existing fields plus new optional `CategoryName`, `UserReward`, `Assets`, and `PurchaseChannel` properties.
* **`UserReward`** — new record type representing the reward commission on a notification, with required `Type` (`CommissionType`) and `Value` (`double`) properties.
* **`EarnedRewardSettledAttributes.CategoryName`**, **`.UserReward`**, **`.Assets`**, and **`.PurchaseChannel`** — new optional enrichment fields added to settled-reward notification attributes, mirroring the fields on `EarnedRewardNotificationAttributes`.

## 16.0.0 - 2026-07-15
### Breaking Changes
* **`NotificationDataUnion.Match<T>()`** and **`NotificationDataUnion.Visit()`** now require a new `onEarnedRewardRejected` delegate parameter. Add a handler for `EarnedRewardRejectedData` at the appropriate position in each call site.
### Added
* **`EarnedRewardRejectedData`** — new notification data type representing a rejected earned reward, with `Id`, `Attributes`, and `Relationships` properties.
* **`EarnedRewardRejectedAttributes`** — new type carrying the rejection `Reason`, `Message`, `TransactionId`, `TransactionAmountInCents`, and `TransactionTimestamp` for a rejected reward notification.
* **`RejectedTransactionRelationships`** — new type holding `User` and `Transaction` relationship references for rejected reward notifications.
* **`NotificationType.EarnedRewardRejected`** — new constant (`"earnedRewardRejected"`) added to `NotificationType`, and `NotificationDataUnion` gains `IsEarnedRewardRejected`, `AsEarnedRewardRejected()`, and `TryAsEarnedRewardRejected()` members.

## 15.3.0 - 2026-07-10
### Added
* **`ContentStrategySort.OffersNearYou`** — new enum value (`"OFFERS_NEAR_YOU"`) added to `ContentStrategySort`, allowing content strategies to be sorted by proximity-based offer recommendations.

## 15.2.0 - 2026-07-02
### Added
* **`ProgressBarSegmentProgress`** — new type representing the fill state of a single progress bar segment node, with `Completed` and `Total` integer properties.
* **`ProgressBarSegments.Progress`** — new optional property (`IEnumerable<ProgressBarSegmentProgress>`) exposing per-segment fill state, index-aligned with segment nodes; supports punch-card offer progress tracking.

## 15.1.1 - 2026-07-02
* chore: update FilterSearch XML doc comment in GetOffersByUserRequest
* Clarify the description of the `FilterSearch` property on
* `GetOffersByUserRequest` to reflect that it performs a case-insensitive
* substring search across both offer name and category name, not just
* merchant name.
* Key changes:
* Updated XML doc comment on `FilterSearch` from "Case-insensitive search string to filter offers by merchant name" to "Case-insensitive substring search. Returns offers whose offer name or category name contains the search string."
* 🌿 Generated with Fern

## 15.1.0 - 2026-06-29
### Added
* **`OfferMedium.Push`** — new enum value (`"PUSH"`) added to `OfferMedium`, allowing push-notification offer mediums to be represented in attribution requests.

## 15.0.1 - 2026-06-23
* SDK regeneration
* Unable to analyze changes with AI, incrementing PATCH version.

## 15.0.0 - 2026-06-23
### Breaking Changes
* **`GetBatchesByPlacementRequest`** and **`GetOffersByPlacementRequest`** — records removed; replace with `GetPlacementContentRequest` passed to `RewardsClient.PlacementContentAsync`.
* **`PlacementContentResponse`** — removed from `KardFinancial.Users` namespace; no longer available as a standalone response model; update call sites to use `OneOf<OffersResponseObject, BatchesResponseObject>`.
* **`RewardsClient.PlacementOffersAsync`** and **`RewardsClient.PlacementBatchesAsync`** — removed; migrate callers to `RewardsClient.PlacementContentAsync`, which handles both standard and batch placements.
* **`RewardsClient.PlacementContentAsync`** — return type changed from `WithRawResponseTask<PlacementContentResponse>` to `WithRawResponseTask<OneOf<OffersResponseObject, BatchesResponseObject>>`; update all call sites to branch on the `OneOf` result.

## 14.2.0 - 2026-06-22
### Added
* **`RewardsClient.PlacementContentAsync`** — new method that retrieves content for any placement by ID; the server resolves the placement type and returns either `standardOffer` or `placementBatch` resources in a unified JSON:API document.
* **`GetPlacementContentRequest`** — new request record with optional `Include` (e.g. `"categories"`) and `SupportedComponents` (`ComponentType` values) query parameters for filtering the response.
* **`PlacementContentResponse`** — new response record representing the combined JSON:API document, with `Data` typed as `IEnumerable<OneOf<OfferDataUnion, PlacementBatchData>>` plus optional `Links`, `Included`, and `Meta` properties.

## 14.1.0 - 2026-06-17
### Added
* **`TransactionsAttributes.AccountId`** — new optional `string?` property that exposes the account identifier associated with a transaction, deserialized from the `accountId` JSON field.

## 14.0.0 - 2026-06-11
### Breaking Changes
* **`UpdatePlacementDataUnion.PlacementMainPage`** — renamed to `Placement` (discriminant changed from `"placementMainPage"` to `"placement"`); replace `PlacementMainPage`, `IsPlacementMainPage`, `AsPlacementMainPage()`, and `TryAsPlacementMainPage()` with their `Placement`-prefixed equivalents.
* **`UpdateMainPagePlacementData`** — renamed to `UpdateStandardPlacementData`; update all construction and type references.
* **`UpdateMainPageAttributes`** — renamed to `UpdateStandardAttributes`; update all construction and type references.
* **`UpdatePlacementDataUnion.Match<T>` and `Visit`** — now require two additional handler parameters (`onPlacementEmail`, `onPlacementGroup`); all existing call sites must be updated to supply these handlers.
### Added
* **`UpdatePlacementDataUnion.PlacementEmail` and `PlacementGroup`** — two new union members with full accessor, `TryAs*`, and implicit-conversion support, backed by new **`UpdateEmailPlacementData`** and **`UpdateGroupPlacementData`** types.
* **`CreateGroupAttributes`**, **`CreateGroupPlacementData`**, **`UpdateGroupAttributes`**, **`UpdateGroupPlacementData`**, **`GroupPlacementAttributes`**, and **`GroupPlacementData`** — new record types for creating, updating, and reading group placements, including `Name`, `Slots`, and `SlottedPlacementRelationships`.
* **`CreateEmailAttributes`**, **`CreateEmailPlacementData`**, **`UpdateEmailAttributes`**, **`EmailPlacementAttributes`** — new record types for creating, updating, and reading email placements with `Name`, `AvailableSlots`, `Cadence`, and optional `ContentStrategyId`.
* **`PlacementData`** — new record type representing a standard placement resource with optional `PlacementRelationships`.
### Changed
* **`BatchesResponseObject`**, **`PlacementBatchData`**, and **`PlacementBatchAttributes`** — documentation updated to reflect applicability to group placements; `isActive` is always `true` for group placement slots and `components` is omitted for group placements.

## 13.2.0 - 2026-06-10
### Added
* **`PushNotificationPlacementFileData`** — new record type representing a push-channel placement file notification, with `PushNotificationPlacementFileAttributes` (placement name, available slots, cadence, download URL) and `PushNotificationPlacementFileRelationships`.
* **`EmailNotificationPlacementFileData`** — new record type representing an email-channel placement file notification, with `EmailNotificationPlacementFileAttributes` (name, organization ID, available slots, cadence, download URL) and `EmailNotificationPlacementFileRelationships`.
* **`NotificationDataUnion`** — extended with constructors, `IsPushNotificationPlacementFile`, `IsEmailNotificationPlacementFile`, `AsPushNotificationPlacementFile()`, `AsEmailNotificationPlacementFile()`, `TryAsPushNotificationPlacementFile()`, `TryAsEmailNotificationPlacementFile()`, and updated `Match`/`Visit` overloads for both new union members.
* **`NotificationType.PushNotificationPlacementFile`** and **`NotificationType.EmailNotificationPlacementFile`** — new string enum constants for the two new notification type discriminants.

## 13.1.0 - 2026-06-10
### Added
* **`UpdateUserRequestAttributes.HistoricalTransactionsSent`** — new optional `bool?` property that confirms historical transactions have been sent for a user; once set to `true` it cannot be reverted to `false`.

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

