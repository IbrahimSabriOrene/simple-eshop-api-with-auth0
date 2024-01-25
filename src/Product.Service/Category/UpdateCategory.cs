using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Category;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Category;
using Category = Models.Category;

public class UpdateCategory : IRequestHandler<UpdateCategoryRequest, Category>
{
    private readonly ICategoryRepository _db;
    private readonly ILogger<UpdateCategory> _logger;

    public UpdateCategory(ICategoryRepository db, ILogger<UpdateCategory> logger)
    {
        _db = db;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Category> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Handling request to update category with ID: {request.Id}");

            var category = await _db.FindById(request.Id);

            if (category == null)
            {
                _logger.LogWarning($"Category with ID {request.Id} is not found.");
                throw new AppException("Category is not found");
            }

            category.Description = request.Description;
            category.Name = request.Name;

            await _db.UpdateAsync(category);

            _logger.LogInformation($"Category with ID {request.Id} updated successfully.");

            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while handling the request");
            throw new AppException("Error while handling the request", ex);
        }
    }
}