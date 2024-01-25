using Microsoft.Extensions.DependencyInjection;
using Product.Infrastructure.Category;
using Product.Infrastructure.Data;
using Product.Infrastructure.Product;
using Product.Infrastructure.Subcategory;

namespace Product.Infrastructure;

public static class DependencyInjection
{
     public static IServiceCollection AddInfrastructure(this IServiceCollection service)
     {
          service.AddScoped<IProductRepository, ProductRepository>();
          service.AddScoped<ISubCategoryRepository,SubCategoryRepository>();
          service.AddScoped<ICategoryRepository, CategoryRepository>();
          service.AddScoped<IDbContext, DbContext>();

          return service;
     }
}