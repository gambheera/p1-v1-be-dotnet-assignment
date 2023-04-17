using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Aggregates.AirportAggregate;
using Domain.Common;
using Domain.Events;
using Domain.SeedWork;

namespace Domain.Aggregates.FlightAggregate
{
    public class Flight : Entity, IAggregateRoot
    {
        public Guid OriginAirportId { get; private set; }
        public Airport OriginAirport { get; private set; }

        public Guid DestinationAirportId { get; private set; }
        public Airport DestinationAirport { get; private set; }

        public DateTimeOffset Departure { get; private set; }
        public DateTimeOffset Arrival { get; private set; }

        private List<FlightRate> _rates;
        public IReadOnlyCollection<FlightRate> Rates => _rates;

        protected Flight()
        {
            _rates = new List<FlightRate>();
        }

        public Flight(DateTimeOffset departure, DateTimeOffset arrival, Guid originAirportId, Guid
            destinationAirportId) : this()
        {
            OriginAirportId = originAirportId;
            DestinationAirportId = destinationAirportId;
            Departure = departure;
            Arrival = arrival;
        }

        public void AddRate(string name, Price price, int numAvailable)
        {
            var rate = new FlightRate(name, price, numAvailable);
            _rates.Add(rate);
        }

        public void UpdateRatePrice(Guid rateId, Price price)
        {
            var rate = GetRate(rateId);

            rate.ChangePrice(price);

            AddDomainEvent(new FlightRatePriceChangedEvent(this, rate));
        }

        public void MutateRateAvailability(Guid rateId, int mutation)
        {
            var rate = GetRate(rateId);

            rate.MutateAvailability(mutation);

            AddDomainEvent(new FlightRateAvailabilityChangedEvent(this, rate, mutation));
        }

        public Price GetLowestPrice()
        {
            // Find the lowest value from the rates list
            var minPrice = _rates.Min(rate => ConvertToBasePrice(rate.Price));

            // Return the lowest Price
            return new Price(minPrice, Currency.EUR);
        }

        private FlightRate GetRate(Guid rateId)
        {
            var rate = _rates.SingleOrDefault(o => o.Id == rateId);

            if (rate == null)
            {
                throw new ArgumentException("This flight does not contain a rate with the provided rateId");
            }

            return rate;
        }

        private decimal ConvertToBasePrice(Price price)
        {
            if (price.Currency == Currency.EUR) { return price.Value; }

            // TODO: Need to consume a live currency rate api and convert the value

            return price.Value;
        }
    }
}