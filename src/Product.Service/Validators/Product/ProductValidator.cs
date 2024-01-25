using FluentValidation;

namespace Product.Service.Validators.Product;
using Product = Models.Product;
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100); 

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(500); 

        RuleFor(x => x.SubCategoryId)
            .NotNull();

        RuleFor(x => x.Stock)
            .NotNull()
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Price)
            .NotNull()
            .GreaterThanOrEqualTo(0); 
    }
}