namespace Product.Infrastructure.Product;
using Product = Models.Product;
public interface IProductRepository
{
    Task Add(Product product);
    Task<Product?> FindById(Guid? id);
    Task<IEnumerable<Product>> GetAll();
    Task<int?> DeleteById(Guid id);
    Task<Product?> UpdateAsync(Product? product);

}