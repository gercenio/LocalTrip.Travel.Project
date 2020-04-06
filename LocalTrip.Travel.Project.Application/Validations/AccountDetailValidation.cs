using FluentValidation;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Travel.Project.Application.Validations
{
    public class AccountDetailValidation : AbstractValidator<AccountDetailCommandRequest>
    {
        public AccountDetailValidation()
        {
            RuleFor(a => a.Document)
                .NotEmpty()
                .WithMessage("O documento é obrigatório");
        }
    }
}