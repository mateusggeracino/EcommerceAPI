﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Order : Entity
    {
        public int OrderCartId { get; set; }
        public DateTime OrderCreation { get; set; }
        public DateTime OrderExpiring { get; set; }
        public int OrderStatus { get; set; }
    }
}
