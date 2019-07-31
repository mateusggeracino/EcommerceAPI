using Ecommerce.Domain.Models;
using FluentValidation;

namespace Ecommerce.Domain.Validations
{
    public class StockValidation : AbstractValidator<Stock>
    {
        public StockValidation()
        {
            RuleFor(x => x.RealStock)
                .GreaterThan(0).WithMessage("RealStock less than 0");

            RuleFor(x => x.VirtualStock)
                .GreaterThan(0).WithMessage("VirtualStock  less than 0");
        }
    }
}