using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.ViewModels
{
    public class PaymentViewModel
    {
        public int OrderId { get; set; }
        public int PayPMId { get; set; }
        public int PayStatus { get; set; }
    }
}
