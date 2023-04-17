using MediatR;
using System;

namespace API.Application.Commands.ConfirmOrder
{
    public class ConfirmOrderCommand : IRequest
    {
        public Guid OrderId { get; private set; }

        public ConfirmOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
