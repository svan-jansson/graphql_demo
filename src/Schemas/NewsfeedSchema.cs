using GraphQl.Demo.Mutations;
using GraphQl.Demo.Queries;
using GraphQl.Demo.Subscriptions;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQl.Demo.Schemas
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