using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Product.Service.Validators.SubCategory
{
    public class SubCategoryValidator : AbstractValidator<Models.SubCategory>
    {
        public SubCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty(); // Assuming Id should not be empty

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100); // Adjust the maximum length as needed

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500); // Adjust the maximum length as needed

            //RuleFor(x => x.ProductIds)
            //    .NotNull(); 
            //
            RuleFor(x => x.ParentCategoryId)
                .NotEmpty()
                .WithMessage("ParentCategoryId must not be empty.");
            //RuleFor(x => x.CreatedAt)
            //    .NotEmpty()
            //    .Must(BeAValidDate);
            //
            //RuleFor(x => x.UpdatedAt)
            //    .NotEmpty()
            //    .Must(BeAValidDate) 
            //    .GreaterThan(x => x.CreatedAt); 
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default(DateTime);
        }
    }
}