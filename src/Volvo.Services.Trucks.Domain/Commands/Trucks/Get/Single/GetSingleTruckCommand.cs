using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Trucks;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Single
{
    public class GetSingleTruckCommand : IRequest<Truck>
    {
        public long Id { get; private set; }

        public GetSingleTruckCommand(long id)
        {
            Id = id;
        }
    }
}