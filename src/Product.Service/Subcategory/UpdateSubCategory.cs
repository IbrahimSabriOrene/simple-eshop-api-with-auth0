using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Subcategory;
using Product.Models;
using Product.Models.Requests;
using Product.Service.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Service.Subcategory
{
    public class UpdateSubCategory : IRequestHandler<UpdateSubCategoryRequest, SubCategory>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ILogger<UpdateSubCategory> _logger;

        public UpdateSubCategory(ISubCategoryRepository subCategoryRepository, ILogger<UpdateSubCategory> logger)
        {
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<SubCategory> Handle(UpdateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Handling request to update Subcategory with ID: {request.Id}");

                var subCategory = await _subCategoryRepository.FindById(request.Id);
                if (subCategory is not null)
                {
                    _logger.LogInformation($"Subcategory with ID {request.Id} found. Updating...");

                    subCategory = subCategory with
                    {
                        Name = request.Name,
                        ParentCategoryId = request.ParentCategoryId,
                        Description = request.Description,
                        //UpdatedAt = DateTime.Now
                    };

                    await _subCategoryRepository.UpdateAsync(subCategory);

                    _logger.LogInformation($"Subcategory with ID {request.Id} updated successfully.");

                    return subCategory;
                }

                _logger.LogInformation($"Subcategory with ID {request.Id} not found.");
                throw new AppException($"Subcategory with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while handling the request to update Subcategory with ID: {request.Id}");

                throw new AppException("Error while handling the request", ex);
            }
        }
    }
}
