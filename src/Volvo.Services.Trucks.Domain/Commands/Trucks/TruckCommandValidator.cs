using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks
{
    public class TruckCommandValidator :
        AbstractValidator<TruckCommand>
    {
        public TruckCommandValidator()
        {
            RuleFor(p => p.TruckModel)
                .Must(p => p == ETruckModel.FH || p == ETruckModel.FM);

            RuleFor(p => p.FabricationYear)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddYears(-100));
                
            RuleFor(p => p.ModelYear)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddYears(-100));
        }
    }
}