using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Commands.Login;
using Volvo.Services.Trucks.Domain.Entities.Security;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Domain.Interfaces.Authentication;
using Volvo.Services.Trucks.Infra.Notifications.Contexts;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Login
{
    public class LoginCommandHandlerTest
    {
        private readonly LoginCommandHandler _sut;
        private readonly Mock<IRepository<User>> _repository;
        private readonly Mock<ITokenGeneratorService> _tokenGeneratorService;
        private readonly INotificationContext _notificationContext;

        public LoginCommandHandlerTest()
        {
            _repository = new Mock<IRepository<User>>();
            _tokenGeneratorService = new Mock<ITokenGeneratorService>();
            _notificationContext = new NotificationContext();

            _sut = new LoginCommandHandler(
                _repository.Object,
                _tokenGeneratorService.Object,
                _notificationContext
            );
        }

        [Fact]
        public async Task MustGenerateToken()
        {
            SetupRepository();
            SetupTokenGeneratorService();
            var command = new LoginCommand(
                "test@test.com",
                "password"
            );

            var token = await _sut.Handle(command, default);

            Assert.NotEqual(token, default);
            Assert.False(_notificationContext.HasNotifications);
            _tokenGeneratorService.Verify(c => c.GenerateToken(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task MustGenerateNotification()
        {
            var command = new LoginCommand(
                "test@test.com",
                "password"
            );

            var token = await _sut.Handle(command, default);

            Assert.Equal(token, default);
            Assert.True(_notificationContext.HasNotifications);
            _tokenGeneratorService.Verify(c => c.GenerateToken(It.IsAny<User>()), Times.Never);
        }

        private void SetupTokenGeneratorService()
        {
            _tokenGeneratorService.Setup(m => m.GenerateToken(It.IsAny<User>()))
                .Returns(
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikp1bGlvIiwibmJmIjoxNjMwNzkwNTM2LCJleHAiOjE2MzA3OTc3MzYsImlhdCI6MTYzMDc5MDUzNn0.4zGnEsM8GWeLp-IwL_hlsc3Iqqqk8vDm1OsljHKV2KM"
                );
        }

        private void SetupRepository()
        {
            _repository.Setup(m => m.GetSingleAsync(It.IsAny<Expression<Func<User, bool>>>(), false))
                .Returns(
                    Task.FromResult(
                        new User(
                            "test",
                            "test@test.com",
                            "password"
                        )
                    )
                );
        }
    }
}