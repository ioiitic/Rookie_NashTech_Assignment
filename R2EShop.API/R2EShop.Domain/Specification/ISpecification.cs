using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Specification
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        IEnumerable<Expression<Func<TEntity, object>>> Includes { get; }
        Expression<Func<TEntity, object>>? OrderByAscending { get; }
        Expression<Func<TEntity, object>>? OrderByDescending { get; }
        IEnumerable<Tuple<Expression<Func<TEntity, object>>, bool>> ThenBys { get; }
        int PageNumber { get; }
        int PageSize { get; }
        Expression<Func<TEntity, bool>> ToExpression();
        ISpecification<TEntity> AddFilter(Expression<Func<TEntity, bool>> filter);
        ISpecification<TEntity> Include(Expression<Func<TEntity, object>> include);
        ISpecification<TEntity> OrderBy(Expression<Func<TEntity, object>> orderBy, bool isDescending);
        ISpecification<TEntity> ThenBy(Expression<Func<TEntity, object>> thenBy, bool isDescending);
        ISpecification<TEntity> AddPagination(int pageNumber, int pageSize);
    }
}
