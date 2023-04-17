using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Guid CustomerId { get; set; }
        public Guid FlightRateId { get; set; }
        public int Quantity { get; set; }
    }
}
