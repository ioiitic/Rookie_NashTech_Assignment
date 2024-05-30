using LinqKit;
using R2EShop.Domain.Entities;
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
        private Expression<Func<TEntity, object>>? _orderByAscending;
        private Expression<Func<TEntity, object>>? _orderByDescending;
        private readonly List<Tuple<Expression<Func<TEntity, object>>, bool>> _thenBys = new List<Tuple<Expression<Func<TEntity, object>>, bool>>();
        private bool _isDescending = false;
        private int _pageNumber = 0;
        private int _pageSize = 0;

        public ISpecification<TEntity> Include(Expression<Func<TEntity, object>> include)
        {
            _includes.Add(include);
            return this;
        }

        public ISpecification<TEntity> AddFilter(Expression<Func<TEntity, bool>> filter)
        {
            _filters.Add(filter);
            return this;
        }

        public ISpecification<TEntity> OrderBy(Expression<Func<TEntity, object>> orderBy, bool isDescending)
        {
            if (!isDescending)
            {
                _orderByAscending = orderBy;
                _orderByDescending = null;
            } else
            {
                _orderByAscending = null;
                _orderByDescending = orderBy;
            }
            return this;
        }

        public ISpecification<TEntity> ThenBy(Expression<Func<TEntity, object>> thenBy, bool isDescending)
        {
            _thenBys.Add(Tuple.Create(thenBy, isDescending));
            return this;
        }

        public ISpecification<TEntity> AddPagination(int pageNumber, int pageSize)
        {
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            return this;
        }

        public IEnumerable<Expression<Func<TEntity, bool>>> Filters => _filters;
        public IEnumerable<Expression<Func<TEntity, object>>> Includes => _includes;
        public Expression<Func<TEntity, object>>? OrderByAscending => _orderByAscending;
        public Expression<Func<TEntity, object>>? OrderByDescending => _orderByDescending;
        public IEnumerable<Tuple<Expression<Func<TEntity, object>>, bool>> ThenBys => _thenBys;
        public int PageNumber => _pageNumber;
        public int PageSize => _pageSize;

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
