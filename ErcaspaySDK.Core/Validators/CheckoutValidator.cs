using FluentValidation;
using ErcaspaySDK.Core.Interfaces;

namespace ErcaspaySDK.Validators;

public class CheckoutValidator : AbstractValidator<IInitiateCheckoutTransactionRequest>
{
    public CheckoutValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0");

        RuleFor(x => x.PaymentReference)
            .NotEmpty()
            .WithMessage("Payment reference is required");

        RuleFor(x => x.PaymentMethods)
            .NotEmpty()
            .WithMessage("Payment methods are required");

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required");

        RuleFor(x => x.CustomerEmail)
            .EmailAddress()
            .WithMessage("A valid email address is required");

        RuleFor(x => x.Currency)
            .Matches("^(NGN|GBP|USD|EUR|CAD)$")
            .WithMessage("Currency must be NGN, GBP, USD, EUR, or CAD");

        RuleFor(x => x.FeeBearer)
            .Must(x => x == null || x == "customer" || x == "merchant")
            .WithMessage("Fee bearer must be 'customer' or 'merchant'");

        RuleFor(x => x.RedirectUrl)
            .Must(x => string.IsNullOrEmpty(x) || Uri.IsWellFormedUriString(x, UriKind.Absolute))
            .WithMessage("Redirect URL must be a valid URL");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description should not exceed 500 characters");
    }
}