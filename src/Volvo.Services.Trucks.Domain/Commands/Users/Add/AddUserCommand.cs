using MediatR;

namespace Volvo.Services.Trucks.Domain.Commands.Users.Add
{
    public class AddUserCommand : UserCommand, IRequest<Unit>
    { }
}