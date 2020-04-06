using FluentValidation;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Travel.Project.Application.Validations
{
    public class AccountRegisterValidation : AbstractValidator<AccountRegisterCommandRequest>
    {
        public AccountRegisterValidation()
        {
            RuleFor(a => a.Document)
                .NotEmpty()
                .WithMessage("O documento é obrigatório");
            
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .WithMessage("O primeiro nome é obrigatório");
            
            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithMessage("O segundo nome é obrigatório");
            
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório");
            
            RuleFor(a => a.Phone)
                .NotEmpty()
                .WithMessage("O telefone é obrigatório");
            
            RuleFor(a => a.Password)
                .NotEmpty()
                .WithMessage("A senha é obrigatório");
            
           
        }
    }
}