using System;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;

namespace Volvo.Services.Trucks.Domain.Entities.Trucks
{
    public class Truck : Entity
    {
        public string Description { get; private set; }
        public DateTime ModelYear { get; private set; }
        public DateTime FabricationYear { get; private set; }
        public ETruckModel TruckModel { get; private set; }

        public Truck(
            string description,
            DateTime modelYear,
            DateTime fabricationYear,
            ETruckModel truckModel
        )
        {
            Description = description;
            ModelYear = modelYear;
            FabricationYear = fabricationYear;
            TruckModel = truckModel;
        }
    }
}