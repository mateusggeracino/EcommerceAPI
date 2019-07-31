using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Domain.Models
{
    public abstract class Entity //: AbstractValidator<Entity>
    {
        public int Id { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}