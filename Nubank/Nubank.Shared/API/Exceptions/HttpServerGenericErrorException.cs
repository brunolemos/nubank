using System;

namespace Nubank.API.Exceptions
{
    public class HttpServerGenericErrorException : APIException
    {
        public HttpServerGenericErrorException() : base() { }
        public HttpServerGenericErrorException(string message) : base(message) { }
        public HttpServerGenericErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
