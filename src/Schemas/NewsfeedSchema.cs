using GraphQL.Demo.Mutations;
using GraphQL.Demo.Queries;
using GraphQL.Demo.Subscriptions;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQL.Demo.Schemas
{
    public class NewsfeedSchema : Schema
    {
        public NewsfeedSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<NewsfeedQuery>();
            Mutation = provider.GetRequiredService<NewsfeedMutation>();
            Subscription = provider.GetRequiredService<NewsfeedSubscription>();
        }
    }
}