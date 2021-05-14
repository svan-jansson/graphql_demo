using GraphQl.Demo.NewsfeedData;
using GraphQl.Demo.Types;
using GraphQL.Types;

namespace GraphQl.Demo.Queries
{
    public class NewsfeedQuery : ObjectGraphType<object>
    {
        public NewsfeedQuery(INewsfeedData newsfeedData)
        {
            Name = "NewsfeedQuery";

            Field<ListGraphType<StoryType>>(
                name: "getNewsfeed",
                description: "Get the lastest stories",
                resolve: context => newsfeedData.GetNewsfeed());

            Field<ListGraphType<AuthorType>>(
                name: "getAuthors",
                description: "Get the authors behind the stories in the newsfeed",
                resolve: context => newsfeedData.GetAuthors());
        }
    }
}
