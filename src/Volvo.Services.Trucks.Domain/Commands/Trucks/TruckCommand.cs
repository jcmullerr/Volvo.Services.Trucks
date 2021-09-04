using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks
{
    public class TruckCommand
    {
        public string Description { get; set; }
        public DateTime ModelYear { get; set; }
        public DateTime FabricationYear { get; set; }
        public ETruckModel TruckModel { get; set; }
        public Truck MapToTruck()
        {
            return new Truck(
                Description,
                ModelYear,
                FabricationYear,
                TruckModel
            );
        }
    }
}