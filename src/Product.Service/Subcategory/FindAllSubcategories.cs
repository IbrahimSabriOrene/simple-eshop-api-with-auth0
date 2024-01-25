using MediatR;
 using Microsoft.Extensions.Logging;
 using Product.Infrastructure.Subcategory;
 using Product.Models;
 using Product.Models.Requests;
 using Product.Service.Helpers;

 namespace Product.Service.Subcategory
 {
     public class FindAllSubcategories : IRequestHandler<FindAllSubcategoriesRequest, IEnumerable<SubCategory>>
     {
         private readonly ISubCategoryRepository _subCategoryRepository;
         private readonly ILogger<FindAllSubcategories> _logger;
 
         public FindAllSubcategories(ISubCategoryRepository subCategoryRepository, ILogger<FindAllSubcategories> logger)
         {
             _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
             _logger = logger ?? throw new ArgumentNullException(nameof(logger));
         }
 
         public async Task<IEnumerable<SubCategory>> Handle(FindAllSubcategoriesRequest request, CancellationToken cancellationToken)
         {
             try
             {
                 _logger.LogInformation("Handling request to find all Subcategories.");
                 var subCategories = await _subCategoryRepository.GetAll();
                 return subCategories;
             }
             catch (Exception ex)
             {
                 _logger.LogError(ex, "Error while handling the request to find all Subcategories");

                 throw new AppException("Error while handling the request", ex);
             }
         }
     }
 }