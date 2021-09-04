using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volvo.Services.Trucks.Domain.Entities;
using Volvo.Services.Trucks.Domain.Interfaces;
using Volvo.Services.Trucks.Infra.Data.Contexts;

namespace Volvo.Services.Trucks.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly DbSet<T> _dbSet;

        public Repository(Context context)
        {
            _dbSet = context.GetDbSet<T>();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var data = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                _dbSet.Remove(data);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetQuery().Where(predicate).ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTrcking = false)
        {
            if (noTrcking)
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);

            return await GetQuery().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> InsertAsync(T model)
        {
            try
            {
                model.SetInsertDate();
                await _dbSet.AddAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(T model)
        {
            try
            {
                model.SetUpdateDate();
                await Task.Run(() => {
                    _dbSet.Update(model);
                });
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public virtual IQueryable<T> GetQuery()
        {
            /*
             Criar expression para carregar objetos relacionados
             */
            var query = _dbSet;
            var expression = new List<Expression<Func<T, object>>>();

            Type type = typeof(T);
            foreach (var prop in type.GetProperties().Where(p => p.GetMethod.IsVirtual))
            {
                var parameterExpression = Expression.Parameter(type);
                var exp = Expression.PropertyOrField(parameterExpression, prop.Name);
                var lamb = Expression.Lambda<Func<T, object>>(exp, parameterExpression);
                query.Include(lamb);
            }

            return query.AsQueryable();
        }
    }
}