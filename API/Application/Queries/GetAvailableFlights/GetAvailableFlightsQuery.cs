using API.ApiResponses;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Queries.GetAvailableFlights
{
    public class GetAvailableFlightsQuery: IRequest<List<FlightResponse>>
    {
        public string DestinationAirportName { get; private set; }

        public GetAvailableFlightsQuery(string destinationAirportName)
        {
            DestinationAirportName = destinationAirportName;
        }
    }
}
