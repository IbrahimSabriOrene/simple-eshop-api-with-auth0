using Microsoft.Extensions.Logging;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Product
{
    using Product = Models.Product;

    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly IDbContext _dbContext;

        public ProductRepository(IDbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Add(Product product)
        {
            try
            {
                const string sql = @"
                    INSERT INTO Products (
                        Id,  Name, Description, Price, Image, Stock, CreatedAt, UpdatedAt, SubCategoryId
                    ) VALUES (
                        @Id, @Name, @Description, @Price, @Image, @Stock, @CreatedAt, @UpdatedAt, @SubCategoryId
                    )
                ";

                await _dbContext.EditDataAsync(sql, product);

                _logger.LogInformation("Product added successfully: {ProductId}. Product Details: {ProductDetails}", product.Id, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product: {Product}. Product Details: {ProductDetails}", product, ex);
                throw new Exception("Error adding product.", ex);
            }
        }

        public async Task<Product?> FindById(Guid? id)
        {
            try
            {
                const string sql = "SELECT * FROM Products WHERE Id = @id";
                var parameters = new { id };
                return await _dbContext.GetAsync<Product>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding product by ID: {ProductId}", id);
                throw new Exception("Error finding product by ID.", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                const string sql = "SELECT * FROM Products";
                return await _dbContext.QueryAsync<Product>(sql);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all products");
                throw new Exception("Error getting all products.", ex);
            }
        }

        public async Task<int?> DeleteById(Guid id)
        {
            try
            {
                const string sql = "DELETE FROM Products WHERE Id = @id";
                var parameters = new { id };
                return await _dbContext.EditDataAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product by ID: {ProductId}", id);
                throw new Exception("Error deleting product by ID.", ex);
            }
        }

        public async Task<Product?> UpdateAsync(Product? product)
        {
            try
            {
                const string sql = @"
                    UPDATE Products
                    SET 
                        SubCategoryId = @SubCategoryId,
                        Description = @Description,
                        Name = @Name,
                        Price = @Price,
                        Image = @Image,
                        Stock = @Stock,
                        CreatedAt = @CreatedAt,
                        UpdatedAt = @UpdatedAt
                    WHERE 
                        Id = @Id
                ";

                if (product == null)
                {
                    throw new Exception("Product is null");
                }

                await _dbContext.EditDataAsync(sql, product);

                _logger.LogInformation("Product updated successfully: {ProductId}. Updated Product Details: {ProductDetails}", product.Id, product);
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product: {Product}. Product Details: {ProductDetails}", product, ex);
                throw new Exception("Error updating product.", ex);
            }
        }
    }
}
