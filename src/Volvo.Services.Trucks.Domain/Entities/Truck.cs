using System;
namespace Volvo.Services.Trucks.Domain.Entities
{
    public class Truck : Entity
    {
        public string Description { get; private set; }
        public DateTime ModelYear { get; private set; }
        public DateTime FabricationYear { get; private set; }
    }
}