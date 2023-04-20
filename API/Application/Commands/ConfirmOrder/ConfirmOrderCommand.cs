using API.ApiResponses;
using MediatR;
using System;

namespace API.Application.Commands.ConfirmOrder
{
    public class ConfirmOrderCommand : IRequest<OrderConfirmationResponse>
    {
        public Guid OrderId { get; private set; }

        public ConfirmOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
