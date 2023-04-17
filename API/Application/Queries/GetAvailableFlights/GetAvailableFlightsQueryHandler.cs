using API.ApiResponses;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries.GetAvailableFlights
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, List<FlightResponse>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetAvailableFlightsQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<FlightResponse>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            // Fetch the matching flight list
            var matchingFlightList = await _flightRepository.GetAvailableFlightsAsync(request.DestinationAirportName);

            var flightResponseList = new List<FlightResponse>();

            // If response is null, No need to proceed.
            if (matchingFlightList == null) { return flightResponseList; }

            // Prepare the response list
            foreach (var flight in matchingFlightList)
            {
                flightResponseList.Add(
                        new FlightResponse(
                            flight.OriginAirport.Code,
                            flight.DestinationAirport.Code,
                            flight.Departure,
                            flight.Arrival,
                            flight.GetLowestPrice().Value)
                    );
            }

            return flightResponseList;
        }
    }
}
