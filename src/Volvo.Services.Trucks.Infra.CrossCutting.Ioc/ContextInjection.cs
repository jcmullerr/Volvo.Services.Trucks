using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Data.Contexts;

namespace Volvo.Services.Trucks.Infra.CrossCutting.Ioc
{
    public static class ContextInjection
    {
        public static void AddContext(
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            services.AddDbContext<Context>(x => x.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped<IContext, Context>();
        }
    }
}