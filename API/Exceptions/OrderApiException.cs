using System;

namespace API.Exceptions
{
    public class OrderApiException: Exception
    {
        public OrderApiException()
        {
        }

        public OrderApiException(string message) : base(message)
        {
        }

        public OrderApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
