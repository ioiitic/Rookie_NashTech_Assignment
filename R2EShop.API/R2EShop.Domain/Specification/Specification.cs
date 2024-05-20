using LinqKit;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Specification
{
    public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        private readonly List<Expression<Func<TEntity, bool>>> _filters = new List<Expression<Func<TEntity, bool>>>();
        private readonly List<Expression<Func<TEntity, object>>> _includes = new List<Expression<Func<TEntity, object>>>();

        public void Include(Expression<Func<TEntity, object>> include)
        {
            _includes.Add(include);
        }

        public void AddFilter(Expression<Func<TEntity, bool>> filter)
        {
            _filters.Add(filter);
        }

        public IEnumerable<Expression<Func<TEntity, bool>>> Filters => _filters;
        public IEnumerable<Expression<Func<TEntity, object>>> Includes => _includes;
        
        public Expression<Func<TEntity, bool>> ToExpression()
        {
            if (_filters.Count == 0)
            {
                return p => true;
            }

            var predicate = PredicateBuilder.New<TEntity>(true);

            foreach (var filter in _filters)
            {
                predicate = predicate.And(filter);
            }

            return predicate;
        }
    }
}
