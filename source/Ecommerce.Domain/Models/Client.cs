using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    public class Client : Entity
    {
        [Column("Name")]
        public string Name { get; set; }
        public string SocialNumber { get; set; }
        public string Email { get; set; }
    }
}