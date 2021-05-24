using GraphQL.Demo.NewsfeedData;
using GraphQL.Demo.Types;
using GraphQL.Types;

namespace GraphQL.Demo.Queries
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

            Field<AuthorType>(
                name: "getAuthor",
                description: "Get a single author",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "authorId",
                        Description = "The unique ID of the author"
                    }
                ),
                resolve: context => newsfeedData.GetAuthor(context.GetArgument<int>("authorId")));
        }
    }
}
