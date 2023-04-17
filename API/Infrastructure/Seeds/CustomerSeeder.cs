using Domain.Aggregates.CustomerAggregate;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Infrastructure.Seeds
{
    public class CustomerSeeder : FlightsContextSeeder
    {

        public CustomerSeeder(FlightsContext flightsContext) : base(flightsContext)
        {
        }

        public override void Seed()
        {
            if (FlightsContext.Customers.Any())
            {
                Console.WriteLine("Skipping Customers seeder because table is not empty.");
                return;
            }

            var customers = new List<Customer>()
            {
                new Customer("001", "Scott Edwards"),
                new Customer("002", "Shariz Ahmad"),
                new Customer("003", "Tom Cooper"),
                new Customer("004", "Ryan Klein"),
                new Customer("005", "Paul van Meekeren"),
                new Customer("006", "Wesley Barresi")
        };

            FlightsContext.Customers.AddRange(customers);
            FlightsContext.SaveChanges();
        }
    }
}
