using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Category;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Category;
using Category = Models.Category; 
public class FindCategory : IRequestHandler<FindCategoryRequest, Category>
{
    private readonly ICategoryRepository _db;
    private readonly ILogger<FindCategory> _logger;

    public FindCategory(ICategoryRepository db, ILogger<FindCategory> logger)
    {
        _db = db;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Category> Handle(FindCategoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling request to find category with ID: {request.Id}");

            var category = await _db.FindById(request.Id);

            if (category != null)
            {
                _logger.LogInformation($"Category with ID {request.Id} found successfully.");
                return category;
            }

            _logger.LogWarning($"Category with ID {request.Id} not found.");
            throw new AppException("Category not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while handling the request");
            throw new AppException("Error while handling the request", ex);
        }
    }
}