using System;
using System.Runtime.Serialization;

namespace Books.Persistence
{
    [Serializable]
    public class MissingBookException : Exception
    {
        public MissingBookException() { }
        public MissingBookException(string message) : base(message) { }
        public MissingBookException(string message, Exception inner) : base(message, inner) { }
        protected MissingBookException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }
    }
}
