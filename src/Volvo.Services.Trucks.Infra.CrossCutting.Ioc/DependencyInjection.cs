using Microsoft.Extensions.DependencyInjection;
using Volvo.Services.Trucks.Domain.Entities.Security;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Data.Contexts;
using Volvo.Services.Trucks.Infra.Data.Repositories;
using Volvo.Services.Trucks.Infra.Data.UoW;
using Volvo.Services.Trucks.Infra.Notifications.Contexts;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Infra.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Notification Context
            services.AddScoped<INotificationContext, NotificationContext>();

            //Repositories
            services.AddScoped<IRepository<User>, Repository<User>>();

            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}