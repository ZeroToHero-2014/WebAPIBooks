using System;
using System.Runtime.Serialization;

namespace Books.Persistence
{
    [Serializable]
    public class MissingEntityException : Exception
    {
        public MissingEntityException() { }
        public MissingEntityException(string message) : base(message) { }
        public MissingEntityException(string message, Exception inner) : base(message, inner) { }
        protected MissingEntityException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }
    }
}
