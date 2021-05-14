using System.Collections.Generic;

namespace GraphQl.Demo.NewsfeedData
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Story> Stories { get; set; }
    }
}