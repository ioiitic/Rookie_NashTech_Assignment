using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Infrastructure.Data;
using R2EShop.Infrastructure.Repositories;
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
        private readonly IDeviceRepository _deviceRepository;
        private readonly ICaseColorRepository _caseColorRepository;
        private readonly ICaseTypeRepository _caseTypesRepository;

        public UnitOfWork(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _userRepository = new UserRepository(_dbContext);
            _categoryRepository = new CategoryRepository(_dbContext);
            _deviceRepository = new DeviceRepository(_dbContext);
            _caseColorRepository = new CaseColorRepository(_dbContext);
            _caseTypesRepository = new CaseTypeRepository(_dbContext);
        }

        public IUserRepository Users => _userRepository;
        public IProductRepository Products => _productRepository;
        public ICategoryRepository Categories => _categoryRepository;
        public IDeviceRepository Devices => _deviceRepository;
        public ICaseColorRepository CaseColors => _caseColorRepository;
        public ICaseTypeRepository CaseTypes => _caseTypesRepository;

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
