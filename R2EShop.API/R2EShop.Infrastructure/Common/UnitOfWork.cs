﻿using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UnitOfWork(
            MyDbContext dbContext,
            IUserRepository userRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IUserRepository Users => _userRepository;
        public IProductRepository Products => _productRepository;
        public ICategoryRepository Categories => _categoryRepository;

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
