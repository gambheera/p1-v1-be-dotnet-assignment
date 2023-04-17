using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.CustomerAggregate
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<Customer> GetAsync(Guid customerId);
    }
}
