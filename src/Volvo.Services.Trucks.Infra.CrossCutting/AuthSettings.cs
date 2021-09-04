using Microsoft.Extensions.Configuration;

namespace Volvo.Services.Trucks.Infra.CrossCutting
{
    public class AuthSettings
    {
        public string Key { get; set; }

        public AuthSettings(IConfiguration configuration)
        {
            configuration.Bind(nameof(AuthSettings), this);
        }
    }
}