namespace Ecommerce.Application.ViewModels
{
    public class StockViewModel
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int RealStock { get; set; }
        public int VirtualStock { get; set; }
    }
}