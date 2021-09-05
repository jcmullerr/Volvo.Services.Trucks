using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks
{
    public abstract class TruckCommandHandler
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<Truck> _repository;
        protected readonly INotificationContext _notificationContext;

        protected TruckCommandHandler(
            IRepository<Truck> repository,
            IUnitOfWork unitOfWork,
            INotificationContext notificationContext)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public void AddNotFoundNotification()
        {
            _notificationContext.AddNotification("No truck with matching Id was found in the database");
        }
    }
}