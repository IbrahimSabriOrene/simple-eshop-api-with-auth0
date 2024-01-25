using Microsoft.Extensions.Configuration;

namespace Product.Infrastructure.Data;

public interface IDbContext
{
  

    Task<T?> GetAsync<T>(string sql, object parameters);
    Task<IEnumerable<T>> QueryAsync<T>(string sql);
    Task<int> EditDataAsync(string sql, object? parameters);
    
}
