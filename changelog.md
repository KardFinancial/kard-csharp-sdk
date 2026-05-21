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

