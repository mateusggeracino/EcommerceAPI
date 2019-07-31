using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Ecommerce.Domain.Models
{
    public abstract class Entity //: AbstractValidator<Entity>
    {
        [Key]
        public int Id { get; set; }

        [Write(false)]
        public ValidationResult ValidationResult { get; set; }
    }
}