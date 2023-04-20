using API.ApiResponses;
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
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, OrderConfirmationResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<ConfirmOrderCommandHandler> _logger;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository, ILogger<ConfirmOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        /// <summary>
        /// Handles the confirmation of an order.
        /// </summary>
        /// <param name="request">The request containing the order ID to be confirmed.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An OrderConfirmationResponse containing the confirmed order information.</returns>
        public async Task<OrderConfirmationResponse> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the order before confirmation to check if it is eligible for confirmation
                var orderBeforeConfirm = await _orderRepository.GetAsync(request.OrderId);

                // Check if the order is null or not available for confirmation
                if (orderBeforeConfirm == null)
                {
                    var message = "Order is not available to proceed.";
                    _logger.LogError($"{message} Order Id: {request.OrderId}");
                    throw new OrderApiException(message);
                }

                // Check if the quantity of the order is eligible for confirmation
                if (!orderBeforeConfirm.isQuantityEligibleToConfirm())
                {
                    var message = "Available quantity is not enough.";
                    _logger.LogError($"{message} Order Id: {request.OrderId}");
                    throw new OrderApiException(message);
                }

                // Confirm the order by changing its status
                var order = await _orderRepository.ConfirmAsync(request.OrderId);

                // Update the availability of the order
                orderBeforeConfirm.FlightRate.MutateAvailability(-order.Quantity);

                // Push everything to the database
                await _orderRepository.UnitOfWork.SaveChangesAsync();

                /// Send a notification to the customer about the confirmation of their order
                orderBeforeConfirm.Customer.SendNotification($"Your order has been confirmed. Order No: {order.ReferenceNo}");

                // Return the order confirmation response
                return new OrderConfirmationResponse(orderBeforeConfirm.Id, orderBeforeConfirm.ReferenceNo, orderBeforeConfirm.Quantity);
            }
            catch (Exception ex)
            {
                // Log and rethrow any unexpected exception
                _logger.LogCritical("An unexpected exception occurred while confirming the order.", ex);
                throw;
            }
        }
    }
}
