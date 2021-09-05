using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Many;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks.Get.Many
{
    public class GetManyTrucksCommandHandlerTest : TruckCommandHandlerTest
    {
        private readonly GetManyTrucksCommandHandler _sut;

        public GetManyTrucksCommandHandlerTest()
        {
            _sut = new GetManyTrucksCommandHandler(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _notificationContextMock.Object
            );
        }

        [Fact]
        public async Task MustGetAllTrucksSuccessfully()
        {
            await _sut.Handle(new GetManyTrucksCommand(), default);

            _repositoryMock.Verify(m => m.GetQuery(), Times.Once);
        }
    }
}