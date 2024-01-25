using Microsoft.Extensions.Logging;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Subcategory
{
    using Subcategory = Models.SubCategory;

    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ILogger<SubCategoryRepository> _logger;
        private readonly IDbContext _dbContext;

        public SubCategoryRepository(IDbContext dbContext, ILogger<SubCategoryRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Add(Subcategory subcategory)
        {
            try
            {
                const string sql = @"
                    INSERT INTO Subcategories (
                        Id, Name, Description, ParentCategoryId
                    ) VALUES (
                        @Id, @Name, @Description, @ParentCategoryId
                    )
                ";

                await _dbContext.EditDataAsync(sql, subcategory);

                _logger.LogInformation("Subcategory added successfully: {SubcategoryId}", subcategory.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding subcategory: {Subcategory}", subcategory);
                throw new Exception("Error adding subcategory.", ex);
            }
        }

        public async Task<Subcategory?> FindById(Guid? id)
        {
            try
            {
                const string sql = "SELECT * FROM Subcategories WHERE Id = @id";
                var parameters = new { id };
                return await _dbContext.GetAsync<Subcategory>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding subcategory by ID: {SubcategoryId}", id);
                throw new Exception("Error finding subcategory by ID.", ex);
            }
        }

        public async Task<IEnumerable<Subcategory>> GetAll()
        {
            try
            {
                const string sql = "SELECT * FROM Subcategories";
                return await _dbContext.QueryAsync<Subcategory>(sql);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all subcategories");
                throw new Exception("Error getting all subcategories.", ex);
            }
        }

        public async Task<int?> DeleteById(Guid id)
        {
            try
            {
                const string sql = "DELETE FROM Subcategories WHERE Id = @id";
                var parameters = new { id };
                return await _dbContext.EditDataAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting subcategory by ID: {SubcategoryId}", id);
                throw new Exception("Error deleting subcategory by ID.", ex);
            }
        }

        public async Task<Subcategory?> UpdateAsync(Subcategory? subcategory)
        {
            try
            {
                const string sql = @"
                    UPDATE Subcategories
                    SET 
                        Name = @Name,
                        Description = @Description
                    WHERE 
                        Id = @Id
                ";

                if (subcategory == null)
                {
                    throw new Exception("Invalid subcategory object");
                }

                await _dbContext.EditDataAsync(sql, subcategory);
                return subcategory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating subcategory: {Subcategory}", subcategory);
                throw new Exception("Error updating subcategory.", ex);
            }
        }
    }
}
