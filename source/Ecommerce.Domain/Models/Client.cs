using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    [Table("Client")]
    public class Client : Entity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Social_Number")]
        public string SocialNumber { get; set; }
        public string Email { get; set; }
    }
}