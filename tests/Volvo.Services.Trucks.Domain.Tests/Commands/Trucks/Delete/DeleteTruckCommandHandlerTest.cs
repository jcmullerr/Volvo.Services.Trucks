using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Delete;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks.Delete
{
    public class DeleteTruckCommandHandlerTest : TruckCommandHandlerTest
    {
        private readonly DeleteTruckCommandHandler _sut;

        public DeleteTruckCommandHandlerTest()
        {
            _sut = new DeleteTruckCommandHandler(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _notificationContext
            );
        }

        [Fact]
        public async Task MustDeleteTruckSuccesfully()
        {
            SetupRepostory();
            await _sut.Handle(new DeleteTruckCommand(1), default);

            Assert.False(_notificationContext.HasNotifications);
            _repositoryMock.Verify(m => m.DeleteAsync(It.IsAny<long>()),Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChangesAsync(),Times.Once);
        }

        [Fact]
        public async Task MustGenerateNotification()
        {
            await _sut.Handle(new DeleteTruckCommand(1), default);

            Assert.True(_notificationContext.HasNotifications);
            _repositoryMock.Verify(m => m.DeleteAsync(It.IsAny<long>()),Times.Never);
            _unitOfWorkMock.Verify(m => m.SaveChangesAsync(),Times.Never);
        }
    }
}