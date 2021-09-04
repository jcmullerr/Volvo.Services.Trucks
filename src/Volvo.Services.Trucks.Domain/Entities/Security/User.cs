namespace Volvo.Services.Trucks.Domain.Entities.Security
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}