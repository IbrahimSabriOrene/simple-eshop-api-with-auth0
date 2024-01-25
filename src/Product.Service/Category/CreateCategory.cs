using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Category;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Category;
using Category = Models.Category;

public class CreateCategory : IRequestHandler<CreateCategoryRequest, Category>
{
    private readonly ICategoryRepository _db;
    private readonly ILogger<CreateCategory> _logger;

    public CreateCategory(ICategoryRepository db, ILogger<CreateCategory> logger)
    {
        _db = db;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Category> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling request to create a new category: {request.Name}");

            var category = new Category(
                Guid.NewGuid(),
                request.Name,
                request.Description);

            _logger.LogInformation($"Created a new category with ID: {category.Id}");

            await _db.Add(category);

            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create a new category.");
            throw new AppException("Failed to create a new category.", ex);
        }
    }
}