using Microsoft.Extensions.Logging;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Infrastructure.Category
{
    using Category = Models.Category;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> _logger;
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Add(Category category)
        {
            try
            {
                const string sql = @"
                    INSERT INTO Categories (
                        Id,  Name, Description
                    ) VALUES (
                        @Id, @Name, @Description
                    )
                ";

                await _dbContext.EditDataAsync(sql, category);

                _logger.LogInformation("Category added successfully: {CategoryId}. Category Details: {CategoryDetails}", category.Id, category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding category: {Category}. Category Details: {CategoryDetails}", category, ex);
                throw new Exception("Error adding category", ex);
            }
        }

        public async Task<Category?> FindById(Guid? id)
        {
            const string sql = "SELECT * FROM Categories WHERE Id = @id";
            var parameters = new { id };

            try
            {
                return await _dbContext.GetAsync<Category>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding category by ID: {CategoryId}", id);
                throw new Exception("Error finding category by ID", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            const string sql = "SELECT * FROM Categories";

            try
            {
                return await _dbContext.QueryAsync<Category>(sql);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all categories");
                throw new Exception("Error getting all categories", ex);
            }
        }

        public async Task<int?> DeleteById(Guid id)
        {
            const string sql = "DELETE FROM Categories WHERE Id = @id";
            var parameters = new { id };

            try
            {
                return await _dbContext.EditDataAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting category by ID: {CategoryId}", id);
                throw new Exception("Error deleting category by ID", ex);
            }
        }

        public async Task<Category?> UpdateAsync(Category? category)
        {
            const string sql = @"
                UPDATE Categories
                SET 
                    Description = @Description,
                    Name = @Name
                WHERE 
                    Id = @Id
            ";

            try
            {
                await _dbContext.EditDataAsync(sql, category);

                _logger.LogInformation("Category updated successfully: {CategoryId}. Updated Category Details: {CategoryDetails}", category?.Id, category);
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category: {Category}. Category Details: {CategoryDetails}", category, ex);
                throw new Exception("Error updating category", ex);
            }
        }
    }
}
