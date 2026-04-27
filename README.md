# Kard C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=https%3A%2F%2Fgithub.com%2FKardFinancial%2Fkard-csharp-sdk)
[![nuget shield](https://img.shields.io/nuget/v/kard-financial-sdk)](https://nuget.org/packages/kard-financial-sdk)

The Kard C# library provides convenient access to the Kard APIs from C#.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Reference](#reference)
- [Usage](#usage)
- [Environments](#environments)
- [Exception Handling](#exception-handling)
- [Advanced](#advanced)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Raw Response](#raw-response)
  - [Additional Headers](#additional-headers)
  - [Additional Query Parameters](#additional-query-parameters)
  - [Forward Compatible Enums](#forward-compatible-enums)
- [Contributing](#contributing)

## Requirements

This SDK requires:

## Installation

```sh
dotnet add package kard-financial-sdk
```

## Reference

A full reference for this library is available [here](https://github.com/KardFinancial/kard-csharp-sdk/blob/HEAD/./reference.md).

## Usage

Instantiate and use the client with the following:

```csharp
using KardApi;

var client = new KardApiClient("client_id", "client_secret");
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

## Environments

This SDK allows you to configure different environments for API requests.

```csharp
using KardApi;

var client = new KardApiClient(new ClientOptions
{
    BaseUrl = KardApiEnvironment.Production
});
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using KardApi;

try {
    var response = await client.Users.CreateAsync(...);
} catch (KardApiApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

A request is deemed retryable when any of the following HTTP status codes is returned:

- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500) (Internal Server Errors)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.Users.CreateAsync(
    ...,
    new RequestOptions {
        MaxRetries: 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.Users.CreateAsync(
    ...,
    new RequestOptions {
        Timeout: TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using KardApi;

// Access raw response data (status code, headers, etc.) alongside the parsed response
var result = await client.Users.CreateAsync(...).WithRawResponse();

// Access the parsed data
var data = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    System.Console.WriteLine($"Request ID: {requestId}");
}

// For the default behavior, simply await without .WithRawResponse()
var data = await client.Users.CreateAsync(...);
```

### Additional Headers

If you would like to send additional headers as part of the request, use the `AdditionalHeaders` request option.

```csharp
var response = await client.Users.CreateAsync(
    ...,
    new RequestOptions {
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Custom-Header", "custom-value" }
        }
    }
);
```

### Additional Query Parameters

If you would like to send additional query parameters as part of the request, use the `AdditionalQueryParameters` request option.

```csharp
var response = await client.Users.CreateAsync(
    ...,
    new RequestOptions {
        AdditionalQueryParameters = new Dictionary<string, string>
        {
            { "custom_param", "custom-value" }
        }
    }
);
```

### Forward Compatible Enums

This SDK uses forward-compatible enums that can handle unknown values gracefully.

```csharp
using KardApi;

// Using a built-in value
var cardNetwork = CardNetwork.Visa;

// Using a custom value
var customCardNetwork = CardNetwork.FromCustom("custom-value");

// Using in a switch statement
switch (cardNetwork.Value)
{
    case CardNetwork.Values.Visa:
        Console.WriteLine("Visa");
        break;
    default:
        Console.WriteLine($"Unknown value: {cardNetwork.Value}");
        break;
}

// Explicit casting
string cardNetworkString = (string)CardNetwork.Visa;
CardNetwork cardNetworkFromString = (CardNetwork)"VISA";
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
