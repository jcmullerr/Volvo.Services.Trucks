using System;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Volvo.Services.Trucks.Infra.CrossCutting.PipelineBehavior;

namespace Volvo.Services.Trucks.Infra.CrossCutting.Ioc
{
    public static class MediatorInjection
    {
        private static Assembly DomainAssembly => AppDomain.CurrentDomain.Load("Volvo.Services.Trucks.Domain");

        public static void AddMediator(this IServiceCollection services)
        {

            AssemblyScanner
                .FindValidatorsInAssembly(DomainAssembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(DomainAssembly); 
        }
    }

}