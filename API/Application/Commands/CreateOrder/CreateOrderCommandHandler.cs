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

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flightRate = await _flightRateRepository.GetAsync(request.FlightRateId);

                if (flightRate == null)
                {
                    var message = "Requested quantity is not available.";
                    _logger.LogError($"{message} Flight rate Id: {request.FlightRateId}");
                    throw new OrderApiException(message);
                }

                if (flightRate.Available < request.Quantity)
                {
                    var message = "Requested quantity is not available.";
                    _logger.LogError($"{message} Flight rate Id: {request.FlightRateId}");
                    throw new OrderApiException(message);
                }

                var order = await _orderRepository.AddAsync(new Order(request.CustomerId, request.FlightRateId, request.Quantity));
                await _orderRepository.UnitOfWork.SaveEntitiesAsync();

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Unexpected Exception", ex);
                throw;
            }
            
        }
    }
}
