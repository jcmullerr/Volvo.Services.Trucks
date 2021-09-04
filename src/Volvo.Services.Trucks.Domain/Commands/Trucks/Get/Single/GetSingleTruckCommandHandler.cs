using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Single
{
    public class GetSingleTruckCommandHandler : TruckCommandHandler,
        IRequestHandler<GetSingleTruckCommand, Truck>
    {
        public GetSingleTruckCommandHandler(
            IRepository<Truck> repository,
            IUnitOfWork unitOfWork,
            INotificationContext notificationContext
        ) : base(repository, unitOfWork, notificationContext)
        { }

        public async Task<Truck> Handle(GetSingleTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = await _repository.GetSingleAsync(x => x.Id == request.Id);
            if (truck == default)
                _notificationContext.AddNotification("No truck found with the required Id");
            
            return truck;
        }
    }
}