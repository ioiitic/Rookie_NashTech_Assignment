using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.Interface.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(object id);
    }
}
