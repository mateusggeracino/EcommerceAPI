using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce.Domain.Models
{
    [Table("Users.Customers",Schema="Users")]
    public class Client : Entity
    {
        public string CustomerType { get; set; }
        public string CustomerDocument { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTelephone { get; set; }
        public string CustomerEmail { get; set; }
    }
}