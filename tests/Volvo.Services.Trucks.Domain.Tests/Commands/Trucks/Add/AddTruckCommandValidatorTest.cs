using System;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Add;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks.Add
{
    public class AddTruckCommandValidatorTest
    {
        private readonly AddTruckCommandValidator _sut;

        public AddTruckCommandValidatorTest()
        {
            _sut = new AddTruckCommandValidator();
        }

        [Fact]
        public void MustCreateValidAddTruckCommand()
        {
            var command = new AddTruckCommand
            {
                Description = "description",
                FabricationYear = DateTime.Now.Year,
                ModelYear = DateTime.Now.Year,
                TruckModel = ETruckModel.FH
            };

            var result = _sut.Validate(command);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(2020,2020,ETruckModel.FE)]
        [InlineData(2020,2020,ETruckModel.FH16)]
        [InlineData(2020,2020,ETruckModel.FL)]
        [InlineData(1900,2020,ETruckModel.FL)]
        [InlineData(2020,1900,ETruckModel.FL)]
        [InlineData(2019,2020,ETruckModel.FL)]
        public void MustCreateInvalidAddTruckCommand(
            int fabricationYear,
            int modelYear,
            ETruckModel truckModel
        )
        {
            var command = new AddTruckCommand
            {
                Description = "description",
                FabricationYear = fabricationYear,
                ModelYear = modelYear,
                TruckModel = truckModel
            };

            var result = _sut.Validate(command);

            Assert.False(result.IsValid);
        }
    }
}