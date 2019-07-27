namespace Ecommerce.Application.ViewModels
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public int StockStoreId { get; set; }
        public int StockProductId { get; set; }
        public int RealStock { get; set; }
        public int VirtualStock { get; set; }
    }
}