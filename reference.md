# Reference
## Auth
<details><summary><code>client.Auth.<a href="/src/KardFinancial/Auth/AuthClient.cs">GetTokenAsync</a>(GetTokenRequest { ... }) -> WithRawResponseTask&lt;TokenResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Auth.GetTokenAsync(
    new GetTokenRequest { ClientId = "client_id", ClientSecret = "client_secret" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetTokenRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Files
<details><summary><code>client.Files.<a href="/src/KardFinancial/Files/FilesClient.cs">GetMetadataAsync</a>(organizationId, GetFilesMetadataRequest { ... }) -> WithRawResponseTask&lt;GetFilesMetadataResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves metadata for files associated with a specific issuer/organization.
This endpoint supports pagination and sorting options to efficiently navigate 
through potentially large sets of file metadata.
<b>Required scopes:</b> `files.read`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Files.GetMetadataAsync(
    "organization-123",
    new GetFilesMetadataRequest
    {
        PageSize = 5,
        FilterDateFrom = "2025-02-20T21:56:23Z",
        FilterDateTo = "2025-03-20T21:56:23Z",
        FilterFileType = FileType.EarnedRewardApprovedDailyReconciliationFile,
        Sort = [FilesMetadataSortOptions.SentDateDesc],
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetFilesMetadataRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Subscriptions
<details><summary><code>client.Notifications.Subscriptions.<a href="/src/KardFinancial/Notifications/Subscriptions/SubscriptionsClient.cs">GetAsync</a>(organizationId, GetSubscriptionsRequest { ... }) -> WithRawResponseTask&lt;SubscriptionsResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to fetch the subscriptions of the provided issuer.<br/>
<b>Required scopes:</b> `notifications:read`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.Subscriptions.GetAsync(
    "organization-123",
    new GetSubscriptionsRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notifications.Subscriptions.<a href="/src/KardFinancial/Notifications/Subscriptions/SubscriptionsClient.cs">CreateAsync</a>(organizationId, SubscriptionRequestBody { ... }) -> WithRawResponseTask&lt;CreateSubscriptionsResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to subscribe to notification events.<br/>
<b>Required scopes:</b> `notifications:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.Subscriptions.CreateAsync(
    "organization-123",
    new SubscriptionRequestBody
    {
        Data = new List<SubscriptionRequestUnion>()
        {
            new SubscriptionRequestUnion(
                new SubscriptionRequestUnion.Subscription(
                    new SubscriptionRequest
                    {
                        Attributes = new SubscriptionRequestAttributes
                        {
                            EventName = NotificationType.EarnedRewardApproved,
                            WebhookUrl = "https://webhookUrl.com/post",
                            Enabled = true,
                        },
                    }
                )
            ),
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubscriptionRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notifications.Subscriptions.<a href="/src/KardFinancial/Notifications/Subscriptions/SubscriptionsClient.cs">UpdateAsync</a>(organizationId, subscriptionId, UpdateSubscriptionRequestBody { ... }) -> WithRawResponseTask&lt;UpdateSubscriptionsResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to update existing notification subscriptions.<br/>
<b>Required scopes:</b> `notifications:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.Subscriptions.UpdateAsync(
    "organization-123",
    "subscription-123",
    new UpdateSubscriptionRequestBody
    {
        Data = new UpdateSubscriptionRequestUnion(
            new UpdateSubscriptionRequestUnion.Subscription(
                new UpdateSubscriptionRequest
                {
                    Attributes = new UpdateSubscriptionRequestAttributes
                    {
                        EventName = NotificationType.EarnedRewardApproved,
                        WebhookUrl = "https://webhookUrl.com/post",
                        Enabled = true,
                    },
                }
            )
        ),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**subscriptionId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateSubscriptionRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations
<details><summary><code>client.Organizations.<a href="/src/KardFinancial/Organizations/OrganizationsClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;ExternalOrganizationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve organization details for the authenticated issuer
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Children
<details><summary><code>client.Organizations.Children.<a href="/src/KardFinancial/Organizations/Children/ChildrenClient.cs">ListAsync</a>(organizationId, ListChildrenRequest { ... }) -> WithRawResponseTask&lt;ChildOrganizationListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List child organizations belonging to the authenticated issuer
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Children.ListAsync("organizationId", new ListChildrenRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the parent organization
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListChildrenRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Children.<a href="/src/KardFinancial/Organizations/Children/ChildrenClient.cs">CreateAsync</a>(organizationId, CreateChildRequestBody { ... }) -> WithRawResponseTask&lt;ChildOrganizationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a child organization by cloning the parent and overriding specified fields. An 8-digit numeric ID is generated automatically. The name is required, must contain at least one letter, and may contain only letters and spaces.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Children.CreateAsync(
    "organizationId",
    new CreateChildRequestBody
    {
        Data = new CreateChildRequestData
        {
            Type = "organization",
            Attributes = new CreateChildAttributes { Name = "name" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the parent organization
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateChildRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Children.<a href="/src/KardFinancial/Organizations/Children/ChildrenClient.cs">GetAsync</a>(organizationId, childId) -> WithRawResponseTask&lt;ChildOrganizationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific child organization
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Children.GetAsync("organizationId", "childId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the parent organization
    
</dd>
</dl>

<dl>
<dd>

**childId:** `string` — Unique identifier of the child organization
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Children.<a href="/src/KardFinancial/Organizations/Children/ChildrenClient.cs">UpdateAsync</a>(organizationId, childId, UpdateChildRequestBody { ... }) -> WithRawResponseTask&lt;ChildOrganizationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a child organization. Only the name can be changed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Children.UpdateAsync(
    "organizationId",
    "childId",
    new UpdateChildRequestBody
    {
        Data = new UpdateChildRequestData
        {
            Type = "organization",
            Attributes = new UpdateChildAttributes(),
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the parent organization
    
</dd>
</dl>

<dl>
<dd>

**childId:** `string` — Unique identifier of the child organization
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateChildRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Children.<a href="/src/KardFinancial/Organizations/Children/ChildrenClient.cs">DeleteAsync</a>(organizationId, childId) -> WithRawResponseTask&lt;DeleteResourceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a child organization
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Children.DeleteAsync("organizationId", "childId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the parent organization
    
</dd>
</dl>

<dl>
<dd>

**childId:** `string` — Unique identifier of the child organization
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ContentStrategies
<details><summary><code>client.Organizations.ContentStrategies.<a href="/src/KardFinancial/Organizations/ContentStrategies/ContentStrategiesClient.cs">CreateAsync</a>(organizationId, CreateContentStrategyRequestBody { ... }) -> WithRawResponseTask&lt;ContentStrategyResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a content strategy for the organization. The strategy name must be unique within the organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ContentStrategies.CreateAsync(
    "org-123",
    new CreateContentStrategyRequestBody
    {
        Data = new CreateContentStrategyRequestData
        {
            Type = "contentStrategy",
            Attributes = new CreateContentStrategyAttributes
            {
                Name = "Featured Travel",
                Sort = ContentStrategySort.HighestCashback,
                Categories = new List<CategoryOption>() { CategoryOption.Travel },
                CategoryExclusions = new List<CategoryOption>() { CategoryOption.Gas },
                MerchantExclusions = new List<string>() { "merchant-abc" },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateContentStrategyRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.ContentStrategies.<a href="/src/KardFinancial/Organizations/ContentStrategies/ContentStrategiesClient.cs">ListAsync</a>(organizationId, ListContentStrategiesRequest { ... }) -> WithRawResponseTask&lt;ContentStrategyListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List content strategies belonging to the authenticated organization
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ContentStrategies.ListAsync(
    "organizationId",
    new ListContentStrategiesRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListContentStrategiesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.ContentStrategies.<a href="/src/KardFinancial/Organizations/ContentStrategies/ContentStrategiesClient.cs">GetAsync</a>(organizationId, contentStrategyId) -> WithRawResponseTask&lt;ContentStrategyResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific content strategy
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ContentStrategies.GetAsync("organizationId", "contentStrategyId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**contentStrategyId:** `string` — Unique identifier of the content strategy (UUID v7)
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.ContentStrategies.<a href="/src/KardFinancial/Organizations/ContentStrategies/ContentStrategiesClient.cs">UpdateAsync</a>(organizationId, contentStrategyId, UpdateContentStrategyRequestBody { ... }) -> WithRawResponseTask&lt;ContentStrategyResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replace a content strategy. All fields must be provided; any omitted attribute is treated as cleared.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ContentStrategies.UpdateAsync(
    "organizationId",
    "contentStrategyId",
    new UpdateContentStrategyRequestBody
    {
        Data = new UpdateContentStrategyRequestData
        {
            Type = "contentStrategy",
            Attributes = new UpdateContentStrategyAttributes
            {
                Name = "name",
                Categories = new List<CategoryOption>()
                {
                    CategoryOption.ArtsEntertainment,
                    CategoryOption.ArtsEntertainment,
                },
                CategoryExclusions = new List<CategoryOption>()
                {
                    CategoryOption.ArtsEntertainment,
                    CategoryOption.ArtsEntertainment,
                },
                MerchantExclusions = new List<string>()
                {
                    "merchantExclusions",
                    "merchantExclusions",
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**contentStrategyId:** `string` — Unique identifier of the content strategy (UUID v7)
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateContentStrategyRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.ContentStrategies.<a href="/src/KardFinancial/Organizations/ContentStrategies/ContentStrategiesClient.cs">DeleteAsync</a>(organizationId, contentStrategyId) -> WithRawResponseTask&lt;DeleteResourceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a content strategy. Returns 409 if the strategy is still referenced by another resource.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ContentStrategies.DeleteAsync("organizationId", "contentStrategyId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**contentStrategyId:** `string` — Unique identifier of the content strategy (UUID v7)
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Placements
<details><summary><code>client.Organizations.Placements.<a href="/src/KardFinancial/Organizations/Placements/PlacementsClient.cs">CreateAsync</a>(organizationId, CreatePlacementRequestBody { ... }) -> WithRawResponseTask&lt;PlacementFormatUnion&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a placement for the organization. Use type "placementMainPage" for main-page placements (requires name and availableSlots) or "placementPushNotification" for push-notification placements (requires name and cadence; availableSlots is automatically set to 1).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Placements.CreateAsync(
    "org-123",
    new CreatePlacementRequestBody
    {
        Data = new CreatePlacementDataUnion(
            new CreatePlacementDataUnion.PlacementMainPage(
                new CreateMainPagePlacementData
                {
                    Attributes = new CreateMainPageAttributes
                    {
                        Name = "Homepage Banner",
                        AvailableSlots = 5,
                    },
                }
            )
        ),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreatePlacementRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Placements.<a href="/src/KardFinancial/Organizations/Placements/PlacementsClient.cs">ListAsync</a>(organizationId, ListPlacementsRequest { ... }) -> WithRawResponseTask&lt;PlacementListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List placements belonging to the authenticated organization
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Placements.ListAsync("organizationId", new ListPlacementsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListPlacementsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Placements.<a href="/src/KardFinancial/Organizations/Placements/PlacementsClient.cs">GetAsync</a>(organizationId, placementId, GetPlacementRequest { ... }) -> WithRawResponseTask&lt;PlacementResource&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific placement
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Placements.GetAsync(
    "organizationId",
    "placementId",
    new GetPlacementRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**placementId:** `string` — Unique identifier of the placement (UUID v7)
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetPlacementRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Placements.<a href="/src/KardFinancial/Organizations/Placements/PlacementsClient.cs">UpdateAsync</a>(organizationId, placementId, UpdatePlacementRequestBody { ... }) -> WithRawResponseTask&lt;PlacementFormatUnion&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replace a placement. All fields must be provided. Use type "placementMainPage" or "placementPushNotification" to set the placement kind. If the type is "placementPushNotification", availableSlots is automatically set to 1.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Placements.UpdateAsync(
    "organizationId",
    "placementId",
    new UpdatePlacementRequestBody
    {
        Data = new UpdatePlacementDataUnion(
            new UpdatePlacementDataUnion.PlacementMainPage(
                new UpdateMainPagePlacementData
                {
                    Attributes = new UpdateMainPageAttributes { Name = "name", AvailableSlots = 1 },
                }
            )
        ),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**placementId:** `string` — Unique identifier of the placement (UUID v7)
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdatePlacementRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Placements.<a href="/src/KardFinancial/Organizations/Placements/PlacementsClient.cs">DeleteAsync</a>(organizationId, placementId) -> WithRawResponseTask&lt;DeleteResourceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a placement
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Placements.DeleteAsync("organizationId", "placementId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` — Unique identifier of the organization
    
</dd>
</dl>

<dl>
<dd>

**placementId:** `string` — Unique identifier of the placement (UUID v7)
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Ping
<details><summary><code>client.Ping.<a href="/src/KardFinancial/Ping/PingClient.cs">PingAsync</a>() -> WithRawResponseTask&lt;PingResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to verify network connectivity and service availability.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Ping.PingAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Transactions
<details><summary><code>client.Transactions.<a href="/src/KardFinancial/Transactions/TransactionsClient.cs">CreateAsync</a>(organizationId, TransactionsRequestBody { ... }) -> WithRawResponseTask&lt;TransactionsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to send all transactions made by all your enrolled users in your rewards program. The request body will depend on the transaction type.<br/>
Please use the correct type when calling the endpoint:
- `transaction`: These incoming transactions will be processed and matched by the Kard system. Learn more about the [Transaction CLO Matching](https://github.com/kard-financial/kard-postman#c-transaction-clo-matching) flow here.
- `matchedTransaction`: For pre-matched transactions that need validation on match by the Kard system.
- `coreTransaction`: For transactions from core banking systems with limited card-level data.<br/>

<b>Required scopes:</b> `transaction:write`<br/>
<b>Note:</b> `Maximum of 500 transactions can be created per request`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Transactions.CreateAsync(
    "organization-123",
    new TransactionsRequestBody
    {
        Data = new List<Transactions>()
        {
            new Transactions(
                new Transactions.Transaction(
                    new TransactionsRequest
                    {
                        Id = "309rjfoincor3icno3rind093cdow3jciwjdwcm",
                        Attributes = new TransactionsAttributes
                        {
                            UserId = "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                            Status = TransactionStatus.Approved,
                            Amount = 1000,
                            Subtotal = 800,
                            Currency = "USD",
                            Direction = DirectionType.Debit,
                            PaymentType = TransactionPaymentType.Card,
                            Description = "ADVANCEAUTO",
                            Description2 = "ADVANCEAUTO",
                            Mcc = "1234",
                            CardBin = "123456",
                            CardLastFour = "4321",
                            AuthorizationDate = new DateTime(2021, 07, 02, 17, 47, 06, 000),
                            Merchant = new Merchant
                            {
                                Id = "12345678901234567",
                                Name = "ADVANCEAUTO",
                                AddrStreet = "125 Main St",
                                AddrCity = "Philadelphia",
                                AddrState = States.Pa,
                                AddrZipcode = "19147",
                                AddrCountry = "United States",
                                Latitude = "37.9419429",
                                Longitude = "-73.1446869",
                                StoreId = "12345",
                            },
                            AuthorizationCode = "123456",
                            RetrievalReferenceNumber = "100804333919",
                            AcquirerReferenceNumber = "1234567890123456789012345678",
                            SystemTraceAuditNumber = "333828",
                            TransactionId = "2467de37-cbdc-416d-a359-75de87bfffb0",
                            CardProductId = "1234567890123456789012345678",
                            ProcessorMids = new ProcessorMid(
                                new ProcessorMid.Visa(
                                    new VisaMid
                                    {
                                        Mids = new VisaMidDetails
                                        {
                                            Vmid = "12345678901",
                                            Vsid = "12345678",
                                        },
                                    }
                                )
                            ),
                        },
                    }
                )
            ),
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `TransactionsRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transactions.<a href="/src/KardFinancial/Transactions/TransactionsClient.cs">CreateFraudMarkersAsync</a>(organizationId, FraudulentTransactionRequestBody { ... }) -> WithRawResponseTask&lt;FraudulentTransactionObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to flag a submitted transaction as fraudulent. This will prevent it from being rewarded.<br/>

<b>Required scopes:</b>&nbsp;&nbsp;`transaction:write`<br/>
<b>Note:</b> `Maximum of 500 fraudulent transactions can be created per request`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Transactions.CreateFraudMarkersAsync(
    "organization-123",
    new FraudulentTransactionRequestBody
    {
        Data = new List<FraudulentTransactionData>()
        {
            new FraudulentTransactionData
            {
                Id = "myTxnId12345",
                Type = "fraudulentTransaction",
                Attributes = new FraudulentTransactionAttributes { UserId = "userId123" },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `FraudulentTransactionRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transactions.<a href="/src/KardFinancial/Transactions/TransactionsClient.cs">CreateAuditsAsync</a>(organizationId, userId, CreateAuditRequestBody { ... }) -> WithRawResponseTask&lt;CreateAuditResponseBody&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to request that a particular transaction be audited further by the Kard system, in the event of a missing cashback claim, incorrect cashback amount claim or other mis-match claims.<br/>
<b>Required scopes:</b> `audit:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Transactions.CreateAuditsAsync(
    "organization-123",
    "user-123",
    new CreateAuditRequestBody
    {
        Data = new List<CreateAuditRequestDataUnion>()
        {
            new CreateAuditRequestDataUnion(
                new CreateAuditRequestDataUnion.Audit(
                    new AuditRequestData
                    {
                        Attributes = new AuditAttributes
                        {
                            AuditCode = 8001,
                            MerchantName = "Caribbean Goodness",
                            AuditDescription = "duplicate transaction",
                            TransactionId = "issuerTransaction123",
                        },
                    }
                )
            ),
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — The ID of the user as defined on the issuers system
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateAuditRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transactions.<a href="/src/KardFinancial/Transactions/TransactionsClient.cs">CreateBulkTransactionsUploadUrlAsync</a>(organizationId, CreateFileUploadRequestBody { ... }) -> WithRawResponseTask&lt;CreateFileUploadUrlResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Generates up to 10 presigned PUT URLs for uploading JSONL transaction files (up to 5GB each) directly
to storage. Each URL is valid for 15 minutes. Use the returned URL to upload the file via an HTTP PUT request with the
binary file content as the body. If a URL expires before the upload completes, you must request a new one.
Files can be uploaded as plain JSONL or as a gzip-compressed file.
Supports both `incomingTransactionsFile` for daily transaction ingestion and `historicalTransactionsFile` for historical transaction ingestion. See the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide for details on the historical flow.
<b>Required scopes:</b> `files:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Transactions.CreateBulkTransactionsUploadUrlAsync(
    "organization-123",
    new CreateFileUploadRequestBody
    {
        Data = new List<CreateFileUploadData>()
        {
            new CreateFileUploadData
            {
                Type = FileUploadType.IncomingTransactionsFile,
                Attributes = new CreateFileUploadAttributes
                {
                    Filename = "transaction_12345.jsonl",
                },
            },
            new CreateFileUploadData
            {
                Type = FileUploadType.IncomingTransactionsFile,
                Attributes = new CreateFileUploadAttributes
                {
                    Filename = "transaction_67890.jsonl",
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateFileUploadRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transactions.<a href="/src/KardFinancial/Transactions/TransactionsClient.cs">GetEarnedRewardsAsync</a>(organizationId, userId, GetEarnedRewardsRequest { ... }) -> WithRawResponseTask&lt;GetEarnedRewardsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve rewarded transaction history for a specific user. By default this returns only SETTLED transactions within the last 12 months regardless of payment status. Pass `filter[paidInFullOnly]=true` to restrict the response to matched transactions that have been paid in full to the issuer (`paidToIssuer` is `PAID_IN_FULL`).
<br/>
<b>Required scopes:</b> `transaction:read`
<br/>
<b>Query Limit:</b> Maximum of 12 months of transaction data can be queried.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Transactions.GetEarnedRewardsAsync(
    "org-123",
    "user-456",
    new GetEarnedRewardsRequest
    {
        PageSize = 10,
        FilterStatus = RewardedTransactionStatus.Approved,
        Include = "merchant,offer",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — The ID of the user as defined on the issuers system
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetEarnedRewardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users
<details><summary><code>client.Users.<a href="/src/KardFinancial/Users/UsersClient.cs">CreateAsync</a>(organizationId, CreateUsersObject { ... }) -> WithRawResponseTask&lt;CreateUsersObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to enroll a specified user into your rewards program.<br/>

<b>Required scopes:</b>&nbsp;&nbsp;`user:write`<br/>
<b>Note:</b> `Maximum of 100 users can be created per request`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.CreateAsync(
    "organization-123",
    new CreateUsersObject
    {
        Data = new List<UserRequestDataUnion>()
        {
            new UserRequestDataUnion(
                new UserRequestDataUnion.User(
                    new UserRequestData
                    {
                        Id = "1234567890",
                        Attributes = new UserRequestAttributes
                        {
                            ZipCode = "11238",
                            EnrolledRewards = new List<EnrolledRewardsType>()
                            {
                                EnrolledRewardsType.Cardlinked,
                            },
                            Email = "user@example.com",
                            HashedEmail =
                                "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3e2d8a5b76e45a1d4c4e2e3a1",
                            PhoneNumber = "+14155552671",
                            BirthYear = "1990",
                            HistoricalTransactionsSent = true,
                        },
                    }
                )
            ),
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateUsersObject` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/KardFinancial/Users/UsersClient.cs">UpdateAsync</a>(organizationId, userId, UpdateUserObject { ... }) -> WithRawResponseTask&lt;UserResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to update the details on a specified user.<br/>

<b>Required scopes:</b> `user:update`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.UpdateAsync(
    "organization-123",
    "user-123",
    new UpdateUserObject
    {
        Data = new UpdateUserRequestDataUnion(
            new UpdateUserRequestDataUnion.User(
                new UpdateUserRequestData
                {
                    Id = "1234567890",
                    Attributes = new UpdateUserRequestAttributes
                    {
                        ZipCode = "11238",
                        EnrolledRewards = new List<EnrolledRewardsType>()
                        {
                            EnrolledRewardsType.Cardlinked,
                        },
                        Email = "user@example.com",
                        HashedEmail =
                            "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3e2d8a5b76e45a1d4c4e2e3a1",
                        PhoneNumber = "+14155552671",
                        BirthYear = "1990",
                    },
                }
            )
        ),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateUserObject` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/KardFinancial/Users/UsersClient.cs">DeleteAsync</a>(organizationId, userId) -> WithRawResponseTask&lt;DeleteUserResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to delete a specified enrolled user from the rewards program and Kard's system. Users can be re-enrolled into rewards by calling the [Create User](/2024-10-01/api/users/create) endpoint using the same `id` from before.<br/>

<b>Required scopes:</b> `user:delete`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.DeleteAsync("organization-123", "user-123");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/KardFinancial/Users/UsersClient.cs">GetAsync</a>(organizationId, userId) -> WithRawResponseTask&lt;UserResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to fetch the details on a specified user.<br/>
<br/>
<b>Required scopes:</b>&nbsp;&nbsp;`user:read`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.GetAsync("organization-123", "user-123");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Attributions
<details><summary><code>client.Users.Attributions.<a href="/src/KardFinancial/Users/Attributions/AttributionsClient.cs">CreateAsync</a>(organizationId, userId, CreateAttributionRequestObject { ... }) -> WithRawResponseTask&lt;CreateAttributionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Call this endpoint to send attribution events made by a single enrolled user for processing. A maximum of 100 events can be included in a single request.

<b>Required scopes:</b> `attributions:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Attributions.CreateAsync(
    "organization-123",
    "user-123",
    new CreateAttributionRequestObject
    {
        Data = new List<CreateAttributionRequestUnion>()
        {
            new CreateAttributionRequestUnion(
                new CreateAttributionRequestUnion.OfferAttribution(
                    new OfferAttributionRequest
                    {
                        Attributes = new OfferAttributionAttributes
                        {
                            EntityId = "60e4ba1da31c5a22a144c075",
                            EventCode = EventCode.View,
                            Medium = OfferMedium.Search,
                            EventDate = new DateTime(2025, 01, 01, 00, 00, 00, 000),
                        },
                    }
                )
            ),
            new CreateAttributionRequestUnion(
                new CreateAttributionRequestUnion.OfferAttribution(
                    new OfferAttributionRequest
                    {
                        Attributes = new OfferAttributionAttributes
                        {
                            EntityId = "60e4ba1da31c5a22a144c077",
                            EventCode = EventCode.Impression,
                            Medium = OfferMedium.Email,
                            EventDate = new DateTime(2025, 01, 01, 00, 00, 00, 000),
                        },
                    }
                )
            ),
            new CreateAttributionRequestUnion(
                new CreateAttributionRequestUnion.NotificationAttribution(
                    new NotificationAttributionRequest
                    {
                        Attributes = new NotificationAttributionAttributes
                        {
                            EntityId = "60e4ba1da31c5a22a144c076",
                            EventCode = EventCode.Impression,
                            Medium = NotificationMedium.Push,
                            EventDate = new DateTime(2025, 01, 01, 00, 00, 00, 000),
                        },
                    }
                )
            ),
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateAttributionRequestObject` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Attributions.<a href="/src/KardFinancial/Users/Attributions/AttributionsClient.cs">ActivateAsync</a>(organizationId, userId, offerId, ActivateOfferRequest { ... }) -> WithRawResponseTask&lt;ActivateOfferResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Record when a user activates an offer. Creates an attribution event with eventCode=ACTIVATE and medium=CTA.
Optionally include the offer data by passing `include=offer`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Attributions.ActivateAsync(
    "organization-123",
    "user-123",
    "offer-456",
    new ActivateOfferRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**offerId:** `string` — The unique identifier of the offer being activated
    
</dd>
</dl>

<dl>
<dd>

**request:** `ActivateOfferRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Attributions.<a href="/src/KardFinancial/Users/Attributions/AttributionsClient.cs">BoostAsync</a>(organizationId, userId, offerId, BoostOfferRequest { ... }) -> WithRawResponseTask&lt;BoostOfferResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Record when a user boosts an offer. Creates an attribution event with eventCode=BOOST and medium=CTA.
Optionally include the offer data by passing `include=offer`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Attributions.BoostAsync(
    "organization-123",
    "user-123",
    "offer-456",
    new BoostOfferRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**offerId:** `string` — The unique identifier of the offer being boosted
    
</dd>
</dl>

<dl>
<dd>

**request:** `BoostOfferRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Attributions.<a href="/src/KardFinancial/Users/Attributions/AttributionsClient.cs">ActivatePlacementSlotAsync</a>(organizationId, userId, placementId, slotId) -> WithRawResponseTask&lt;ActivatePlacementSlotResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Record when a user activates a batch-activation placement slot. Writes a slot-level
`placementSlotAttribution` ACTIVATE event and fans out a per-offer
`offerAttribution` ACTIVATE event for every offer resolved by the slot's content
strategy. The slot-level event id and the resolved `offerIds` are returned so the
partner can render the batch immediately without an extra `getBatchesByPlacement`
round-trip.

<b>Required scopes:</b> `attributions:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Attributions.ActivatePlacementSlotAsync(
    "organization-123",
    "user-123",
    "018f8d6b-1abc-7def-9012-345678901234",
    "slot-a"
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**placementId:** `string` — Unique identifier of the placement (UUID v7)
    
</dd>
</dl>

<dl>
<dd>

**slotId:** `string` — Stable identifier for the slot within the placement
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## WebView
<details><summary><code>client.Users.Auth.<a href="/src/KardFinancial/Users/Auth/AuthClient.cs">GetWebViewTokenAsync</a>(organizationId, userId) -> WithRawResponseTask&lt;WebViewTokenResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves an OAuth token for webview authentication.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Auth.GetWebViewTokenAsync("organization-123", "user-123");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Rewards
<details><summary><code>client.Users.Rewards.<a href="/src/KardFinancial/Users/Rewards/RewardsClient.cs">OffersAsync</a>(organizationId, userId, GetOffersByUserRequest { ... }) -> WithRawResponseTask&lt;OffersResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve national brand offers that a specified user is eligible for. Call this endpoint to build out your
[targeted offers UX experience](/2024-10-01/api/getting-started#b-discover-a-lapsed-customer-clo). Local offers details
can be found by calling the [Get Eligible Locations](/2024-10-01/api/rewards/locations).<br/>
<b>Required scopes:</b> `rewards:read`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Rewards.OffersAsync(
    "organization-123",
    "user-123",
    new GetOffersByUserRequest
    {
        PageSize = 1,
        FilterIsTargeted = true,
        Sort = [OfferSortOptions.StartDateDesc],
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetOffersByUserRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Rewards.<a href="/src/KardFinancial/Users/Rewards/RewardsClient.cs">PlacementOffersAsync</a>(organizationId, userId, placementId, GetOffersByPlacementRequest { ... }) -> WithRawResponseTask&lt;OffersResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve offers for a placement slot. Returns offers sorted by highest cash back,
limited by the placement's available slots.<br/>
<b>Required scopes:</b> `rewards:read`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Rewards.PlacementOffersAsync(
    "organizationId",
    "userId",
    "placementId",
    new GetOffersByPlacementRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**placementId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetOffersByPlacementRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Rewards.<a href="/src/KardFinancial/Users/Rewards/RewardsClient.cs">PlacementBatchesAsync</a>(organizationId, userId, placementId, GetBatchesByPlacementRequest { ... }) -> WithRawResponseTask&lt;BatchesResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve batches for a batch-activation placement. Returns each slot in slot
order with its current offer set, alias, and freshness fields (`isActive`,
`lastActivatedAt`, `expiresAt`). Applies the same per-user eligibility and
per-slot content-strategy filter as Get Offers By Placement, independently
per slot. A slot only flips to `isActive: false` when its refresh interval
has elapsed AND its post-eligibility `offers[]` is non-empty; otherwise the
slot is still returned and stays active so the partner UI does not promote
"refresh" with nothing to show.<br/>
<b>Required scopes:</b> `rewards:read`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Rewards.PlacementBatchesAsync(
    "organizationId",
    "userId",
    "placementId",
    new GetBatchesByPlacementRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**placementId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetBatchesByPlacementRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Rewards.<a href="/src/KardFinancial/Users/Rewards/RewardsClient.cs">LocationsAsync</a>(organizationId, userId, GetLocationsByUserRequest { ... }) -> WithRawResponseTask&lt;LocationsResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve national and local geographic locations that a specified user has eligible in-store offers at. Use this endpoint to build
out your [map-specific UX experiences](/2024-10-01/api/getting-started#c-discover-clos-near-you-map-view). Please note
that Longitude and Latitude fields are prioritized over State, City and Zipcode and are the recommended search
pattern.<br/>
<br/>
<b>Required scopes:</b> `rewards:read`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Rewards.LocationsAsync(
    "organization-123",
    "user-123",
    new GetLocationsByUserRequest
    {
        PageSize = 1,
        FilterLatitude = 39.9419429,
        FilterLongitude = -75.1446869,
        FilterRadius = 10,
        Include = ["offers,categories"],
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetLocationsByUserRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Uploads
<details><summary><code>client.Users.Uploads.<a href="/src/KardFinancial/Users/Uploads/UploadsClient.cs">CreateAsync</a>(organizationId, userId, CreateUploadRequestObject { ... }) -> WithRawResponseTask&lt;CreateUploadResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

<b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.

Call this endpoint to create an upload session and retrieve an upload ID. Using the upload ID in the [Add Upload Part](/2024-10-01/api/transactions/uploads/create-part) endpoint, historical transactions can be sent in batches for further processing.
<b>Required scopes:</b> `transaction:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Uploads.CreateAsync(
    "organization-123",
    "user-123",
    new CreateUploadRequestObject
    {
        Data = new CreateUploadRequestDataUnion(
            new CreateUploadRequestDataUnion.HistoricalTransactionStart(
                new StartHistoricalUploadNoData { Attributes = new EmptyObject() }
            )
        ),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — The ID of the user as defined on the issuers system
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateUploadRequestObject` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Uploads.<a href="/src/KardFinancial/Users/Uploads/UploadsClient.cs">CreatePartAsync</a>(organizationId, userId, uploadId, CreateUploadPartRequestObject { ... }) -> WithRawResponseTask&lt;CreateUploadPartResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

<b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.

Call this endpoint using the upload ID provided in the [Create Upload](/2024-10-01/api/transactions/uploads/create) endpoint to add parts to your upload. Currently, this endpoint supports adding historical transactions.
<b>Required scopes:</b> `transaction:write`
<b>Note:</b> `Maximum of 500 transactions can be uploaded per request`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Uploads.CreatePartAsync(
    "organization-123",
    "user-123",
    "upload-123",
    new CreateUploadPartRequestObject
    {
        Data = new List<CreateUploadPartDataUnion>()
        {
            new CreateUploadPartDataUnion(
                new CreateUploadPartDataUnion.HistoricalTransaction(
                    new TransactionsRequest
                    {
                        Id = "309rjfoincor3icno3rind093cdow3jciwjdwcm",
                        Attributes = new TransactionsAttributes
                        {
                            UserId = "6FHt5b6Fnp0qdomMEy5AN6PXcSJIeX69",
                            Status = TransactionStatus.Approved,
                            Amount = 1000,
                            Subtotal = 800,
                            Currency = "USD",
                            Direction = DirectionType.Debit,
                            PaymentType = TransactionPaymentType.Card,
                            Description = "ADVANCEAUTO",
                            Description2 = "ADVANCEAUTO",
                            Mcc = "1234",
                            CardBin = "123456",
                            CardLastFour = "4321",
                            AuthorizationDate = new DateTime(2021, 07, 02, 17, 47, 06, 000),
                            Merchant = new Merchant
                            {
                                Id = "12345678901234567",
                                Name = "ADVANCEAUTO",
                                AddrStreet = "125 Main St",
                                AddrCity = "Philadelphia",
                                AddrState = States.Pa,
                                AddrZipcode = "19147",
                                AddrCountry = "United States",
                                Latitude = "37.9419429",
                                Longitude = "-73.1446869",
                                StoreId = "12345",
                            },
                            AuthorizationCode = "123456",
                            RetrievalReferenceNumber = "100804333919",
                            AcquirerReferenceNumber = "1234567890123456789012345678",
                            SystemTraceAuditNumber = "333828",
                            TransactionId = "2467de37-cbdc-416d-a359-75de87bfffb0",
                        },
                    }
                )
            ),
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — The ID of the user as defined on the issuers system
    
</dd>
</dl>

<dl>
<dd>

**uploadId:** `string` — The upload ID identifying the upload session to add parts
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateUploadPartRequestObject` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Uploads.<a href="/src/KardFinancial/Users/Uploads/UploadsClient.cs">UpdateAsync</a>(organizationId, userId, uploadId, UpdateUploadRequestObject { ... }) -> WithRawResponseTask&lt;UpdateUploadResponseObject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

<b>Deprecated.</b> This endpoint is deprecated in favor of the [Create Bulk Transactions Upload URL](/2024-10-01/api/transactions/create-bulk-transactions-upload-url) endpoint. New integrations should use the bulk flow outlined in the [Historical Transaction Uploads](/2024-10-01/api/integration-guides/historical-transaction-uploads) integration guide.

Call this endpoint to update your upload session. Currently, you can signal completing a historical transactions upload.
<b>Required scopes:</b> `transaction:write`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Uploads.UpdateAsync(
    "organization-123",
    "user-123",
    "upload-123",
    new UpdateUploadRequestObject
    {
        Data = new UpdateUploadRequestDataUnion(
            new UpdateUploadRequestDataUnion.HistoricalTransactionComplete(
                new HistoricalTransactionCompleteNoData
                {
                    Id = "7e382223-b9a5-4825-91fb-436c8957a2e7",
                    Attributes = new EmptyObject(),
                }
            )
        ),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**organizationId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — The ID of the user as defined on the issuers system
    
</dd>
</dl>

<dl>
<dd>

**uploadId:** `string` — The upload ID identifying the upload session to update
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateUploadRequestObject` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

