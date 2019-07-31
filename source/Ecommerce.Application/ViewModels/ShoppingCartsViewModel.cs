using System;

namespace Ecommerce.Application.ViewModels
{
    public class ShoppingCartsViewModel
    {
        public int CartCustomerId { get; set; }
        public int CartStoreId { get; set; }
        public int CartProductId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CartCreation { get; set; }
        public DateTime CartExpiring { get; set; }
        public int CartStatus { get; set; }
    }
}