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
    public class FindSubCategory : IRequestHandler<FindSubCategoryRequest, SubCategory>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ILogger<FindSubCategory> _logger;

        public FindSubCategory(ISubCategoryRepository subCategoryRepository, ILogger<FindSubCategory> logger)
        {
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<SubCategory> Handle(FindSubCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Handling request to find Subcategory with ID: {request.Id}");

                var subCategory = await _subCategoryRepository.FindById(request.Id);
                if (subCategory is not null)
                {
                    _logger.LogInformation($"Subcategory with ID {request.Id} found.");

                    return subCategory;
                }

                _logger.LogInformation($"Subcategory with ID {request.Id} not found.");

                throw new AppException($"Subcategory with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while handling the request to find Subcategory with ID: {request.Id}");

                throw new AppException("Error while handling the request", ex);
            }
        }
    }
}