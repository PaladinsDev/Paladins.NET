namespace Paladins.Net.Exceptions
{
    using System;

    [Serializable]
    public class UnavailableException : Exception
    {
        public UnavailableException()
        {
        }

        public UnavailableException(string message)
            : base(message)
        {
        }

        public UnavailableException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UnavailableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

    }
}
