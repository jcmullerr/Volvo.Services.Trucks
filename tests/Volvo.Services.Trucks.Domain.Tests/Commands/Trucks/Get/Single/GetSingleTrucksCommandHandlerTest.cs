using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Single;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks.Get.Single
{
    public class GetSingleTrucksCommandHandlerTest : TruckCommandHandlerTest
    {
        private readonly GetSingleTruckCommandHandler _sut;

        public GetSingleTrucksCommandHandlerTest()
        {
            _sut = new GetSingleTruckCommandHandler(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _notificationContext
            );
        }

        [Fact]
        public async Task MustGetSingleTruckSuccesfully()
        {
            SetupRepostory();
            await _sut.Handle(new GetSingleTruckCommand(1), default);

            Assert.False(_notificationContext.HasNotifications);
            _repositoryMock.Verify(m => m.GetSingleAsync(It.IsAny<Expression<Func<Truck, bool>>>(), false), Times.Once);
        }

        [Fact]
        public async Task MustGenerateNotification()
        {
            await _sut.Handle(new GetSingleTruckCommand(1), default);

            Assert.True(_notificationContext.HasNotifications);
            _repositoryMock.Verify(m => m.GetSingleAsync(It.IsAny<Expression<Func<Truck, bool>>>(), false), Times.Once);
        }
    }
}