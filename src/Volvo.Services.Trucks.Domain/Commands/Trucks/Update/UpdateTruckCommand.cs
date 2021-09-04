using System.Net;
using MediatR;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Update
{
    public class UpdateTruckCommand : TruckCommand, IRequest<Unit>
    {  }
}