using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volvo.Services.Trucks.Domain.Entities;

namespace Volvo.Services.Trucks.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity, new()
    {
        Task<bool> DeleteAsync(long id);
        Task<bool> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTrcking = false);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQuery();
    }
}