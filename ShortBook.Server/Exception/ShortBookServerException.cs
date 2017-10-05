using System;
using System.Runtime.Serialization;

namespace ShortBook.Server.Exception
{
    [Serializable]
    public class ShortBookServerException : System.Exception
    {
        public ShortBookServerException()
        {
        }

        public ShortBookServerException(string message) : base(message)
        {
        }

        public ShortBookServerException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected ShortBookServerException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}