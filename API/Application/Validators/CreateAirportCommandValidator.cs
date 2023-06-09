using API.Application.Commands;
using FluentValidation;

namespace API.Application.Validators
{
    public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
    {
        public CreateAirportCommandValidator()
        {
            RuleFor(c => c.Code).NotEmpty().NotNull().Length(3);
            RuleFor(c => c.Name).NotEmpty().NotNull();
        }
    }
}