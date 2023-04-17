using API.Application.Queries.GetAvailableFlights;
using FluentValidation;

namespace API.Application.Validators
{
    public class GetAvailableFlightsQueryValidator : AbstractValidator<GetAvailableFlightsQuery>
    {
        public GetAvailableFlightsQueryValidator()
        {
            RuleFor(c => c.DestinationAirportName).NotEmpty().NotNull();
        }
    }
}
