using FluentValidation;
using OrderApp.Domain.AggregateModels;

namespace OrderApp.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(a => a.AccountNumber)
                .NotEmpty()
                .WithMessage("Invalid AccountNumber");

            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty");

            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithMessage("Lastname cannot be empty");

            RuleFor(a => a.DocumentId)
                .NotEmpty().When(a=> (a.Status == CustomerStatusType.OK) || (a.Status == CustomerStatusType.IN_DEBIT))
                .WithMessage("DocumentId cannot be empty");

            RuleFor(a => a.Status)
                .NotEmpty()
                .WithMessage("DocumentId cannot be empty");
        }
    }
}
