using Ecommerce.Domain.Models;
using FluentValidation;

namespace Ecommerce.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("ProductDescription is required");

            RuleFor(x => x.ProductStatus)
                .NotEmpty().WithMessage("Status is required");

            RuleFor(x => x.ProductType)
                .NotEmpty().WithMessage("Type is required");

            RuleFor(x => x.Specs)
                .NotEmpty().WithMessage("Specs is required");
        }
    }
}