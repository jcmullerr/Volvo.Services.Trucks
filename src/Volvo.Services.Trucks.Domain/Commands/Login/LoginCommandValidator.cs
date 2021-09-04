using FluentValidation;

namespace Volvo.Services.Trucks.Domain.Commands.Login
{
    public class LoginCommandValidator :
        AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p =>  p.Email)
                .NotEmpty();
            
            RuleFor(p =>  p.Password)
                .NotEmpty();
        }
    }
}