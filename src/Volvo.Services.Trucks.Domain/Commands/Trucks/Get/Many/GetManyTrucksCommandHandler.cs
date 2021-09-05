using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Many
{
    public class GetManyTrucksCommandHandler : TruckCommandHandler,
        IRequestHandler<GetManyTrucksCommand, IEnumerable<Truck>>
    {
        public GetManyTrucksCommandHandler(
            IRepository<Truck> repository,
            IUnitOfWork unitOfWork,
            INotificationContext notificationContext
        ) : base(repository, unitOfWork, notificationContext)
        { }

        public async Task<IEnumerable<Truck>> Handle(
            GetManyTrucksCommand request, 
            CancellationToken cancellationToken
        )
        {
            return await Task.Run<IEnumerable<Truck>>(() => _repository.GetQuery());
        }
    }
}