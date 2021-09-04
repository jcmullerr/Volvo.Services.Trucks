using System;
using FluentValidation;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Update
{
    public class UpdateTruckCommandValidator : AbstractValidator<UpdateTruckCommand>
    {
        public UpdateTruckCommandValidator()
        {
            RuleFor(p => p.TruckModel)
                .Must(p => p == ETruckModel.FH || p == ETruckModel.FM);

            RuleFor(p => p.FabricationYear)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddYears(-100));
                
            RuleFor(p => p.ModelYear)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddYears(-100));
            
            
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}