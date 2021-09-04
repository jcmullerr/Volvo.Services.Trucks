using MediatR;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Delete
{
    public class DeleteTruckCommand : IRequest<Unit>
    { 
        public long Id { get; private set; }

        public DeleteTruckCommand(long id)
        {
            Id = id;
        }
    }
}