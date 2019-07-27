using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce.Domain.Models
{
    [Table("customers")]
    public class Client : Entity
    {
        [Column("customer_type")]
        public string Type { get; set; }
        [Column("customer_document")]
        public string Document { get; set; }
        [Column("customer_name")]
        public string Name { get; set; }
        [Column("customer_gender")]
        public string Gender { get; set; }
        [Column("customer_address")]
        public string Address { get; set; }
        [Column("customer_telephone")]
        public string Telephone { get; set; }
        [Column("customer_email")]
        public string Email { get; set; }
    }
}