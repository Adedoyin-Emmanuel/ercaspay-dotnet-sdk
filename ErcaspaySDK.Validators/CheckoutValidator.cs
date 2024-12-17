using FluentValidation;
using ErcaspaySDK.Interfaces;

namespace ErcaspaySDK.Validators
{
    public class CheckoutValidator : AbstractValidator<IInitiateCheckoutTransactionRequest>
    {
        public CheckoutValidator()
        {
            RuleFor(x => x.amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than 0");

            RuleFor(x => x.paymentReference)
                .NotEmpty()
                .WithMessage("Payment reference is required");

            RuleFor(x => x.paymentMethods)
                .NotEmpty()
                .WithMessage("Payment methods are required");

            RuleFor(x => x.customerName)
                .NotEmpty()
                .WithMessage("Customer name is required");

            RuleFor(x => x.customerEmail)
                .EmailAddress()
                .WithMessage("A valid email address is required");

            RuleFor(x => x.currency)
                .Matches("^(NGN|GBP|USD|EUR|CAD)$")
                .WithMessage("Currency must be NGN, GBP, USD, EUR, or CAD");

            RuleFor(x => x.feeBearer)
                .Must(x => x == null || x == "customer" || x == "merchant")
                .WithMessage("Fee bearer must be 'customer' or 'merchant'");

            RuleFor(x => x.redirectUrl)
                .Must(x => string.IsNullOrEmpty(x) || Uri.IsWellFormedUriString(x, UriKind.Absolute))
                .WithMessage("Redirect URL must be a valid URL");

            RuleFor(x => x.description)
                .MaximumLength(500)
                .WithMessage("Description should not exceed 500 characters");
        }
    }
}