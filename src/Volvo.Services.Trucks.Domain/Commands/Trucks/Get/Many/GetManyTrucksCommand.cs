using System.Collections.Generic;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Trucks;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Many
{
    public class GetManyTrucksCommand : IRequest<IEnumerable<Truck>>
    { }
}