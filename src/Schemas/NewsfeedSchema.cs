using GraphQl.Demo.Queries;
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
            //Mutation = provider.GetRequiredService<NewsfeedMutation>();
        }
    }
}