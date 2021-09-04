using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volvo.Services.Trucks.Domain.Entities;
using Volvo.Services.Trucks.Domain.Entities.Security;
using Volvo.Services.Trucks.Domain.Entities.Trucks;
using Volvo.Services.Trucks.Domain.Interfaces;

namespace Volvo.Services.Trucks.Infra.Data.Contexts
{
    public class Context : DbContext , IContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<T> GetDbSet<T>() where T : Entity, new()
        {
            Type type = this.GetType();
            Type repositoryType = typeof(DbSet<>).MakeGenericType(typeof(T));

            var propertyInfo =
                type
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType == repositoryType);

            return (DbSet<T>)propertyInfo.GetValue(this);
        }
    }
}