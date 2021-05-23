using GraphQL.Demo.NewsfeedData;
using GraphQL.Demo.Types;
using GraphQL;
using GraphQL.Types;

namespace GraphQL.Demo.Mutations
{
    public class NewsfeedMutation : ObjectGraphType
    {
        public NewsfeedMutation(INewsfeedData newsfeedData)
        {
            Name = nameof(NewsfeedMutation);

            Field<AuthorType>(
                name: "addAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "name",
                        Description = "The name of the author"
                    }),
                resolve: context => newsfeedData.AddAuthor(context.GetArgument<string>("name"))
                );

            Field<StoryType>(
                name: "addStory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "authorId",
                        Description = "The unique ID of an author"
                    },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "title",
                        Description = "The title of the story"
                    },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "body",
                        Description = "The body text of the story"
                    }),
                resolve: context => newsfeedData.AddStory(
                    context.GetArgument<int>("authorId"),
                    context.GetArgument<string>("title"),
                    context.GetArgument<string>("body"))
                );
        }
    }
}
