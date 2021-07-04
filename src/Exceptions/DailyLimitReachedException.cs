namespace Paladins.Net.Exceptions
{
    using System;

    [Serializable]
    public class DailyLimitReachedException : Exception
    {
        public DailyLimitReachedException()
        {
        }

        public DailyLimitReachedException(string message)
            : base(message)
        {
        }

        public DailyLimitReachedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DailyLimitReachedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
