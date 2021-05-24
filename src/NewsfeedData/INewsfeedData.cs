using System;
using System.Collections.Generic;

namespace GraphQL.Demo.NewsfeedData
{
    public interface INewsfeedData
    {
        IEnumerable<Story> GetNewsfeed();
        IEnumerable<Author> GetAuthors();
        Author GetAuthor(int authorId);
        Author AddAuthor(string name);
        Story AddStory(int authorId, string title, string body);
        IObservable<Story> SubscribeToNewsfeed();
    }
}
