using FluentValidation;

namespace Volvo.Services.Trucks.Domain.Commands.Users
{
    public class UserCommandValidator : AbstractValidator<UserCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty();
            
            RuleFor(u => u.Email)
                .NotEmpty();
            
            RuleFor(u => u.Password)
                .NotEmpty();
        }
    }
}