using Domain.Aggregates.OrderAggregate;
using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public string ReferenceNo { get; set; }
        public int Quantity { get; set; }

        public Guid CustomerId { get; set; }
        public Guid FlightRateId { get; set; }

        public DateTimeOffset PlacedAt { get; set; }
        public OrderStatus Status { get; set; }
    }
}
