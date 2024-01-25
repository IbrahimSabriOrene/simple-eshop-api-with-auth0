using FluentValidation;

namespace Product.Service.Validators.Category;
using Category = Models.Category;
public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty(); 

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100); 

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(500); 
    }
}