namespace Product.Infrastructure.Category;
using Category = Models.Category;

public interface ICategoryRepository
{
    Task Add(Category category);
    Task<Category?> FindById(Guid? id);
    Task<IEnumerable<Category>> GetAll();
    Task<int?> DeleteById(Guid id);
    Task<Category?> UpdateAsync(Category? category);
}