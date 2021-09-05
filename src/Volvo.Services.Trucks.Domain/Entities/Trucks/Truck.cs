using System;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;

namespace Volvo.Services.Trucks.Domain.Entities.Trucks
{
    public class Truck : Entity
    {
        public string Description { get; private set; }
        public int ModelYear { get; private set; }
        public int FabricationYear { get; private set; }
        public ETruckModel TruckModel { get; private set; }
        public Truck()
        { }

        public Truck(
            long id,
            string description,
            int modelYear,
            int fabricationYear,
            ETruckModel truckModel
        )
        {
            Description = description;
            ModelYear = modelYear;
            FabricationYear = fabricationYear;
            TruckModel = truckModel;
            Id = id;
        }

        public Truck(
            string description,
            int modelYear,
            int fabricationYear,
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