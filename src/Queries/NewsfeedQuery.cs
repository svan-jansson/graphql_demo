using GraphQl.Demo.NewsfeedData;
using GraphQl.Demo.Types;
using GraphQL;
using GraphQL.Types;

namespace GraphQl.Demo.Queries
{
    public class NewsfeedQuery : ObjectGraphType<object>
    {
        public NewsfeedQuery(INewsfeedData newsfeedData)
        {
            Name = nameof(NewsfeedQuery);

            Field<ListGraphType<StoryType>>(
                name: "getNewsfeed",
                description: "Get the lastest stories",
                resolve: context => newsfeedData.GetNewsfeed());

            Field<ListGraphType<AuthorType>>(
                name: "getAuthors",
                description: "Get the authors behind the stories in the newsfeed",
                resolve: context => newsfeedData.GetAuthors());

            Field<ListGraphType<StoryType>>(
                name: "getStoriesByAuthor",
                description: "Get all stories by a given author",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "authorId",
                        Description = "The unique ID of the author"
                    }
                ),

                resolve: context => newsfeedData.GetStoriesByAuthor(context.GetArgument<int>("authorId")));
        }
    }
}
