using MediatR;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Subcategory;
using Product.Models.Requests;
using Product.Service.Helpers;

namespace Product.Service.Subcategory
{
    public class DeleteSubCategory : IRequestHandler<DeleteSubCategoryRequest, string>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ILogger<DeleteSubCategory> _logger;

        public DeleteSubCategory(ISubCategoryRepository subCategoryRepository, ILogger<DeleteSubCategory> logger)
        {
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(DeleteSubCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Handling request to delete Subcategory with ID: {request.Id}");

                var subCategory = await _subCategoryRepository.FindById(request.Id);
                if (subCategory is not null)
                {
                    _logger.LogInformation($"Subcategory with ID {request.Id} found. Deleting...");

                    await _subCategoryRepository.DeleteById(request.Id);

                    _logger.LogInformation($"Subcategory with ID {request.Id} deleted successfully.");
                    return "The Subcategory Removed";
                }

                _logger.LogInformation($"Subcategory with ID {request.Id} not found.");

                throw new AppException($"Subcategory with ID {request.Id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while handling the request to delete Subcategory with ID: {request.Id}");

                throw new AppException("Error while handling the request", ex);
            }
        }
    }
}
