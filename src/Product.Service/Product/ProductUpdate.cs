using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Product;
using Product.Models.Requests;
using Product.Service.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Service.Product;
using Product = Models.Product;

public class ProductUpdate : IRequestHandler<UpdateProductRequest, Product>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductUpdate> _logger;

    public ProductUpdate(IProductRepository productRepository, ILogger<ProductUpdate> logger)
    {
        _productRepository = productRepository;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Product> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling request to update product with ID: {request.Id}");

            var product = await _productRepository.FindById(request.Id);
    
            if (product is null)
            {
                _logger.LogWarning($"Warning! Product with ID {request.Id} not found.");
                throw new AppException($"Product with ID {request.Id} not found.");
            }

            var updatedProduct = new Product(
                id: product.Id,
                subCategoryId: request.SubCategoryId,
                name: request.Name,
                description: request.Description,
                price: request.Price,
                image: request.Image,
                stock: request.Stock,
                createdAt: product.CreatedAt,
                updatedAt: DateTime.Now
            );

            _logger.LogInformation($"Updated product with ID: {request.Id}");

            await _productRepository.UpdateAsync(updatedProduct);

            return updatedProduct;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update product.");
            throw new AppException("Failed to update product.", ex);
        }
    }
}