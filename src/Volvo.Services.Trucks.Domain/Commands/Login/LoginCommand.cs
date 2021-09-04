using MediatR;

namespace Volvo.Services.Trucks.Domain.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}