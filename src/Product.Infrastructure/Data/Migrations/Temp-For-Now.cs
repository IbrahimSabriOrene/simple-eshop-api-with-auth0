namespace Product.Infrastructure.Data.Migrations;

public class TempForNow
{
 //   private async Task InitDatabaseAsync(IDbConnection connection)
 //   {
 //       var sql = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{_builder.InitialCatalog}') CREATE DATABASE [{_builder.InitialCatalog}];";
 //       await connection.ExecuteAsync(sql);
 //   }
 //   private async Task InitTablesAsync(IDbConnection connection)
 //   {
 //       //We will add more tables later
 //       await InitProducts();
 //       return;
 //
 //       async Task InitProducts()
 //       {
 //           var sql = @"
 //           IF OBJECT_ID('Products', 'U') IS NULL
 //           CREATE TABLE Products (
 //               Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
 //               SubCategoryName NVARCHAR(MAX),
 //               Name NVARCHAR(MAX),
 //               Description NVARCHAR(MAX),
 //               Price DECIMAL(18,2), 
 //               Image NVARCHAR(MAX),
 //               Stock INT,
 //               CreatedAt DATETIME,
 //               UpdatedAt DATETIME
 //           );
 //       ";
 //           await connection.ExecuteAsync(sql);
 //       }
 //   }
}