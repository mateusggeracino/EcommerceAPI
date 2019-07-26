namespace Ecommerce.Domain.Models
{
    public class Client : Entity
    {
        public string Name { get; set; }
        public string SocialNumber { get; set; }
        public string Email { get; set; }
    }
}