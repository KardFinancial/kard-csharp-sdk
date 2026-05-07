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

