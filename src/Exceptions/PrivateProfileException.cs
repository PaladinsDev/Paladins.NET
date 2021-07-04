namespace Paladins.Net.Exceptions
{
    using System;

    [Serializable]
    public class PrivateProfileException : Exception
    {
        public PrivateProfileException()
        {
        }

        public PrivateProfileException(string message)
            : base(message)
        {
        }

        public PrivateProfileException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected PrivateProfileException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

    }
}
