using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volvo.Services.Trucks.Domain.Entities;

namespace Volvo.Services.Trucks.Domain.Interfaces
{
    public interface IContext
    {
        DbSet<T> GetDbSet<T>() where T : Entity, new();
        void Migrate();
    }
}