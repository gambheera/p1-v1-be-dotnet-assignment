using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Common;
using Domain.Exceptions;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public string ReferenceNo { get; private set; }
        public int Quantity { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set;}

        public Guid FlightRateId { get; private set; }
        public FlightRate FlightRate { get; private set; }

        public DateTimeOffset PlacedAt { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order()
        { }

        public Order(Guid customerId, Guid flightRateId, int quantity) : this()
        {
            CustomerId = customerId;
            FlightRateId = flightRateId;
            Quantity = quantity;
            PlacedAt = DateTimeOffset.Now;
            Status = OrderStatus.Pending;
            ReferenceNo = GenerateReferenceNo();
        }

        public Order(Guid customerId, Guid flightRateId, int quantity, string referenceNo, OrderStatus status)
        {
            CustomerId = customerId;
            FlightRateId = flightRateId;
            Quantity = quantity;
            Status = status;
            ReferenceNo = referenceNo;
        }

        public void ChangeStatus(OrderStatus orderStatusToBe)
        {
            if (!IsOrderEligibleToChange())
            {
                // If order is in Confirmed status, the operation will not be processed. 
                throw new OrderDomainException("Makimg changes to a confirmed order is not allowed.");
            }

            Status = orderStatusToBe;
        }

        private string GenerateReferenceNo()
        {
            // Get the current time as a long value
            long ticks = DateTime.UtcNow.Ticks;

            // Convert the ticks value to a string
            string uniqueId = ticks.ToString();

            // Return the unique ID
            return uniqueId;
        }

        public bool isQuantityEligibleToConfirm()
        {
            return FlightRate.Available >= Quantity;
        }

        public void SetFlightRate(FlightRate flightRate)
        {
            FlightRate = flightRate;
        }

        private bool IsOrderEligibleToChange()
        {
            // Check whether order is in confirmed status
            return Status != OrderStatus.Confirmed;
        }
    }
}
