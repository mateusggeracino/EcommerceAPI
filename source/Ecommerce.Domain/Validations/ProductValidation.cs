using Ecommerce.Domain.Models;
using FluentValidation;

namespace Ecommerce.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Brand)
                .MaximumLength(50).WithMessage("Brand max 50 characters");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("ProductDescription is required")
                .MaximumLength(100).WithMessage("ProductDescription max 100 characters");

            RuleFor(x => x.ProductStatus)
                .NotNull().WithMessage("Status is required");

            RuleFor(x => x.ProductType)
                .MaximumLength(20).WithMessage("Type max 20 characters");

            RuleFor(x => x.ProductSpecs)
                .NotEmpty().WithMessage("Specs is required")
                .MaximumLength(50).WithMessage("Specs max 50 characters");
        }
    }
}