using FluentValidation;
using Product_Catalog_API.Models.Products;
namespace Product_Catalog_API.Validators

{
    public class ProductFormValidator : AbstractValidator<ProductForm>
    {
        public ProductFormValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500);

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required")
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}