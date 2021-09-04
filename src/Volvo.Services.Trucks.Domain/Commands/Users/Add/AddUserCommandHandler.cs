using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Security;
using Volvo.Services.Trucks.Domain.Interfaces;

namespace Volvo.Services.Trucks.Domain.Commands.Users.Add
{
    public class AddUserCommandHandler :
        IRequestHandler<AddUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;
        public AddUserCommandHandler()
        { }
        public async Task<Unit> Handle(
            AddUserCommand request, 
            CancellationToken cancellationToken
        )
        {
            await _repository.InsertAsync(request.MapToUser());
            return Unit.Value;
        }
    }
}