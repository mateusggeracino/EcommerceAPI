using Dapper.Contrib.Extensions;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Ecommerce.Domain.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }

        [Write(false)]
        public ValidationResult ValidationResult { get; set; }
    }
}