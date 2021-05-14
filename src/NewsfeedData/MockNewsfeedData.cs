using LoremNET;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQl.Demo.NewsfeedData
{
    public class MockNewsfeedData : INewsfeedData
    {
        private readonly IList<Story> _stories = new List<Story>();
        private readonly IList<Author> _authors = new List<Author>();

        public MockNewsfeedData()
        {
            _stories = new List<Story>();

            for (var id = 1; id <= 10; id++)
            {
                var author = new Author
                {
                    Id = 10 - id,
                    Name = Lorem.Words(2),
                    Stories = new List<Story>()
                };

                var story = new Story
                {
                    Id = id,
                    Title = Lorem.Sentence(3, 5),
                    Body = Lorem.Paragraph(5, 7, 5, 10),
                    PublishedOn = DateTime.Now.AddHours(-id),
                    Author = author
                };

                (author.Stories as List<Story>).Add(story);

                _stories.Add(story);
                _authors.Add(author);
            }
        }

        public Story AddStory(int authorId, string title, string body)
        {
            var author = _authors.Where(author => author.Id == authorId).FirstOrDefault();
            if (author is null)
            {
                throw new ArgumentException($"{nameof(authorId)} not found");
            }

            var story = new Story
            {
                Title = title,
                Body = body,
                PublishedOn = DateTime.Now,
                Author = author
            };

            (author.Stories as List<Story>).Add(story);

            _stories.Add(story);

            return story;
        }

        public Author AddAuthor(string name)
        {
            var authorId = _authors.Count + 1;

            var author = new Author
            {
                Id = authorId,
                Name = name,
                Stories = new List<Story>()
            };

            _authors.Add(author);

            return author;
        }

        public IEnumerable<Story> GetNewsfeed() => _stories.OrderByDescending(story => story.PublishedOn);

        public IEnumerable<Author> GetAuthors() => _authors;

        public IEnumerable<Story> GetStoriesByAuthor(int authorId)
            => _stories.Where(story => story.Author.Id == authorId);
    }
}
