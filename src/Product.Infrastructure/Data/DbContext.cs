using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Product.Infrastructure.Data
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DbContext> _logger;
        private readonly SqlConnectionStringBuilder _builder;

        public DbContext(IConfiguration configuration, ILogger<DbContext> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _builder = new SqlConnectionStringBuilder
            {
                DataSource = _configuration["Database:server"],
                InitialCatalog = _configuration["Database:database"],
                UserID = _configuration["Database:user"],
                Password = _configuration["Database:password"],
                MultipleActiveResultSets = true,
                TrustServerCertificate = true,
            };
        }

        private async Task<IDbConnection> GetOpenConnectionAsync()
        {
            var connection = new SqlConnection(_builder.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }

        public async Task<T?> GetAsync<T>(string sql, object parameters)
        {
            try
            {
                using var connection = await GetOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing query: {Sql}", sql);
                throw new InvalidOperationException("Error executing database query.", ex);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            try
            {
                using var connection = await GetOpenConnectionAsync();
                return await connection.QueryAsync<T>(sql);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing query: {Sql}", sql);
                throw new InvalidOperationException("Error executing database query.", ex);
            }
        }

        public async Task<int> EditDataAsync(string sql, object? parameters)
        {
            try
            {
                using var connection = await GetOpenConnectionAsync();
                return await connection.ExecuteAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing SQL command: {Sql}", sql);
                throw new InvalidOperationException("Error executing SQL command.", ex);
            }
        }
    }
}
