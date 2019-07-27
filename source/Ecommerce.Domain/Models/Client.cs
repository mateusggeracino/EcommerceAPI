using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce.Domain.Models
{
    [Table("customers")]
    public class Client : Entity
    {
        public string Type { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}