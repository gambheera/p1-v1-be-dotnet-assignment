using Domain.Aggregates.CustomerAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public CustomerRepository(FlightsContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetAsync(Guid customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
        }
    }
}
