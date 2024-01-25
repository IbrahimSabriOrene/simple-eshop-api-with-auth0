using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Product;
using Product.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Service.Product;
using Product = Models.Product;
public class ProductsGetAll
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductsGetAll> _logger;

    public ProductsGetAll(IProductRepository productRepository, ILogger<ProductsGetAll> logger)
    {
        _productRepository = productRepository;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<Product>> GetAllService()
    {
        try
        {
            _logger.LogInformation("Handling request to retrieve all products");

            var products = await _productRepository.GetAll();

            var allService = products as Product[] ?? products.ToArray();
            if (products is null || !allService.Any())
            {
                _logger.LogWarning("Warning! No products were found.");
                throw new AppException("Products retrieval failed: No products were found.");
            }

            return allService;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while handling the request to retrieve all products");
            throw new AppException("Error while handling the request", ex);
        }
    }
}