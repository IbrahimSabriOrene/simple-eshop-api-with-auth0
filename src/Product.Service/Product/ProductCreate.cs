using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Product;
using Product.Infrastructure.Subcategory;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Product;
using Product = Models.Product;
public class ProductCreate : IRequestHandler<ProductRequest, Product>
{
    private readonly IProductRepository _productRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ILogger<ProductCreate> _logger;

    public ProductCreate(IProductRepository productRepository, ISubCategoryRepository subCategoryRepository, ILogger<ProductCreate> logger)
    {
        _productRepository = productRepository;
        _subCategoryRepository = subCategoryRepository;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Product> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling request to create a new product: {request.Name}");

            var subcategory = await _subCategoryRepository.FindById(request.SubCategoryId);
            if (subcategory is null)
            {
                _logger.LogWarning($"The given subcategory with ID {request.SubCategoryId} was not found.");
                throw new AppException("The given subcategory was not found");
            }

            var productId = Guid.NewGuid();

            var product = new Product(
                id: productId,
                subCategoryId: request.SubCategoryId,
                name: request.Name,
                description: request.Description,
                price: request.Price, 
                image: request.Image,
                stock: request.Stock,
                createdAt: DateTime.Now,
                updatedAt: DateTime.Now 
            );

            _logger.LogInformation($"Created a new product with ID: {productId}");

            await _productRepository.Add(product);

            _logger.LogInformation($"Product with ID {productId} created successfully.");

            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error while handling the request to create a new product: {ex.Message}");
            throw new AppException("Failed to create a new product.", ex);
        }
    }
}