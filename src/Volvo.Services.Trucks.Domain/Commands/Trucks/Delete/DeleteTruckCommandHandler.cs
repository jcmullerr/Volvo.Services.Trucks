using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Delete
{
    public class DeleteTruckCommandHandler : TruckCommandHandler,
        IRequestHandler<DeleteTruckCommand, Unit>
    {
        public DeleteTruckCommandHandler(
            IRepository<Truck> repository,
            IUnitOfWork unitOfWork,
            INotificationContext notificationContext
        ) : base(repository, unitOfWork, notificationContext)
        {
        }

        public async Task<Unit> Handle(
            DeleteTruckCommand request,
            CancellationToken cancellationToken
        )
        {
            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}