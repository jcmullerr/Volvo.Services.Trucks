using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks
{
    public abstract class TruckCommand
    {

        public long? Id { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public ETruckModel TruckModel { get; set; }
        
        public Truck MapToTruck(bool isUpdate = false)
        {
            if(isUpdate)
                return new Truck(
                    Id.GetValueOrDefault(),
                    Description,
                    ModelYear,
                    FabricationYear,
                    TruckModel
                );
            
            return new Truck(
                    Description,
                    ModelYear,
                    FabricationYear,
                    TruckModel
                );
        }
    }
}