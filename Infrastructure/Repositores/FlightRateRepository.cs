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
    public class FlightRateRepository : IFlightRateRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRateRepository(FlightsContext context)
        {
            _context = context;
        }

        public async Task<FlightRate> GetAsync(Guid flightRateId)
        {
            return await _context.FlightRates.FirstOrDefaultAsync(flightRate => flightRate.Id == flightRateId);
        }

        public void Update(FlightRate flightRate)
        {
            _context.FlightRates.Update(flightRate);
        }
    }
}
