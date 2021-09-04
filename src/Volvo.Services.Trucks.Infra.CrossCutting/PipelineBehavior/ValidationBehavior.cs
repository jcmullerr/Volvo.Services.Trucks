using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Infra.CrossCutting.PipelineBehavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly INotificationContext _notificationContext;

        public ValidationBehavior(
            IEnumerable<IValidator<TRequest>> validators,
            INotificationContext notificationContext
        )
        {
            _validators = validators;
            _notificationContext = notificationContext;
        }

        public Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next
        )
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                foreach (var failure in failures)
                {
                    _notificationContext.AddNotification(failure.PropertyName, failure.ErrorMessage);
                }

                return Task.FromResult(default(TResponse));
            }

            return next();
        }
    }
}