using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Category;
using Product.Infrastructure.Subcategory;
using Product.Models;
using Product.Models.Requests;
using Product.Service.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Service.Subcategory
{
    public class CreateSubCategory : IRequestHandler<SubCategoryRequest, SubCategory>
    {
        private readonly ILogger<CreateSubCategory> _logger;
        private readonly ISubCategoryRepository _subCategory;
        private readonly ICategoryRepository _category;

        public CreateSubCategory(ISubCategoryRepository subCategory, ICategoryRepository category, ILogger<CreateSubCategory> logger)
        {
            _subCategory = subCategory ?? throw new ArgumentNullException(nameof(subCategory));
            _category = category ?? throw new ArgumentNullException(nameof(category));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<SubCategory> Handle(SubCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Handling request to create Subcategory with Name: {request.Name}, ParentCategoryId: {request.ParentCategoryId}");

                await ValidateRequestAsync(request);

                var subCategory = new SubCategory(
                    Guid.NewGuid(),
                    request.Name,
                    request.Description, // This is null for now.
                    request.ParentCategoryId
                    // DateTime.Now,
                    // DateTime.Now
                );

                await _subCategory.Add(subCategory);

                _logger.LogInformation($"Subcategory created successfully with ID: {subCategory.Id}");

                return subCategory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling the request to create Subcategory");
                throw new AppException("Error while handling the request");
            }
        }

        private async Task ValidateRequestAsync(SubCategoryRequest request)
        {
            _logger.LogInformation($"Validating request for Subcategory creation with ParentCategoryId: {request.ParentCategoryId}");

            var category = await _category.FindById(request.ParentCategoryId);
            if (category?.Id != request.ParentCategoryId)
            {
                _logger.LogInformation("Category ID mismatch");
                throw new ArgumentException("Category ID mismatch");
            }
        }
    }
}
