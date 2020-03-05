using FluentValidation;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Travel.Project.Application.Validations
{
    public class AuthenticationValidation : AbstractValidator<AuthenticationCommandRequest>
    {
        public AuthenticationValidation()
        {
            RuleFor(a => a.UserCode)
                .NotEmpty()
                .WithMessage("O codigo do usuario é obrigatório");
            
            RuleFor(a => a.AccessKey)
                .NotEmpty()
                .WithMessage("O key é obrigatório");
        }
    }
}