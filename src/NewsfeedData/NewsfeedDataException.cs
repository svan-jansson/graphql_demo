using System;
using System.Runtime.Serialization;

namespace GraphQL.Demo.NewsfeedData
{
    [Serializable]
    internal class NewsfeedDataException : Exception
    {
        public NewsfeedDataException()
        {
        }

        public NewsfeedDataException(string message) : base(message)
        {
        }

        public NewsfeedDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NewsfeedDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}