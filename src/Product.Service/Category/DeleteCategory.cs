using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Category;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Category
{
    public class DeleteCategory : IRequestHandler<DeleteCategoryRequest, string>
    {
        private readonly ICategoryRepository _db;
        private readonly ILogger<DeleteCategory> _logger;

        public DeleteCategory(ICategoryRepository db, ILogger<DeleteCategory> logger)
        {
            _db = db;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Handling request to delete category with ID: {request.Id}");

                var category = await _db.FindById(request.Id);
                if (category == null)
                {
                    _logger.LogWarning($"The given category with ID {request.Id} was not found.");
                    throw new AppException("The given category was not found");
                }

                await _db.DeleteById(request.Id);

                _logger.LogInformation($"Category with ID {request.Id} is removed from categories.");

                return "The given category is removed from categories.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling the request");
                throw new AppException("Error while handling the request", ex);
            }
        }
    }
}