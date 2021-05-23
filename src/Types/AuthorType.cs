using GraphQL.Demo.NewsfeedData;
using GraphQL.Types;

namespace GraphQL.Demo.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = "Author";

            Field(a => a.Id).Description("The unique ID of the author");
            Field(a => a.Name).Description("The name of the author");
            Field<ListGraphType<StoryType>>("stories", "The stories written by the author");
        }
    }
}
