using System;

namespace Paladins.Net.Exceptions
{
    public class PrivateProfile : Exception { }
    public class NotFound : Exception { }
    public class PlayerNotFound : NotFound { }
    public class Unauthorized : Exception { }
    public class Unavailable : Exception { }
    public class DailyLimitReached : Exception { }
}
