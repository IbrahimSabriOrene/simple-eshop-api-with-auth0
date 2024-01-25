using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Product;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Product;

public class ProductDelete : IRequestHandler<DeleteProductRequest, string>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductDelete> _logger;

    public ProductDelete(IProductRepository productRepository, ILogger<ProductDelete> logger)
    {
        _productRepository = productRepository;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling request to delete product with ID: {request.Id}");

            var product = await _productRepository.FindById(request.Id);
            if (product is null)
            {
                _logger.LogWarning($"Warning!, product with ID {request.Id} was not found.");
                throw new AppException("Warning!, product was not found");
            }

            await _productRepository.DeleteById(request.Id);

            _logger.LogInformation($"Product with ID {request.Id} removed successfully.");

            return "Product is removed.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error while handling the request to delete product with ID: {request.Id}");
            throw new AppException("Error while handling the request", ex);
        }
    }
}