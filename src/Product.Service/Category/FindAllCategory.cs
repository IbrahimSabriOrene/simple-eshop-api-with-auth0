using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Category;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Category;
using Category = Models.Category;

public class FindAllCategory : IRequestHandler<FindAllCategoryRequest, IEnumerable<Category>>
{
    private readonly ICategoryRepository _db;
    private readonly ILogger<FindAllCategory> _logger;

    public FindAllCategory(ICategoryRepository db, ILogger<FindAllCategory> logger)
    {
        _db = db;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<Category>> Handle(FindAllCategoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handling request to find all categories");

            var categories = await _db.GetAll();

            if (categories == null)
            {
                _logger.LogWarning("No categories were found.");
                throw new AppException("No category was found");
            }

            return categories;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while handling the request");
            throw new AppException("Error while handling the request", ex);
        }
    }
}