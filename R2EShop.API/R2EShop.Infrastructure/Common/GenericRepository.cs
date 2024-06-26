﻿using LinqKit;
using Microsoft.EntityFrameworkCore;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using R2EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Infrastructure.Common
{ 
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private protected MyDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity?> FindFirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (spec != null)
            {
                query = query.Where(spec.ToExpression());

                foreach (var include in spec.Includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> spec)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (spec != null)
            {
                query = query.Where(spec.ToExpression());

                foreach (var include in spec.Includes)
                {
                    query = query.Include(include);
                }

                if (spec.OrderByAscending is not null)
                {
                    query = query.OrderBy(spec.OrderByAscending);
                }
                if (spec.OrderByDescending is not null)
                {
                    query = query.OrderBy(spec.OrderByDescending);
                }
                foreach (var orderby in spec.ThenBys)
                {
                    query = orderby.Item2
                        ? ((IOrderedQueryable<TEntity>)query).ThenByDescending(orderby.Item1)
                        : ((IOrderedQueryable<TEntity>)query).ThenBy(orderby.Item1);
                }

                if (spec.PageNumber > 0 && spec.PageSize >= 0)
                {
                    var skip = (spec.PageNumber - 1) * spec.PageSize;
                    query.Skip(skip).Take(spec.PageSize);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindFromSqlAsync(ISpecification<TEntity> spec, string sql)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (spec != null)
            {
                query = query.Where(spec.ToExpression());

                foreach (var include in spec.Includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public void Update(TEntity existingEntity, TEntity updatedEntity)
        {
            _dbSet.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
