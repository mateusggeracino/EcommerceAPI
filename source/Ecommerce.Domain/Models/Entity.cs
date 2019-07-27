using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}