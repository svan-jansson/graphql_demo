using System;
using System.Collections.Generic;

namespace GraphQl.Demo.NewsfeedData
{
    public interface INewsfeedData
    {
        IEnumerable<Story> GetNewsfeed();
        IEnumerable<Story> GetStoriesByAuthor(int authorId);
        Story AddStory(int authorId, string title, string body);
        IEnumerable<Author> GetAuthors();
        Author AddAuthor(string name);
        IObservable<Story> SubscribeToNewsfeed();
    }
}
