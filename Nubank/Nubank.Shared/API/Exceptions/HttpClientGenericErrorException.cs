using System;

namespace Nubank.API.Exceptions
{
    public class HttpClientGenericErrorException : APIException
    {
        public HttpClientGenericErrorException() : base() { }
        public HttpClientGenericErrorException(string message) : base(message) { }
        public HttpClientGenericErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
