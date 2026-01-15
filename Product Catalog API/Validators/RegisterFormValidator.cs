using FluentValidation;
using Product_Catalog_API.Models;

namespace Product_Catalog_API.Validators;

public class RegisterFormValidator : AbstractValidator<RegisterForm>
{
    public RegisterFormValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
}