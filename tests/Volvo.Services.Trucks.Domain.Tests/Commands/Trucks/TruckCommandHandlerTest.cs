using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Contexts;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Trucks
{
    public abstract class TruckCommandHandlerTest
    {
        protected readonly Mock<IRepository<Truck>> _repositoryMock;
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly Mock<INotificationContext> _notificationContextMock;
        protected readonly INotificationContext _notificationContext;

        protected TruckCommandHandlerTest()
        {
            _repositoryMock = new Mock<IRepository<Truck>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _notificationContextMock = new Mock<INotificationContext>();
            _notificationContext = new NotificationContext();
        }

        protected void SetupRepostory()
        {
            _repositoryMock.Setup(m => m.GetSingleAsync(It.IsAny<Expression<Func<Truck, bool>>>(), false))
                .Returns(
                    Task.FromResult(
                        new Truck()
                    )
                );
        }
    }
}