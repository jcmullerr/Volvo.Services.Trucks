using Volvo.Services.Trucks.Domain.Entities.Security;

namespace Volvo.Services.Trucks.Domain.Interfaces.Authentication
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}