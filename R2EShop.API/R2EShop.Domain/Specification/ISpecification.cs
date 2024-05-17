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
        Expression<Func<TEntity, bool>> ToExpression();
        void Include(Expression<Func<TEntity, object>> include);
    }
}
