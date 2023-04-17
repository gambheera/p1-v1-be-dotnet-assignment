using API.Application.Commands.ConfirmOrder;
using FluentValidation;

namespace API.Application.Validators
{
    public class ConfirmOrderCommandValidator: AbstractValidator<ConfirmOrderCommand>
    {
        public ConfirmOrderCommandValidator()
        {
            RuleFor(c => c.OrderId).NotEmpty().NotNull();
        }
    }
}
