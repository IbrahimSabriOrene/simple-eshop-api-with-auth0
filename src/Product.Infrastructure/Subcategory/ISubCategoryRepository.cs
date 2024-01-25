namespace Product.Infrastructure.Subcategory;
using Subcategory = Models.SubCategory;

public interface ISubCategoryRepository
{
    Task Add(Subcategory subcategory);
    Task<Subcategory?> FindById(Guid? id);
    Task<IEnumerable<Subcategory>> GetAll();
    Task<int?> DeleteById(Guid id);
    Task<Subcategory?> UpdateAsync(Subcategory? product);
}