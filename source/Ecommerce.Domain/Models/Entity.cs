using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}