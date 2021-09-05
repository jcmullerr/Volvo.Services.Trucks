using System.Reflection.Metadata;
using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Add;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Update;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks.Add
{
    public class UpdateTruckCommandHandlerTest : TruckCommandHandlerTest
    {
        private readonly UpdateTruckCommandHandler _sut;

        public UpdateTruckCommandHandlerTest() : base()
        {
            _sut = new UpdateTruckCommandHandler(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _notificationContext
            );
        }

        [Fact]
        public async Task MustUpdateTruckSucessfully()
        {
            SetupRepostory();
            var command = new UpdateTruckCommand();
            await _sut.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            _repositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Truck>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task MustGenerateNotification()
        {
            var command = new UpdateTruckCommand();
            await _sut.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            _repositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Truck>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
}