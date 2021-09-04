using Microsoft.Extensions.DependencyInjection;

namespace Volvo.Services.Trucks.Infra.CrossCutting.Ioc
{
    public static class SettingsInjection
    {
        public static void AddSettings(this IServiceCollection services)
        {
            services.AddScoped<AuthSettings>();
        }
    }
}