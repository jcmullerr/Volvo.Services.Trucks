using System.Threading.Tasks;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Data.Contexts;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private readonly INotificationContext _notificationContext;

        public UnitOfWork(Context context, INotificationContext notificationContext)
        {
            _context = context;
            _notificationContext = notificationContext;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await Task.Run(() => _context.Database.CommitTransaction());
        }

        public async Task RollbackTransactionAsync()
        {
            await Task.Run(() => _context.Database.RollbackTransaction());
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (_notificationContext.HasNotifications)
            {
                return false;
            }

            await _context.SaveChangesAsync();

            return true;
        }

    }
}