using FluentValidation;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Travel.Project.Application.Validations
{
    public class FindTripValidation : AbstractValidator<FindTripCommandRequest>
    {
        public FindTripValidation()
        {
            RuleFor(a => a.CityDestination)
                .NotEmpty()
                .WithMessage("A cidade destino é obrigatório");
        }
    }
}