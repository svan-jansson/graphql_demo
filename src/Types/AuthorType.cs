using GraphQl.Demo.NewsfeedData;
using GraphQL.Types;

namespace GraphQl.Demo.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(a => a.Id).Description("The unique ID of the author");
            Field(a => a.Name).Description("The name of the author");
            Field<ListGraphType<StoryType>>("stories", "The stories written by the author");
        }
    }
}
