using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    [Table( "Store", Schema = "Users")]
    public class Store : Entity
    {
        [Column("store_name")]
        public string Name { get; set; }
        [Column( "store_address" )]
        public string Address { get; set; }
        [Column( "store_telephonex" )]
        public string Telephone { get; set; }
    }
}
