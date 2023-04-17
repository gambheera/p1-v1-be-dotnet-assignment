using API.Application.Commands.CreateOrder;
using FluentValidation;

namespace API.Application.Validators
{
    public class CreateOrderCommandValidator: AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().NotNull();
            RuleFor(c => c.FlightRateId).NotEmpty().NotNull();
            RuleFor(c => c.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
