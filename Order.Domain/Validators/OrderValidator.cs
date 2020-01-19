using FluentValidation;

namespace OrderApp.Domain.Validators
{
    public class OrderValidator : AbstractValidator<AggregateModels.Order>
    {
        public OrderValidator()
        {
            RuleFor(a => a.AccountNumber)
                .NotEmpty()
                .WithMessage("Invalid AccountNumber");

            RuleFor(a => a.Price)
                .GreaterThan(0)
                .WithMessage("Invalid Price");

            RuleFor(a => a.Quantity)
                .GreaterThan(0)
                .WithMessage("Invalid Quantity");

            RuleFor(a => a.Stock)
                .NotNull()
                .WithMessage("Should have Stock");

            RuleFor(a => a.Operation)
                .IsInEnum()
                .WithMessage("Invalid Operation");

            RuleFor(a => a.Type)
                .IsInEnum()
                .WithMessage("Invalid Type");
        }
    }
}
