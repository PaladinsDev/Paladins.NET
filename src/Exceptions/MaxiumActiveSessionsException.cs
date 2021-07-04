namespace Paladins.Net.Exceptions
{
    using System;


    [Serializable]
    public class MaxiumActiveSessionsException : Exception
    {
        public MaxiumActiveSessionsException()
        {
        }

        public MaxiumActiveSessionsException(string message)
            : base(message)
        {
        }

        public MaxiumActiveSessionsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected MaxiumActiveSessionsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

    }
}
