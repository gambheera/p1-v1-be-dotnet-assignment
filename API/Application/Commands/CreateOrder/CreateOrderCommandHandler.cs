using API.Exceptions;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRateRepository _flightRateRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository, 
            IFlightRateRepository flightRateRepository,
            ILogger<CreateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _flightRateRepository = flightRateRepository;
            _logger = logger;
        }

        /// <summary>
        /// Handles the creation of a new order.
        /// </summary>
        /// <param name="request">The request containing the order details to be created.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created Order object.</returns>
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetch the flight rate details to validate the creation of the order
                var flightRate = await _flightRateRepository.GetAsync(request.FlightRateId);

                // Validate the fetched FlightRate object for nullity
                if (flightRate == null)
                {
                    var message = "The requested flight rate is not available.";
                    _logger.LogError($"{message} Flight rate Id: {request.FlightRateId}");
                    throw new OrderApiException(message);
                }

                // Validate the available quantity to place the order
                if (flightRate.Available < request.Quantity)
                {
                    var message = "The requested quantity is not available for the flight rate.";
                    _logger.LogError($"{message} Flight rate Id: {request.FlightRateId}");
                    throw new OrderApiException(message);
                }

                // Add the new order to the repository
                var order = await _orderRepository.AddAsync(new Order(request.CustomerId, request.FlightRateId, request.Quantity));

                // Save changes to the database
                await _orderRepository.UnitOfWork.SaveEntitiesAsync();

                // Set the flight rate details for the order
                order.SetFlightRate(flightRate);

                return order;
            }
            catch (Exception ex)
            {
                // Log and rethrow any unexpected exception
                _logger.LogCritical("An unexpected exception occurred while creating the order.", ex);
                throw;
            }
            
        }
    }
}
