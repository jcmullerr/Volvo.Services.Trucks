using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Volvo.Services.Trucks.Domain.Entities.Security;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Domain.Interfaces.Authentication;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Domain.Commands.Login
{
    public class LoginCommandHandler :
        IRequestHandler<LoginCommand, string>
    {
        private readonly IRepository<User> _repository;
        private readonly ITokenGeneratorService _tokenGeneratorService;
        private readonly INotificationContext _notificationContext;

        public LoginCommandHandler(
            IRepository<User> repository,
            ITokenGeneratorService tokenGeneratorService,
            INotificationContext notificationContext
        )
        {
            _repository = repository;
            _tokenGeneratorService = tokenGeneratorService;
            _notificationContext = notificationContext;
        }

        public async Task<string> Handle(
            LoginCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _repository.GetSingleAsync(
                p => p.Email == request.Email &&
                p.Password == request.Password
            );

            if (user == default)
                _notificationContext.AddNotification("No user matched the credentials sent");

            return _tokenGeneratorService.GenerateToken(user);
        }
    }
}