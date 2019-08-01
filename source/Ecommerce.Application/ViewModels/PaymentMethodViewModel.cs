using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.ViewModels
{
    public class PaymentMethodViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int SupplierId { get; set; }
        public string EndPointName { get; set; }
    }
}
