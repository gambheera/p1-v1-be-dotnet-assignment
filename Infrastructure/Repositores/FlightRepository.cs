using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public Flight Add(Flight flight)
        {
            throw new NotImplementedException();
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flight>> GetAvailableFlightsAsync(string destinationAirportName)
        {
            return await _context.Flights
                .Include(flight => flight.OriginAirport)
                .Include(flight => flight.DestinationAirport)
                .Include(flight => flight.Rates)
                .Where(flight => 
                        flight.DestinationAirport.Name.ToUpper().Contains(destinationAirportName.ToUpper().Trim()) && 
                        flight.Rates.Count > 0)
                .ToListAsync();
        }

        public void Update(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
