using FluentValidation;

namespace Volvo.Services.Trucks.Domain.Commands.Users.Add
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
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