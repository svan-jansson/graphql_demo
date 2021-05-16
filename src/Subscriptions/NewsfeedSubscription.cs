using GraphQl.Demo.NewsfeedData;
using GraphQl.Demo.Types;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace GraphQl.Demo.Subscriptions
{
    public class NewsfeedSubscription : ObjectGraphType<object>
    {
        public NewsfeedSubscription(INewsfeedData newsfeedData)
        {
            Name = nameof(NewsfeedSubscription);

            AddField(new EventStreamFieldType
            {
                Name = "subscribeToNewsfeed",
                Type = typeof(StoryType),
                Resolver = new FuncFieldResolver<Story>(context => context.Source as Story),
                Subscriber = new EventStreamResolver<Story>(context => newsfeedData.SubscribeToNewsfeed())
            });
        }
    }
}
