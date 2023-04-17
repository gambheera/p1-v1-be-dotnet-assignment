using System;

namespace API.Exceptions
{
    public class FlightApiException : Exception
    {
        public FlightApiException()
        {
        }

        public FlightApiException(string message) : base(message)
        {
        }

        public FlightApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
