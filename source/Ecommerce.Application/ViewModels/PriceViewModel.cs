namespace Ecommerce.Application.ViewModels
{
    public class PriceViewModel
    {
        public int Id { get; set; }
        public int PriceStoreId { get; set; }
        public int PriceProductId { get; set; }
        public bool Promotion { get; set; }
        public double RegularPrice { get; set; }
        public double PromotionalPrice { get; set; }
        public int? PriceGroup { get; set; }
    }
}