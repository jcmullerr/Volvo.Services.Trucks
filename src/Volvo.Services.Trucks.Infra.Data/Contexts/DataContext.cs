using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volvo.Services.Trucks.Domain.Entities;
using Volvo.Services.Trucks.Domain.Interfaces;

namespace Volvo.Services.Trucks.Infra.Data.Contexts
{
    public class DataContext : DbContext , IDataContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Model> Models { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
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

        public async Task<int> SaveChanges(
            CancellationToken cancellationToken = default
        )
        {
            return await SaveChangesAsync(cancellationToken);
        }
    }
}