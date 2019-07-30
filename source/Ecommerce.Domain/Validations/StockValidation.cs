using Ecommerce.Domain.Models;
using FluentValidation;

namespace Ecommerce.Domain.Validations
{
    public class StockValidation : AbstractValidator<Stock>
    {
        public bool IsValid(Stock stock)
        {
            RuleFor(x => x.RealStock)
                .NotEmpty().WithMessage("RealStock is empty");

            RuleFor(x => x.VirtualStock)
                .NotEmpty().WithMessage("VirtualStock is empty");

            return Validate(stock).IsValid;
        }
    }
}