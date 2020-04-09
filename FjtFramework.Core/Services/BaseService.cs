using AutoMapper;
using FjtFramework.Cores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FjtFramework.CoreServices
{
    public class BaseService<TModel, TDbContext>
        where TModel : BaseEntity
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        protected readonly DbSet<TModel> _dbSet;
        protected readonly IMapper _mapper;

        public BaseService(TDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TModel>();
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<long> RecordsCountAsync()
        {
            return await _dbSet.LongCountAsync();
        }

        public async Task<IEnumerable<TViewModel>> ListAsync<TViewModel>(BaseListRequest request) where TViewModel : BaseViewModel
        {
            var models = await _dbSet.Skip(request.PageSize * request.PageIndex)
                .Take(request.PageSize)
                .ToListAsync();

            var recordCount = await _dbSet.LongCountAsync();
            var entities = _mapper.Map<IEnumerable<TViewModel>>(models);
            var result = new PaginatedViewModel<TViewModel>(request.PageIndex, request.PageSize, recordCount, entities);

            return _mapper.Map<IEnumerable<TViewModel>>(models);
        }

        public async Task<IEnumerable<TViewModel>> GetAllAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            var models = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TViewModel>>(models);
        }

        public async Task<TViewModel> GetByIdAsync<TViewModel>(int id) where TViewModel : BaseViewModel
        {
            var model = await _dbSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
            return _mapper.Map<TViewModel>(model);
        }

        public virtual async Task<TViewModel> CreateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            viewModel.ValidateAndThrow();

            TModel model = _mapper.Map<TModel>(viewModel);

            var error = await ValidateDatabaseBeforeAddOrUpdateAsync(model);
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error); // TODO: Implement application exception
            }

            _dbSet.Add(model);
            await _dbContext.SaveChangesAsync();

            viewModel = _mapper.Map<TViewModel>(model);
            return viewModel;
        }

        public virtual async Task<TViewModel> UpdateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            viewModel.ValidateAndThrow();

            var model = _mapper.Map<TModel>(viewModel);

            var error = await ValidateDatabaseBeforeAddOrUpdateAsync(model);
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            _dbSet.Update(model);
            await _dbContext.SaveChangesAsync();

            model = await _dbSet.SingleOrDefaultAsync(e => e.Id.Equals(model.Id));

            viewModel = _mapper.Map<TViewModel>(model);
            return viewModel;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var model = await _dbSet.SingleOrDefaultAsync(e => e.Id.Equals(id));

            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        protected virtual Task<string> ValidateDatabaseBeforeAddOrUpdateAsync(TModel model)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
