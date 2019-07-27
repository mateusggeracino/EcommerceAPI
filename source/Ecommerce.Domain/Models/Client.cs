using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD

namespace Ecommerce.Domain.Models
{
    [Table("Client")]
    public class Client : Entity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Social_Number")]
        public string SocialNumber { get; set; }
=======
using System.Reflection.Metadata.Ecma335;

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
>>>>>>> f1b0fad395b9ff4383ba549e1712f54cb2399b95
        public string Email { get; set; }
    }
}