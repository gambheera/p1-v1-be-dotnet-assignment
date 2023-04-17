using API.Exceptions;
using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<ConfirmOrderCommandHandler> _logger;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository, ILogger<ConfirmOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the order before doing anything to check the eligibility
                var orderBeforeConfirm = await _orderRepository.GetAsync(request.OrderId);

                // Check for null results
                if (orderBeforeConfirm == null)
                {
                    var message = "Order is not available to proceed.";
                    _logger.LogError($"{message} Order Id: {request.OrderId}");
                    throw new OrderApiException(message);
                }

                // Check for orders with higher quantities than available
                if (!orderBeforeConfirm.isQuantityEligibleToConfirm())
                {
                    var message = "Available quantity is not enough.";
                    _logger.LogError($"{message} Order Id: {request.OrderId}");
                    throw new OrderApiException(message);
                }

                // Change the order status to Confirmed
                var order = await _orderRepository.ConfirmAsync(request.OrderId);

                // Change the availability
                orderBeforeConfirm.FlightRate.MutateAvailability(-order.Quantity);

                // Push everything to the database
                await _orderRepository.UnitOfWork.SaveChangesAsync();

                // Send the notification to the customer
                orderBeforeConfirm.Customer.SendNotification($"Your order has been confirmed. Order No: {order.ReferenceNo}");

                return new Unit();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Unexpected Exception", ex);
                throw;
            }
        }
    }
}
