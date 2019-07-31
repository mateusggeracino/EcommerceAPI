using Ecommerce.Domain.Models;
using FluentValidation;

namespace Ecommerce.Domain.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.CustomerDocument)
                .NotEmpty().WithMessage("Document is required");

            RuleFor(x => x.CustomerEmail)
                .NotEmpty().WithMessage("Email is required");

            RuleFor(x => x.CustomerGender)
                .NotEmpty().WithMessage("Gender is required");

            RuleFor(x => x.CustomerAddress)
                .NotEmpty().WithMessage("Address is required");

            RuleFor(x => x.CustomerType)
                .NotEmpty().WithMessage("Type is required");

            RuleFor(x => x.CustomerTelephone)
                .NotEmpty().WithMessage("Telephone is required");
        }
    }
}