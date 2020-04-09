using FjtFramework.Cores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FjtFramework.Interfaces
{
    public interface IBaseService : IDisposable
    {
        Task<TViewModel> CreateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;

        Task<TViewModel> UpdateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;

        Task<bool> DeleteAsync(int id);

        Task<TViewModel> GetByIdAsync<TViewModel>(int id) where TViewModel : BaseViewModel;

        Task<IEnumerable<TViewModel>> GetAllAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task<IEnumerable<TViewModel>> ListAsync<TViewModel>(BaseListRequest request) where TViewModel : BaseViewModel;

        Task<long> RecordsCountAsync();
    }
}
