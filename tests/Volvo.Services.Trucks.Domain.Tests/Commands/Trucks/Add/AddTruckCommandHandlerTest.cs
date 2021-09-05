using System.Reflection.Metadata;
using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Add;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks.Add
{
    public class AddTruckCommandHandlerTest : TruckCommandHandlerTest
    {
        private readonly AddTruckCommandHandler _sut;

        public AddTruckCommandHandlerTest() : base()
        {
            _sut = new AddTruckCommandHandler(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _notificationContextMock.Object
            );
        }

        [Fact]
        public async Task MustAddTruckSucessfully()
        {
            var command = new AddTruckCommand();
            await _sut.Handle(command,default);

            _repositoryMock.Verify(x => x.InsertAsync(It.IsAny<Truck>()),Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(),Times.Once);
        }
    }
}