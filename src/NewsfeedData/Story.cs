using System;

namespace GraphQL.Demo.NewsfeedData
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedOn { get; set; }
        public Author Author { get; set; }
    }
}