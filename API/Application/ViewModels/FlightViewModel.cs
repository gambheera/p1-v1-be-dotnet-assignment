using System;

namespace API.Application.ViewModels
{
    public class FlightViewModel
    {
        public Guid Id { get; set; }
        public Guid OriginAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }

        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
    }
}
