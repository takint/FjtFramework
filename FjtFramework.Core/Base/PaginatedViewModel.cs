using System.Collections.Generic;

namespace FjtFramework.Cores
{
    public class PaginatedViewModel<TViewModel> where TViewModel : class
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public long Count { get; private set; }

        public IEnumerable<TViewModel> Data { get; private set; }

        public PaginatedViewModel(int pageIndex, int pageSize, long count, IEnumerable<TViewModel> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }
    }
}
