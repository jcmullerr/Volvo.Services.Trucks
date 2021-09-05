using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Update
{
    public class UpdateTruckCommandHandler : TruckCommandHandler,
        IRequestHandler<UpdateTruckCommand, Unit>
    {
        public UpdateTruckCommandHandler(
            IRepository<Truck> repository,
            IUnitOfWork unitOfWork,
            INotificationContext notificationContext
        ) : base(repository, unitOfWork, notificationContext)
        { }

        public async Task<Unit> Handle(
            UpdateTruckCommand request,
            CancellationToken cancellationToken
        )
        {
            var truck = await _repository.GetSingleAsync(x => x.Id == request.Id);

            if(truck == default)
            {
                AddNotFoundNotification();
                return default;
            }

            await _repository.UpdateAsync(
                request.MapToTruck(true)
            );

            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}