using Product_Catalog_API.Models.Products;
using FluentValidation;
namespace Product_Catalog_API.Validators;



public class ProductUpdateValidator : AbstractValidator<ProductUpdate>
{
    public ProductUpdateValidator()
    {
     
        RuleFor(x => x.Name)
            .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.")
            .When(x => x.Name != null);

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.")
            .When(x => x.Description != null);

        RuleFor(x => x.Category)
            .MaximumLength(100).WithMessage("Category cannot exceed 100 characters.")
            .When(x => x.Category != null);
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.")
            .When(x => x.Price.HasValue);
    }
}
