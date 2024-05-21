using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.Interface.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> FindFirstOrDefaultAsync(ISpecification<TEntity> spec);
        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> spec);
        Task<IEnumerable<TEntity>> FindFromSqlAsync(ISpecification<TEntity> spec, string sql);
        Task<TEntity?> GetByIdAsync(object id);
        Task AddAsync(TEntity entity);
        void Update(TEntity existingEntity, TEntity updatedEntity);
        void Delete(TEntity entity);
    }
}
