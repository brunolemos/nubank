using System;

namespace Nubank.API.Exceptions
{
    public class NoInternetAvailableException : APIException
    {
        public NoInternetAvailableException() : base() { }
        public NoInternetAvailableException(string message) : base(message) { }
        public NoInternetAvailableException(string message, Exception innerException) : base(message, innerException) { }
    }
}
