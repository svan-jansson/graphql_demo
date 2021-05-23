using GraphQL.Demo.NewsfeedData;
using GraphQL.Types;

namespace GraphQL.Demo.Types
{
    public class StoryType : ObjectGraphType<Story>
    {
        public StoryType()
        {
            Name = "Story";

            Field(s => s.Id).Description("The unique ID of the story");
            Field(s => s.Title).Description("The title of the story");
            Field(s => s.Body).Description("The body of the story");
            Field(s => s.PublishedOn).Description("When the story was published");
            Field<AuthorType>("author", "The author of the story");
        }
    }
}
