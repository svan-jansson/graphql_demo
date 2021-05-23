using System.Collections.Generic;

namespace GraphQL.Demo.NewsfeedData
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Story> Stories { get; set; }
    }
}