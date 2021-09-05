using System;
using FluentValidation;
using Volvo.Services.Trucks.Infra.CrossCutting.Enums;

namespace Volvo.Services.Trucks.Domain.Commands.Trucks.Add
{
    public class AddTruckCommandValidator : AbstractValidator<AddTruckCommand>
    {
        public AddTruckCommandValidator()
        {
            RuleFor(p => p.TruckModel)
                .Must(p => p == ETruckModel.FH || p == ETruckModel.FM);

            RuleFor(p => p.FabricationYear)
                .NotEmpty()
                .GreaterThan(DateTime.Now.Year - 100);

            RuleFor(p => p.ModelYear)
                .NotEmpty()
                .GreaterThan(DateTime.Now.Year - 100)
                .GreaterThanOrEqualTo(p => p.FabricationYear);
        }
    }
}