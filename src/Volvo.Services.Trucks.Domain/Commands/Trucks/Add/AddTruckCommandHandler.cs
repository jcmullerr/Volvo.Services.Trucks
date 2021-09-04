using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Add
{
    public class AddTruckCommandHandler : TruckCommandHandler,
        IRequestHandler<AddTruckCommand, Unit>
    {
        public AddTruckCommandHandler(
            IRepository<Truck> repository,
            IUnitOfWork unitOfWork,
            INotificationContext notificationContext
        ) : base(repository, unitOfWork, notificationContext)
        { }

        public async Task<Unit> Handle(
            AddTruckCommand request,
            CancellationToken cancellationToken
        )
        {
            await _repository.InsertAsync(
                request.MapToTruck()
            );
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}