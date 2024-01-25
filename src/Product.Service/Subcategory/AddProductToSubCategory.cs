using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Product;
using Product.Infrastructure.Subcategory;
using Product.Models;
using Product.Models.Requests;
using Product.Service.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Service.Subcategory
{
    public class AddProductToSubCategory : IRequestHandler<AddProductToSubCategoryRequest, SubCategory>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ILogger<AddProductToSubCategory> _logger;

        public AddProductToSubCategory(IProductRepository productRepository, ISubCategoryRepository subCategoryRepository, ILogger<AddProductToSubCategory> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<SubCategory> Handle(AddProductToSubCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Handling request to add product with ID {request.ProductId} to subcategory with ID {request.SubCategoryId}");

                var product = await _productRepository.FindById(request.ProductId);
                if (product is not null)
                {
                    _logger.LogInformation($"Product with ID {request.ProductId} found.");

                    var subcategory = await _subCategoryRepository.FindById(request.SubCategoryId);

                    if (subcategory != null)
                    {
                        _logger.LogInformation($"Subcategory with ID {request.SubCategoryId} found.");

                        //subcategory.ProductIds?.Add(request.ProductId);
                        await _subCategoryRepository.UpdateAsync(subcategory);

                        _logger.LogInformation($"Product added to Subcategory successfully.");

                        return subcategory;
                    }
                }

                _logger.LogInformation($"Product with ID {request.ProductId} or Subcategory with ID {request.SubCategoryId} not found.");

                throw new AppException($"Product or Subcategory not found for the given IDs");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while handling the request to add product with ID {request.ProductId} to subcategory with ID {request.SubCategoryId}");

                throw new AppException("Error while handling the request", ex);
            }
        }
    }
}
