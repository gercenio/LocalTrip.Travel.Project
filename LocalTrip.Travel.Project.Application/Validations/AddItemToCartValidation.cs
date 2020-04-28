using FluentValidation;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Travel.Project.Application.Validations
{
    public class AddItemToCartValidation : AbstractValidator<AddItemToCartCommandRequest>
    {
        public AddItemToCartValidation()
        {
            RuleFor(a => a.Count)
                .NotEqual(0)
                .WithMessage("A quantidade é obrigatório");
            
            RuleFor(a => a.PeopleId)
                .NotEqual(0)
                .WithMessage("O cliente é obrigatório");
            
            RuleFor(a => a.DestinationId)
                .NotEqual(0)
                .WithMessage("O destino é obrigatório");
        }
    }
}