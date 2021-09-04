using System.Threading.Tasks;

namespace Volvo.Services.Trucks.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}