using Ecommerce.Domain.Models;
using FluentValidation;

namespace Ecommerce.Domain.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name max 100 characters");

            RuleFor(x => x.CustomerDocument)
                .NotEmpty().WithMessage("Document is required")
                .MaximumLength(14).WithMessage("Document max 14 characters"); ;

            RuleFor(x => x.CustomerEmail)
                .MaximumLength(100).WithMessage("Email max 100 characters");

            RuleFor(x => x.CustomerGender)
                .MaximumLength(2).WithMessage("Gender max 2 characters");

            RuleFor(x => x.CustomerAddress)
                .MaximumLength(100).WithMessage("Address max 100 characters");

            RuleFor(x => x.CustomerType)
                .MaximumLength(1).WithMessage("Type max 1 characters");

            RuleFor(x => x.CustomerTelephone)
                .MaximumLength(12).WithMessage("Telephone max 12 characters");
        }
    }
}