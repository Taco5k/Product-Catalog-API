using FluentValidation;
using Product_Catalog_API.Models;

namespace Product_Catalog_API.Validators
{
    public class LoginFormValidator : AbstractValidator<LoginForm>
    {
        public LoginFormValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}