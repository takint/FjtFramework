namespace FjtFramework.Cores
{
    public class BaseListRequest
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public string FiltersCriteria { get; set; }
    }
}
