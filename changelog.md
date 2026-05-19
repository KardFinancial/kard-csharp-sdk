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

