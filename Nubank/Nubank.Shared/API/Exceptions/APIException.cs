using System;

namespace Nubank.API.Exceptions
{
    public abstract class APIException : Exception
    {
        public APIException() : base() { }
        public APIException(string message) : base(message) { }
        public APIException(string message, Exception innerException) : base(message, innerException) { }
    }
}
