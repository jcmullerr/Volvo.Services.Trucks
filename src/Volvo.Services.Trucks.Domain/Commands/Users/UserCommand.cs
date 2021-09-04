using Volvo.Services.Trucks.Domain.Entities.Security;

namespace Volvo.Services.Trucks.Domain.Commands.Users
{
    public class UserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User MapToUser()
        {
            return new User(
                Name,
                Email,
                Password
            );
        }
    }
}