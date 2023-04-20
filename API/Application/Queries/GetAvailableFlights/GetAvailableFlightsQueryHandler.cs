using API.ApiResponses;
using API.Application.Commands.ConfirmOrder;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries.GetAvailableFlights
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, List<FlightResponse>>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ILogger<GetAvailableFlightsQueryHandler> _logger;

        public GetAvailableFlightsQueryHandler(IFlightRepository flightRepository, ILogger<GetAvailableFlightsQueryHandler> logger)
        {
            _flightRepository = flightRepository;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of available flights matching the given destination airport name.
        /// </summary>
        /// <param name="request">The query containing the destination airport name to search for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of FlightResponse objects for the available flights.</returns>
        public async Task<List<FlightResponse>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetch the list of flights matching the given destination airport name
                var matchingFlightList = await _flightRepository.GetAvailableFlightsAsync(request.DestinationAirportName);

                // Create an empty list to hold the FlightResponse objects
                var flightResponseList = new List<FlightResponse>();

                // If there are no matching flights, return the empty response list
                if (matchingFlightList == null) { return flightResponseList; }

                // Prepare the response list with FlightResponse objects for the available flights
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

                // Return the list of FlightResponse objects for the available flights
                return flightResponseList;
            }
            catch (Exception ex)
            {
                // Log and rethrow any unexpected exception
                _logger.LogCritical("An unexpected exception occurred while fetching the available flights.", ex);
                throw;
            }

        }
    }
}
