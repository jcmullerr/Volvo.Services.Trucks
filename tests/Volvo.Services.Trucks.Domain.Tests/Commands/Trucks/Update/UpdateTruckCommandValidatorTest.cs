using Volvo.Services.Trucks.Domain.Commands.Trucks.Update;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks.Update
{
    public class UpdateTruckCommandValidatorTest
    {
        private UpdateTruckCommandValidator _sut;

        public UpdateTruckCommandValidatorTest()
        {
            _sut = new UpdateTruckCommandValidator();
        }
    }
}