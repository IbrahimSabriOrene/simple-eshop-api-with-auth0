using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Product;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Product;
using Product = Models.Product;
public class ProductFind : IRequestHandler<GetProductById, Product>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductFind> _logger;

    public ProductFind(IProductRepository productRepository, ILogger<ProductFind> logger)
    {
        _productRepository = productRepository;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling request to find product with ID: {request.Id}");

            var product = await _productRepository.FindById(request.Id);

            if (product is null)
            {
                _logger.LogWarning($"Warning! Product with ID {request.Id} was not found.");
                throw new AppException("Warning! Product Not Found!");
            }

            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error while handling the request to find product with ID: {request.Id}");
            throw new AppException("Error while handling the request", ex);
        }
    }
}