using MediatR;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Add
{
    public class AddTruckCommand : TruckCommand, IRequest<Unit>
    { }
}