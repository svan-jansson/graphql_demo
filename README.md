# GraphQL Demo

Demo application and slides for a GraphQL API in .NET 5. Used to demostrate core differences between GraphQL and REST.

The application inside `/src` is a simple newsfeed API with support for

- Getting a list of stories a.k.a. the newsfeed
- Getting the authors for the stories
- Getting the stories for a specific author
- Adding new authors
- Adding new stories
- Subscribing to new newsfeed stories

## How to make GraphQL Subscriptions work in .NET 5

This demo application contains a working subscription, implemented with `GraphQL.SystemReactive`. Follow these steps to add subscriptions to your own GraphQL/.NET 5 API:

1. Run `dotnet nuget add GraphQL.SystemReactive`
2. Add an `IObservable<T>` that the GraphQL subscription can listen to. See [MockNewsfeedData.cs](https://github.com/svan-jansson/graphql_demo/blob/526a792a2680d5de61f3bf04a0e3817aec634dd7/src/NewsfeedData/MockNewsfeedData.cs#L105).
3. Add a GraphQL subscription that resolves the `IObservable<T>`. See [NewsfeedSubscription.cs](https://github.com/svan-jansson/graphql_demo/blob/526a792a2680d5de61f3bf04a0e3817aec634dd7/src/Subscriptions/NewsfeedSubscription.cs#L19).
4. Register the subscription with the GraphQL schema. See [NewsfeedSchema.cs](https://github.com/svan-jansson/graphql_demo/blob/526a792a2680d5de61f3bf04a0e3817aec634dd7/src/Schemas/NewsfeedSchema.cs#L17).
5. Add a custom `DocumentExecuter` that supports the `SubscriptionExecutionStrategy`. See [DocumentExecuterWithSubscriptions.cs](https://github.com/svan-jansson/graphql_demo/blob/526a792a2680d5de61f3bf04a0e3817aec634dd7/src/DocumentExecuter/DocumentExecuterWithSubscriptions.cs#L9).
6. Add the custom `DocumentExecuter` along with WebSockets and GraphQL WebSockets support in startup. See [Startup.cs](https://github.com/svan-jansson/graphql_demo/blob/526a792a2680d5de61f3bf04a0e3817aec634dd7/src/Startup.cs#L28).

## How to run

```bash
dotnet run
```
Open a browser and navigate to <https://localhost:5001/ui/playground>

## Goal of Demo

- Give a comparison between GraphQL and REST
- Provide background and reasoning for Facebook's development of the GraphQL specification
- Point out a few problems with REST that are mitigated with GraphQL
  - Over-fetching
  - Multiple round trips
  - API documentation
- Show, in code, how these problems are tackled with GraphQL
