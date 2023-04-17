using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order order)
        {
            return (await _context.Orders.AddAsync(order)).Entity;
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(order => order.FlightRate)
                .Include(order => order.Customer)
                .FirstOrDefaultAsync(order => order.Id == orderId);
        }

        public async Task<Order> ConfirmAsync(Guid OrderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == OrderId);

            if(order == null)
            {
                return null;
            }

            order.ChangeStatus(OrderStatus.Confirmed);

            return order;
        }

    }
}
