using System;

namespace Paladins.Net.Exceptions
{
    [Serializable]
    public class PrivateProfileException : Exception
    {
        public PrivateProfileException() { }
        public PrivateProfileException(string message) : base(message) { }
        public PrivateProfileException(string message, Exception inner) : base(message, inner) { }
        protected PrivateProfileException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }
        protected NotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class PlayerNotFoundException : NotFoundException
    {
        public PlayerNotFoundException() { }
        public PlayerNotFoundException(string message) : base(message) { }
        public PlayerNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected PlayerNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() { }
        public UnauthorizedException(string message) : base(message) { }
        public UnauthorizedException(string message, Exception inner) : base(message, inner) { }
        protected UnauthorizedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class UnavailableException : Exception
    {
        public UnavailableException() { }
        public UnavailableException(string message) : base(message) { }
        public UnavailableException(string message, Exception inner) : base(message, inner) { }
        protected UnavailableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class DailyLimitReachedException : Exception
    {
        public DailyLimitReachedException() { }
        public DailyLimitReachedException(string message) : base(message) { }
        public DailyLimitReachedException(string message, Exception inner) : base(message, inner) { }
        protected DailyLimitReachedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InvalidSessionException : Exception
    {
        public InvalidSessionException() { }
        public InvalidSessionException(string message) : base(message) { }
        public InvalidSessionException(string message, Exception inner) : base(message, inner) { }
        protected InvalidSessionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
